using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    private enum OperationType { load, unload }

    //This wrapper is used to keep track of each scene we want to load or unload
    private class SceneLoadWrapper
    {
        public string scene;
        public OperationType operation;

        //This defines the SceneLoadWrapper constructor so whenever we make a new wrapper it expects these variables
        public SceneLoadWrapper(string scene, OperationType operation)
        {
            this.scene = scene;
            this.operation = operation;
        }
    }

    //This allows us to store this script as a Singleton, meaning only one should exist in the scene, allowing it to be called by typing SceneSwapper.instance
    public static SceneSwapper instance;

    [Tooltip("NOTE: UI Scenes are loaded in the order stored here.")]
    public string[] uiScenes;
    public string[] gameScenes;

    //For keeping track of whether or not an act is loaded
    private Queue sceneQueue = new Queue();
    private bool loadingScenes = false;
    private AsyncOperation currentOperation;
    private string currentScene;

    private void OnEnable()
    {
        //Store the singleton reference when loaded
        instance = this;
    }

    /// <summary>
    /// Listen for SceneSwapper to finish loading scenes
    /// </summary>
    public event Action OnSceneLoadComplete;

    /// <summary>
    /// Load all the gameplay UI additively on the master scene
    /// </summary>
    public void LoadStartingUI()
    {
        //Only queue load scenes if they are currently not loaded
        foreach (string sceneName in uiScenes)
        {
            if (!ActiveScenes.Contains(sceneName))
            {
                sceneQueue.Enqueue(new SceneLoadWrapper(sceneName, OperationType.load));
            }
        }
        //Start the queue
        StartLoadQueue();
    }

    /// <summary>
    /// Load a given scene from a string
    /// </summary>
    /// <param name="id"></param>
    public void LoadScene(string sceneToLoad)
    {
        //Check if there is a game scene already loaded based on the current scene and unload it if there is
        //However, do not do this if the act to load and the loaded act are one and the same!
        
        //If this is a new game scene, unload the existing game scene first
        if (ActiveScenes.Contains(currentScene) && sceneToLoad != currentScene)
        {
            sceneQueue.Enqueue(new SceneLoadWrapper(currentScene, OperationType.unload));
        }

        //Check if the desired scene is loaded, and load it if it is not loaded yet
        if (!ActiveScenes.Contains(sceneToLoad))
        {
            sceneQueue.Enqueue(new SceneLoadWrapper(sceneToLoad, OperationType.load));
        }

        //Set the loaded scene
        currentScene = sceneToLoad;

        StartLoadQueue();
    }

    /// <summary>
    /// Load a given scene from a given integer. This is what is called a method overload as we call it the same way, but input a different variable
    /// </summary>
    /// <param name="id"></param>
    public void LoadScene(int positionInList)
    {
        //Only try to load if this position is shorter than the length of the game scenes list
        if(positionInList < gameScenes.Length)
        {
            //Store a reference to the scene name based on the given integer
            string sceneToLoad = gameScenes[positionInList];

            //Since the other LoadScene function does everything we need from this point, it causes less errors just to use it again
            LoadScene(sceneToLoad);
        }
        else
        {
            //The integer we got is not in the list
            Debug.LogError("Unable to find a game scene at position " + positionInList);
        }        
    }

    private void StartLoadQueue()
    {
        //Start loading the given scenes if none are queued already
        if (!loadingScenes)
        {
            StartCoroutine(SceneLoadQueue());
        }
    }

    //Enqueues and loads given scenes
    private IEnumerator SceneLoadQueue()
    {
        loadingScenes = true;
        while(sceneQueue.Count > 0)
        {
            if(currentOperation == null || currentOperation.isDone)
            {
                SceneLoadWrapper nextScene = (SceneLoadWrapper)sceneQueue.Peek(); //We peek rather than dequeue in order to maintain the while loop until everything is loaded
                //string nextScene = sceneQueue.Dequeue().ToString();
                StartCoroutine(WaitForScene(nextScene));
            }
            yield return null;
        }

        //If we just finished loading the last scene, we're done
        loadingScenes = false;
        //Tell any scripts listening that we've finished loading the scenes
        OnSceneLoadComplete?.Invoke();
    }

    
    /// <summary>
    /// Load or unload the given scene in the queue
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="load"></param>
    /// <returns></returns>
    private IEnumerator WaitForScene(SceneLoadWrapper wrapper)
    {
        if (wrapper.operation == OperationType.load)
        {
            currentOperation = SceneManager.LoadSceneAsync(wrapper.scene, LoadSceneMode.Additive);
        }
        else
        {
            currentOperation = SceneManager.UnloadSceneAsync(wrapper.scene);
        }

        while (!currentOperation.isDone)
        {
            yield return null;
        }

        //We've finished loading, so dequeue this object
        sceneQueue.Dequeue();
    }

    /// <summary>
    /// Returns the list of active scenes currently loaded
    /// </summary>
    private List<string> ActiveScenes
    {
        get
        {
            //Store a list of active scenes if there are any scenes active that need to be loaded
            List<string> activeScenes = new List<string>();

            if (SceneManager.sceneCount > 1)
            {
                for (int i = 0; i < SceneManager.sceneCount; i++)
                {
                    activeScenes.Add(SceneManager.GetSceneAt(i).name);
                }
            }

            return activeScenes;
        }
    }
}