using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MainMenuExit : MonoBehaviour
{
    [SerializeField] private float delayTime;

    void Start()
    {
        StartCoroutine(DelayedExit());
    }

    IEnumerator DelayedExit() 
    {
        yield return new WaitForSeconds(delayTime);

        #if UNITY_EDITOR
            {
                EditorApplication.isPlaying = false;
            }
        #else
            {
                Application.Quit();
            }
        #endif
    }
}
