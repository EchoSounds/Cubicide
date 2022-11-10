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
    [SerializeField] private bool isFacingRight = true;
    private bool isStillPlaying;
    [SerializeField] private GameObject horseSprite;
    [SerializeField] private Material healthyHorse;
    private Transform farmerSprite;
    [SerializeField] private GameObject farmerSpriteObject;
    private Animator farmerAnim;

    public void StartOfGameEvents()
    {
        farmerAnim = farmerSpriteObject.GetComponent<Animator>();
        StartCoroutine(TimedStartOfGameEvents());
    }

    private IEnumerator TimedStartOfGameEvents()
    {
        isStillPlaying = false;
        promptText.enabled = true;
        AllowVerticalMovement = false;
        AllowJumping = false;
        gameTimer.StopTimer = true;
        yield return new WaitForSeconds(textStayTime);
        isStillPlaying = true;
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
            if (isStillPlaying == true)
            {
                farmerAnim.SetTrigger("FarmerHopping");

                if (isFacingRight == false)
                {
                    farmerSprite.localScale = new Vector3(1, farmerSprite.transform.localScale.y, farmerSprite.transform.localScale.z);
                    isFacingRight = true;
                    return;
                }
                else if (isFacingRight == true)
                {
                    return;
                }

                Debug.Log("Pressed Right Key");
            }
            else if (isStillPlaying == false)
            {
                farmerAnim.ResetTrigger("FarmerHopping");
            }
        }
        else if (desiredKBInputV == -1) // If the key that is pressed is the negative binding
        {
            if (isStillPlaying == true)
            {
                farmerAnim.SetTrigger("FarmerHopping");

                if (isFacingRight == true)
                {
                    farmerSprite.localScale = new Vector3(-1, farmerSprite.transform.localScale.y, farmerSprite.transform.localScale.z);
                    isFacingRight = false;
                    return;
                }
                else if (isFacingRight == false)
                {
                    return;
                }
            }
            else if (isStillPlaying == false)
            {
                farmerAnim.ResetTrigger("FarmerHopping");
            }

            Debug.Log("Pressed Left Key");
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
        isStillPlaying = false;
        farmerAnim.SetTrigger("GoalTouched");
        StartCoroutine(TimedTouchHorse());
    }

    private IEnumerator TimedTouchHorse()
    {
        horseSprite.GetComponentInChildren<MeshRenderer>().material = healthyHorse;
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
