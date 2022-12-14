using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class MultiButtonMash : MonoBehaviour
{
    private bool playing = true;
    private float fill = 100f;
    private float inputMash, desiredInputMash;
    [SerializeField] private UnityEvent OnPass;
    [SerializeField] private UnityEvent OnFail;

    public PlayerInputs inputs;
    [SerializeField]
    private SpriteRenderer A,AC,D,DC,S;

    [SerializeField] private List<Sprite> keyCapCovers = new List<Sprite>();

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

    //References
    [SerializeField]
    private Image fillBar;
    [SerializeField]
    private TextMeshProUGUI timerText;

    //Timer
    [SerializeField]
    private float timeToComplete = 15f;
    private float remainingTime = 1;
    private float remainingTimeText;

    //Stats
    [SerializeField]
    private float difficultyMultiplier = 1.01f;

    [SerializeField]
    private float decreaseValue = 1.01f;
    [SerializeField]
    private float buttonValue = 2.5f;

    private void Start()
    {
        remainingTime = timeToComplete;
        desiredInputMash = 1f;
        DC.sprite = keyCapCovers[1];
    }
    private void Update()
    {
        //Difficulty calculations
        decreaseValue += (0.1f * difficultyMultiplier) * Time.deltaTime;

        //Calculate the remianing time
        remainingTime = Mathf.Clamp(remainingTime -= Time.deltaTime, 0, 999999);
        remainingTimeText = Mathf.Round(remainingTime * 100f) / 100f;

        inputMash = inputs.MultiButtonMash.Mash.ReadValue<float>();

        //Only do these things if the game is playing
        if (playing)
        {
            //Apply remaining time to timer text
            timerText.text = remainingTimeText.ToString();
            if (inputMash == desiredInputMash)
            {
                FindObjectOfType<AudioManager>().Play("CorrectKey");
                fill = Mathf.Clamp(fill + buttonValue, 0, 100);
                ChangeDesiredInputMash();
            }

            //Take decrease value multiplied by the difficulty meter from the fill over time
            fill = Mathf.Clamp(fill - ((decreaseValue * difficultyMultiplier) * Time.deltaTime), 0, 100);

            //Apply the fill amount in a percentage to the image fill
            fillBar.fillAmount = Mathf.Round(fill) / 100f;
        }


        if (fill <= 0) //Fail State
        {

            Debug.Log("Get Gud");
            OnFail.Invoke();
            playing = false;

            AC.sprite = keyCapCovers[0];
            DC.sprite = keyCapCovers[0];
            A.sprite = keyCapCovers[0];
            D.sprite = keyCapCovers[0];
        }
        else if (remainingTime <= 0) //Win State
        {
            Debug.Log("You Win");
            OnPass.Invoke();
            playing = false;

            AC.sprite = keyCapCovers[0];
            DC.sprite = keyCapCovers[0];
            A.sprite = keyCapCovers[0];
            D.sprite = keyCapCovers[0];
            S.sprite = keyCapCovers[3];
        }
    }

    private void ChangeDesiredInputMash()
    {
        if (desiredInputMash == 1)
        {
            desiredInputMash = -1;
            AC.sprite = keyCapCovers[1];
            DC.sprite = keyCapCovers[0];
        } else if (desiredInputMash == -1)
        {
            desiredInputMash = 1;
            AC.sprite = keyCapCovers[0];
            DC.sprite = keyCapCovers[1];
        } else
        {
            return;
        }
    }

    private void ClearMisspress()
    {

    }
}
