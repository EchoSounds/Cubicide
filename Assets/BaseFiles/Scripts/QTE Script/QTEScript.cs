using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class QTEScript : MonoBehaviour
{
    public UnityEvent timerFailState;
    public UnityEvent timerSuccessState;

    public PlayerInputs inputs;

    public float remainingTime;
    public float TimeLeftToPress;
    public bool stopTimer = false;
    public TextMeshProUGUI timer;

    

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

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = TimeLeftToPress;
    }

    // Update is called once per frame
    public void Update()
    {
        timer.text = Mathf.Ceil(remainingTime).ToString();

        if (!stopTimer)
        {
            remainingTime = Mathf.Clamp(remainingTime -= Time.deltaTime, 0, 999999);
            //remainingTime = Mathf.Round(remainingTime * 100f) / 100f;
            if (remainingTime > 0)
            {
                if (inputs.TimerQTE.QTE_E.WasPerformedThisFrame())
                {
                    stopTimer = true;
                    timerSuccessState.Invoke();
                }
                Debug.Log(remainingTime);
            }
            else if (remainingTime <= 0)
            {
                stopTimer = true;
                timerFailState.Invoke();
                Debug.Log("Timer has run out!");
            }
        }
        else
        {
            return;
        }
    }
}
