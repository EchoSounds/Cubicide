using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonMash : MonoBehaviour
{
    private bool pressed = false;
    private bool playing = true;
    private float fill = 100f;
    private float penis;

    public PlayerInputs inputs;

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
    }
    private void Update()
    {
        //Difficulty calculations
        //penis += Time.deltaTime / 10;
        //Debug.Log(penis);
        //decreaseValue = Mathf.Pow(decreaseValue * difficultyMultiplier, penis);

        //Calculate the remianing time
        remainingTime = Mathf.Clamp(remainingTime -= Time.deltaTime, 0, 999999);

        //Only do these things if the game is playing
        if (playing)
        {
            //Apply remaining time to timer text
            timerText.text = remainingTime.ToString();

            //Check if space down
            if (Input.GetKeyDown(KeyCode.Space) && !pressed)
            {
                pressed = true;
                //Add buttonValue to fill
                fill = Mathf.Clamp(fill + buttonValue, 0, 100);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                pressed = false;
            }

            //Take decrease value multiplied by the difficulty meter from the fill over time
            fill = Mathf.Clamp(fill - ((decreaseValue * difficultyMultiplier) * Time.deltaTime), 0, 100);

            //Apply the fill amount in a percentage to the image fill
            fillBar.fillAmount = Mathf.Round(fill) / 100f;
        }

        
        if (fill <= 0) //Fail State
        {
            Debug.Log("Get Gud");
            playing = false;
        } else if (remainingTime <= 0) //Win State
        {
            Debug.Log("You Win");
            playing = false;
        }
    }   
}
