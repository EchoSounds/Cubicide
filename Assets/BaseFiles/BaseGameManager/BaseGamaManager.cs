using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseGamaManager : MonoBehaviour
{
    private int currTimelineSpot = 0;

    [SerializeField] private List<string> sceneTimeline;
    [SerializeField] private List<string> sceneIndexOrder;

    private SceneLoader sceneLoader;

    private void Start()
    {
        DontDestroyOnLoad(this);

        sceneLoader = FindObjectOfType<SceneLoader>();

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string Scenename;
            Scenename = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i));
            sceneIndexOrder.Add(Scenename);
            Debug.Log(Scenename);
        }
    }

    void OnSceneLoaded()
    {
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
    }
    public void NextScene()
    {
        currTimelineSpot++;
        sceneLoader.LoadNewLevel(sceneTimeline[currTimelineSpot]);
    }
}