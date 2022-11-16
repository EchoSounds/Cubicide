using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using UnityEngine.Events;

public class ButtonSequence : MonoBehaviour
{
    public PlayerInputs inputs;
    [SerializeField] private UnityEvent OnPressSuccess;
    [SerializeField] private UnityEvent OnPressFailure;
    [SerializeField] private UnityEvent OnPass;
    [SerializeField] private UnityEvent OnFail;
    

    [SerializeField] private int sequenceLength, numberOfLoops;
    private int currKeyNum = 0;
    [SerializeField] private float waitTime = 1f;

    [SerializeField] private string inputValue, desiredValue;
    private bool canInput = true, playing = true;
    [SerializeField] private bool looping;


    [SerializeField] private List<string> buttonSequence = new List<string>();
    private List<string> possibleInputs = new List<string>();

    void Awake()
    {
        inputs = new PlayerInputs();

    }
    protected void Start()
    {
        inputs.ButtonSequenceInputs.Enable();

        Initialise();
        GenerateSequence();
    }

    protected void Update()
    {
        PressButtonCheck();
    }
    protected void Initialise()
    {
        possibleInputs.Add("Q");
        possibleInputs.Add("W");
        possibleInputs.Add("E");
        possibleInputs.Add("A");
        possibleInputs.Add("S");
        possibleInputs.Add("D");
    }
    protected void GenerateSequence()
    {
        buttonSequence = new List<string>();
        currKeyNum = 0;

        int valueToAdd = Random.Range(0, possibleInputs.Count);
        buttonSequence.Add(possibleInputs[valueToAdd]);

        desiredValue = buttonSequence[0];

        for (int i = 1; i < sequenceLength; i++)
        {
            valueToAdd = Random.Range(0, possibleInputs.Count);

            if (possibleInputs[valueToAdd] == buttonSequence[i - 1])
            {
                valueToAdd = Random.Range(0, possibleInputs.Count);
            }
            
            buttonSequence.Add(possibleInputs[valueToAdd]);
        }
    }
    protected void PressButtonCheck()
    {
        if (canInput && playing)
        {
            if (inputs.ButtonSequenceInputs.InputQ.WasPressedThisFrame())
            {
                inputValue = "Q";
                CompareInputToDesired();
            }
            else if (inputs.ButtonSequenceInputs.InputW.WasPressedThisFrame())
            {
                inputValue = "W";
                CompareInputToDesired();
            }
            else if (inputs.ButtonSequenceInputs.InputE.WasPressedThisFrame())
            {
                inputValue = "E";
                CompareInputToDesired();
            }
            else if (inputs.ButtonSequenceInputs.InputA.WasPressedThisFrame())
            {
                inputValue = "A";
                CompareInputToDesired();
            }
            else if (inputs.ButtonSequenceInputs.InputS.WasPressedThisFrame())
            {
                inputValue = "S";
                CompareInputToDesired();
            }
            else if (inputs.ButtonSequenceInputs.InputD.WasPressedThisFrame())
            {
                inputValue = "D";
                CompareInputToDesired();
            }
        }
    }
    protected void CompareInputToDesired()
    {
        if (playing)
        {
            if (inputValue != desiredValue && inputValue != "Null")
            {
                canInput = false;
                Debug.Log("WrongButton");
                OnPressFailure.Invoke();
                Invoke("IncorrectButton", waitTime);
            }
            else if (inputValue == desiredValue)
            {
                if (currKeyNum == buttonSequence.Count - 1)
                {
                       

                    if (looping && numberOfLoops != 1)
                    {
                        GenerateSequence();
                        numberOfLoops--;
                        return;
                    } else if (looping && numberOfLoops == 1)
                    {
                        Debug.Log("Finished Loop");
                        OnPass.Invoke();
                    }
                    else
                    {
                        Debug.Log("Success");
                        OnPass.Invoke();
                    }

                    playing = false;
                    return;

                } else
                {
                    currKeyNum++;
                }

                desiredValue = buttonSequence[currKeyNum];
                Debug.Log("CorrectButton");
                OnPressSuccess.Invoke();
            }
            else if (inputValue == "Null")
            {
                return;
            }
        }
    }
    protected void IncorrectButton()
    {
        canInput = true;
        Debug.Log("Cooldown Finished");
    }

}
