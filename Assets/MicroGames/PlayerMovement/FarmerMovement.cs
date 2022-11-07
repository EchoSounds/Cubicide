using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FarmerMovement : PlayerMovement
{
    [Header("Scene 1.2.2 Level Specific")]
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private TextMeshProUGUI winLoseText;
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private float textStayTime;
    private bool isFacingRight = true;
    private Transform farmerSprite;

    public void StartOfGameEvents()
    {
        StartCoroutine(TimedStartOfGameEvents());
    }

    private IEnumerator TimedStartOfGameEvents()
    {
        promptText.enabled = true;
        AllowVerticalMovement = false;
        AllowJumping = false;
        gameTimer.StopTimer = true;
        yield return new WaitForSeconds(textStayTime);
        promptText.enabled = false;
        AllowVerticalMovement = true;
        AllowJumping = true;
        gameTimer.StopTimer = false;
    }

    private void FixedUpdate()
    {
        farmerSprite = this.transform.Find("FarmerSprite");

        if (desiredKBInputV == 1) // If the key that is pressed is the positive binding
        {
            if (isFacingRight == false)
            {
                farmerSprite.localScale = new Vector3(farmerSprite.transform.localScale.x, farmerSprite.transform.localScale.y, farmerSprite.transform.localScale.z);
                isFacingRight = true;
            }
            else if (isFacingRight == true)
            {
                farmerSprite.localScale = new Vector3(farmerSprite.transform.localScale.x, farmerSprite.transform.localScale.y, farmerSprite.transform.localScale.z);
            }
        }
        else if (desiredKBInputV == -1) // If the key that is pressed is the negative binding
        {
            if (isFacingRight == true)
            {
                farmerSprite.localScale = new Vector3(-farmerSprite.transform.localScale.x, farmerSprite.transform.localScale.y, farmerSprite.transform.localScale.z);
                isFacingRight = false;
            }
            else if (isFacingRight == false)
            {
                farmerSprite.localScale = new Vector3(-farmerSprite.transform.localScale.x, farmerSprite.transform.localScale.y, farmerSprite.transform.localScale.z);
            }
        }
    }

    /* Vector3 CheckBoundary(Vector3 pos) 
    {
        if (pos.x > 7.5f)
            return new Vector3(-7.2f, pos.y, 0);

        if (pos.x < -7.2f)
            return new Vector3(7.5f, pos.y, 0);

        if (pos.y > 3)
            return new Vector3(pos.x, -5, 0);

        if (pos.y < -5)
            return new Vector3(pos.x, 3, 0);

        return pos;
    } */

    public void TouchHorse()
    {
        StartCoroutine(TimedTouchHorse());
    }

    private IEnumerator TimedTouchHorse()
    {
        AllowVerticalMovement = false;
        AllowJumping = false;
        gameTimer.StopTimer = true;
        winLoseText.enabled = true;
        winLoseText.GetComponent<TextMeshProUGUI>().text = "You win!";
        yield return new WaitForSeconds(textStayTime);
        Debug.Log("Microgame Finished.");
    }

    public void TimerUp()
    {
        StartCoroutine(TimedTimerUp());
    }

    private IEnumerator TimedTimerUp()
    {
        AllowVerticalMovement = false;
        AllowJumping = false;
        gameTimer.StopTimer = true;
        winLoseText.enabled = true;
        winLoseText.GetComponent<TextMeshProUGUI>().text = "You lose!";
        yield return new WaitForSeconds(textStayTime);
        Debug.Log("Microgame Finished.");
    }
}
