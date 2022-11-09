using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ImprovedButtonMash : MonoBehaviour
{
    //Bools
    [Tooltip("True is Bar Game, False is CountDown Game")]
    [SerializeField] bool BarOrCount = true;
    bool playing = true;

    //Timer
    [Tooltip("In seconds")]
    [SerializeField]
    private float timeToComplete = 15f;
    private float remainingTime = 10;
    private float remainingTimeText;

    //Floats
    [Header("Bar Game Stats")]
    [Tooltip("How much the bar goes up each button press")]
    [SerializeField] private float buttonValue = 2.5f;
    [Tooltip("How much the bar goes down each second")]
    [SerializeField] private float decreaseValue = 1f;
    [Tooltip("How much the decreaseValue multiplies by")]
    [SerializeField] private float difficultyMultiplier = 5f;
    private float inputMash, desiredInputMash = 1f, fill = 100f;

    //Ints
    [Header("CountDown Game Stats")]
    [SerializeField] int ButtonCount = 30;



    //Event References
    [Header("Event System Buttons")]
    public UnityEngine.Events.UnityEvent aButton;
    public UnityEngine.Events.UnityEvent dButton;
    public UnityEngine.Events.UnityEvent winState;
    public UnityEngine.Events.UnityEvent loseState;

    //References
    public PlayerInputs inputs;
    [Header("//////////////Ignore Anything Below This//////////////")]
    [SerializeField] private Image fillBar;
    [SerializeField] private Image barOutline;
    [SerializeField] private SpriteRenderer num1;
    [SerializeField] private SpriteRenderer num2;
    [SerializeField] private TextMeshProUGUI timerText;

    //Sprite Renders
    [SerializeField] private SpriteRenderer A, AC, D, DC, S;

    //Lists
    [SerializeField] private List<Sprite> keyCapCovers = new List<Sprite>();
    [SerializeField] private List<Sprite> numCaps = new List<Sprite>();
    [SerializeField] private List<int> splitTime = new List<int>();


    private void Awake()
    {
        inputs = new PlayerInputs();
    }
    private void OnEnable()
    {
        inputs.Enable();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }

    private void Start()
    {
        remainingTime = timeToComplete;

        AC.sprite = keyCapCovers[0];
        DC.sprite = keyCapCovers[1];

        if (BarOrCount)
        {
            num1.gameObject.SetActive(false);
            num2.gameObject.SetActive(false);
        }
        else
        {
            fillBar.gameObject.SetActive(false);
            barOutline.gameObject.SetActive(false);
        }

    }

    private void Update()
    {
        if (playing)
        {
            //Difficulty calculations
            decreaseValue += (0.1f * difficultyMultiplier) * Time.deltaTime;

            //Calculate the remianing time
            remainingTime = Mathf.Clamp(remainingTime -= Time.deltaTime, 0, 999999);
            remainingTimeText = Mathf.Round(remainingTime * 100f) / 100f;

            inputMash = inputs.MultiButtonMash.Mash.ReadValue<float>();

            //Apply remaining time to timer text
            timerText.text = remainingTimeText.ToString();
            if (inputMash == desiredInputMash)
            {
                //FindObjectOfType<AudioManager>().Play("CorrectKey");
                ChangeDesiredInputMash();

                if (BarOrCount == true)
                {
                    fill = Mathf.Clamp(fill + buttonValue, 0, 100);
                } else if (BarOrCount == false )
                {
                    ButtonCount--;
                }
            }

            if (BarOrCount == true)
            {
                //Take decrease value multiplied by the difficulty meter from the fill over time
                fill = Mathf.Clamp(fill - ((decreaseValue * difficultyMultiplier) * Time.deltaTime), 0, 100);

                //Apply the fill amount in a percentage to the image fill
                fillBar.fillAmount = Mathf.Round(fill) / 100f;
            } else if (BarOrCount == false)
            {
                int num = ButtonCount;
                if (num > 0)
                {
                    SplitTimeToDigits(num);
                } else
                {
                    splitTime[1] = 0;
                }


                num1.sprite = numCaps[splitTime[0]];
                num2.sprite = numCaps[splitTime[1]];
            }

            if (BarOrCount)
            {
                if (fill <= 0) //Fail State
                {
                    LoseState();
                }
                else if (remainingTime <= 0) //Win State
                {
                    WinState();
                }
            }
            else
            {
                if (ButtonCount <= 0)
                {
                    WinState();
                }
                else if (remainingTime <= 0)
                {
                    LoseState();
                }
            }
        }
    }

    private  void ChangeDesiredInputMash()
    {
        if (desiredInputMash == 1)
        {
            desiredInputMash = -1;
            AC.sprite = keyCapCovers[1];
            DC.sprite = keyCapCovers[0];

            dButton.Invoke();
        }
        else if (desiredInputMash == -1)
        {
            desiredInputMash = 1;
            AC.sprite = keyCapCovers[0];
            DC.sprite = keyCapCovers[1];

            aButton.Invoke();
        }
        else
        {
            return;
        }
    }
    private void SplitTimeToDigits(int num)
    {
        bool below9 = false;

        if (num <= 9)
        {
            below9 = true;
        }

        List<int> listOfInts = new List<int>();
        while (num > 0)
        {
            listOfInts.Add(num % 10);
            num = num / 10;
        }
        listOfInts.Reverse();

        if (below9)
        {
            listOfInts.Add(listOfInts[0]);
            listOfInts[0] = 0;
        }

        splitTime = listOfInts;
    }
    private void WinState()
    {
        Debug.Log("You Win");
        playing = false;

        winState.Invoke();

        AC.sprite = keyCapCovers[0];
        DC.sprite = keyCapCovers[0];
        A.sprite = keyCapCovers[0];
        D.sprite = keyCapCovers[0];
        S.sprite = keyCapCovers[3];
    }

    private void LoseState()
    {
        Debug.Log("Get Gud");
        playing = false;

        loseState.Invoke();

        AC.sprite = keyCapCovers[0];
        DC.sprite = keyCapCovers[0];
        A.sprite = keyCapCovers[0];
        D.sprite = keyCapCovers[0];
    }
}
