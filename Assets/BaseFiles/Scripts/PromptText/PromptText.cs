using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PromptText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private TextMeshProUGUI winLoseText;
    [SerializeField] private string promptTextContents;
    [SerializeField] private string winLoseTextContents;
    [SerializeField] private float textStayTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimedPromptText());
    }

    IEnumerator TimedPromptText() 
    {
        promptText.enabled = true;
        promptText.GetComponent<TextMeshProUGUI>().text = promptTextContents;
        yield return new WaitForSeconds(textStayTime);
        promptText.enabled = false;
    }

    public void GameWin()
    {
        StartCoroutine(TimedWinLoseText());
    }

    IEnumerator TimedWinLoseText() 
    {
        winLoseText.enabled = true;
        winLoseText.GetComponent<TextMeshProUGUI>().text = winLoseTextContents;
        yield return new WaitForSeconds(textStayTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
