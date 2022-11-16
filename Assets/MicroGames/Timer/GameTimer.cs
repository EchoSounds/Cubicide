using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 0;
    private bool tenSecsRemaining;
    public bool StopTimer;
    private bool TextWhiteRed;
    [SerializeField] private UnityEvent TimeUp;

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0 && !StopTimer)
        {
            timeRemaining -= Time.deltaTime;
            this.GetComponent<TextMeshProUGUI>().text = Mathf.Ceil(timeRemaining).ToString(); // Rounds up and sets the text as the float of timeRemaining
        }
        else if (StopTimer)
        {
            if (TextWhiteRed == true)
            {
                this.GetComponent<TextMeshProUGUI>().color = new Color32(100, 0, 0, 255); // Change the text colour to dark red
                return;
            }
            else
            {
                this.GetComponent<TextMeshProUGUI>().color = new Color32(100, 100, 100, 255); // Change the text colour to grey
                return;
            }
            
        }
        else
        {
            Debug.Log("Timer up, game lost.");
            TimeUp.Invoke();
        }

        if (this.GetComponent<TextMeshProUGUI>().text == "10")
        {
            this.GetComponent<TextMeshProUGUI>().color = new Color32(255, 0, 0, 255); // Change the text colour to red
            TextWhiteRed = true;
        }
        else if (this.GetComponent<TextMeshProUGUI>().text == "9")
        {
            this.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255); // Change the text colour to white
            TextWhiteRed = false;
        }
        else if (this.GetComponent<TextMeshProUGUI>().text == "8")
        {
            this.GetComponent<TextMeshProUGUI>().color = new Color32(255, 0, 0, 255); // Change the text colour to red
            TextWhiteRed = true;
        }
        else if (this.GetComponent<TextMeshProUGUI>().text == "7")
        {
            this.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255); // Change the text colour to white
            TextWhiteRed = false;
        }
        else if (this.GetComponent<TextMeshProUGUI>().text == "6")
        {
            this.GetComponent<TextMeshProUGUI>().color = new Color32(255, 0, 0, 255); // Change the text colour to red
            TextWhiteRed = true;
        }
        else if (this.GetComponent<TextMeshProUGUI>().text == "5")
        {
            this.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255); // Change the text colour to white
            TextWhiteRed = false;
        }
        else if (this.GetComponent<TextMeshProUGUI>().text == "4")
        {
            this.GetComponent<TextMeshProUGUI>().color = new Color32(255, 0, 0, 255); // Change the text colour to red
            TextWhiteRed = true;
        }
        else if (this.GetComponent<TextMeshProUGUI>().text == "3")
        {
            this.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255); // Change the text colour to white
            TextWhiteRed = false;
        }
        else if (this.GetComponent<TextMeshProUGUI>().text == "2")
        {
            this.GetComponent<TextMeshProUGUI>().color = new Color32(255, 0, 0, 255); // Change the text colour to red
            TextWhiteRed = true;
        }
        else if (this.GetComponent<TextMeshProUGUI>().text == "1")
        {
            this.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255); // Change the text colour to white
            TextWhiteRed = false;
        }
        else if (this.GetComponent<TextMeshProUGUI>().text == "0")
        {
            this.GetComponent<TextMeshProUGUI>().color = new Color32(255, 0, 0, 255); // Change the text colour to red
            TextWhiteRed = true;
        }
    }
}