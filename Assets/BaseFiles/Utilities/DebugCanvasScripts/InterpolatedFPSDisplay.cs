using UnityEngine;
using TMPro;
using System.Collections;

// An FPS counter.
// It calculates frames/second over each updateInterval,
// so the display does not keep changing wildly.
public class InterpolatedFPSDisplay : MonoBehaviour
{
    public float updateInterval = 0.5F;
    private double lastInterval;
    private int frames;
    private float fps;
    public TextMeshProUGUI display_Text;

    void Start()
    {
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
    }

    void OnGUI()
    {
        //GUILayout.Label("" + fps.ToString("f2"));
        display_Text.text = fps.ToString() + " Avg FPS"; 
    }

    void Update()
    {
        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = Mathf.Ceil((float)(frames / (timeNow - lastInterval))); // Mathf.Ceil will round the outputted integer up to the nearest whole number
            frames = 0;
            lastInterval = timeNow;
        }
    }
}