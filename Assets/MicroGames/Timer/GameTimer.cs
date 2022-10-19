using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{
    public UnityEvent timerFailState;
    public UnityEvent timerSuccessState;

    public float remainingTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        remainingTime = Mathf.Clamp(remainingTime -= Time.deltaTime, 0, 999999);
        //remainingTime = Mathf.Round(remainingTime * 100f) / 100f;
        if (remainingTime > 0)
        {
            Debug.Log(remainingTime);
        }
        else if (remainingTime <= 0)
        {
            timerFailState.Invoke();
            Debug.Log("Timer has run out!");
        }
        
    }
}
