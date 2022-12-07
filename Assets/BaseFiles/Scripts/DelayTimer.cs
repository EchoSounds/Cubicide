using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayTimer : MonoBehaviour
{
    [SerializeField] private GameObject microgameManager;
    [SerializeField] private GameObject keyPrompt;
    [SerializeField] private GameObject timerText;
    [SerializeField] private float timeToDelay;

    // Start is called before the first frame update
    void Start()
    {
        microgameManager.SetActive(false);
        keyPrompt.SetActive(false);
        timerText.SetActive(false);
        StartCoroutine(timerDelay());
    }

    IEnumerator timerDelay() 
    {
        yield return new WaitForSeconds(timeToDelay);
        keyPrompt.SetActive(true);
        timerText.SetActive(true);
        microgameManager.SetActive(true);
    }

}
