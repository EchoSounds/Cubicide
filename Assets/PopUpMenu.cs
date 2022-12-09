using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows;

public class PopUpMenu : MonoBehaviour
{
    [SerializeField] private GameObject backing;
    [SerializeField] private GameObject baseGameManager;
    public PlayerInputs inputs;
    private bool paused = false;

    private void Awake()
    {
        inputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        inputs.Enable();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }


    private void Start()
    {
        backing.SetActive(false);
    }

    private void Update()
    {
        if(baseGameManager.GetComponent<BaseGameManager>().currTimelineSpot > 1)
        {
            if (!paused)
            {
                if (inputs.Buttons.Pause.WasPressedThisFrame())
                {
                    paused = true;
                    backing.SetActive(true);
                }
            }
            else
            {
                if (inputs.Buttons.Pause.WasPressedThisFrame())
                {
                    paused = false;
                    backing.SetActive(false);
                }
            }
        }

        if (paused)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
            
        }
    }

    public void Continue()
    {
        paused = false;
        backing.SetActive(false);
    }

    public void MainMenu()
    {
        paused = false;
        backing.SetActive(false);
        BaseGameManager.LoadScene(true, 1, 1);
    }

    public void Exit()
    {
        paused = false;
        backing.SetActive(false);
        Application.Quit();
    }
}
