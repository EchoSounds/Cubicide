using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FrameTiming : MonoBehaviour
{
    private float CurrentFrameTiming;

    // Update is called once per frame
    void Update()
    {
        CurrentFrameTiming = Mathf.Ceil(Time.deltaTime * 1000); // Rounds the float to the nearest whole number and converts the result from seconds to milliseconds by multiplying by 1000
        this.GetComponent<TextMeshProUGUI>().text = CurrentFrameTiming.ToString() + " ms"; // Sets the text as the float of CurrentFrameTiming
    }
}
