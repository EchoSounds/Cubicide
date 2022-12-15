using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class PromptText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private TextMeshProUGUI winLoseText;
    [SerializeField] private UnityEvent beforePromptEvents;
    [SerializeField] private UnityEvent afterPromptEvents;
    [SerializeField] private string promptTextContents;
    [SerializeField] private string winTextContents;
    [SerializeField] private string loseTextContents;
    [SerializeField] private float textStayTime;

    // Start is called before the first frame update
    void Start()
    {
        beforePromptEvents.Invoke();
        StartCoroutine(TimedPromptText());
    }

    IEnumerator TimedPromptText() 
    {
        promptText.enabled = true;
        promptText.GetComponent<TextMeshProUGUI>().text = promptTextContents;
        yield return new WaitForSeconds(textStayTime);
        afterPromptEvents.Invoke();
        promptText.enabled = false;
    }

    public void GameWin()
    {
        StartCoroutine(TimedWinText());
    }

    IEnumerator TimedWinText() 
    {
        winLoseText.enabled = true;
        winLoseText.GetComponent<TextMeshProUGUI>().text = winTextContents;
        yield return new WaitForSeconds(textStayTime);
    }

    public void GameLose()
    {
        StartCoroutine(TimedLoseText());
    }

    IEnumerator TimedLoseText()
    {
        winLoseText.enabled = true;
        winLoseText.GetComponent<TextMeshProUGUI>().text = loseTextContents;
        yield return new WaitForSeconds(textStayTime);
    }
}
