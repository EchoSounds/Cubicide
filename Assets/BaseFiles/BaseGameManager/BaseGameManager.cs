using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class BaseGameManager : MonoBehaviour
{
    private static BaseGameManager instance;

    private int currTimelineSpot = 0;

    [SerializeField] private List<string> sceneTimeline;
    [SerializeField] private List<string> sceneIndexOrder;

    public Image fader;
    private GameObject[] gameManager;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            fader.rectTransform.sizeDelta = new Vector2(Screen.width + 20, Screen.height + 20);
            fader.gameObject.SetActive(false);
        }
        else
        {
            Destroy(instance);
        }
    }

    private void Start()
    {

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string Scenename;
            Scenename = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i));
            sceneIndexOrder.Add(Scenename);
            Debug.Log(Scenename);
        }
    }
    public void TimelineProgress()
    {
        BaseGameManager.LoadScene(1, 1);
    }

    public static void LoadScene(float duration = 1, float waitTime = 0)
    {
        instance.StartCoroutine(instance.FadeScene(duration,waitTime));
    }

    private IEnumerator FadeScene(float duration, float waitTime)
    {
        yield return new WaitForSeconds(0.5f);

        fader.gameObject.SetActive(true);
        Time.timeScale = 0;


        for (float i = 0; i < 1; i+= Time.deltaTime / duration)
        {
            fader.color = new Color(0, 0, 0,Mathf.Lerp(0,1,i));
            yield return null;
        }

        currTimelineSpot++;
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneTimeline[currTimelineSpot]);

        while (!ao.isDone)
                yield return null;

        yield return new WaitForSeconds(waitTime);

        for (float i = 0; i < 1; i += Time.deltaTime / duration)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, i));
            yield return null;
        }

        fader.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}