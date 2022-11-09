using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Animator crossfade;

    private float transitionTime = 0.5f;
    private float cooldown = 1.5f;

    private void Update()
    {
        if (cooldown > 0)
        {
            cooldown = cooldown - Time.deltaTime;
        }
    }

    public void LoadNewLevel(string SceneName)
    {
        if (cooldown <= 0)
        {
            StartCoroutine(LoadLevel(SceneName));
        }
    }

    IEnumerator LoadLevel(string SceneName)
    {
        crossfade.SetTrigger("Start");
        
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(SceneName);
    }

}
