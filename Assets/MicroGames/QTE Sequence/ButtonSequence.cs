using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class ButtonSequence : MonoBehaviour
{
    public PlayerInputs inputs;
    public SpriteRenderer keyCap;
    public SpriteRenderer keyCapCover;

    [SerializeField] private int sequenceLength, numberOfLoops;
    private int currKeyNum = 0, currKeyCap;
    [SerializeField] private float waitTime = 1f;

    [SerializeField] private string inputValue, desiredValue;
    private bool canInput = true, playing = true;
    [SerializeField] private bool looping;

    [SerializeField] private List<Sprite> keyCaps = new List<Sprite>();
    [SerializeField] private List<Sprite> keyCapCovers = new List<Sprite>();
    [SerializeField] private List<string> buttonSequenceCodes = new List<string>();
    private List<int> buttonSequenceInt = new List<int>();
    private List<string> possibleInputs = new List<string>();

    void Awake()
    {
        inputs = new PlayerInputs();

    }
    private void Start()
    {
        inputs.ButtonSequenceInputs.Enable();
        keyCapCover.sprite = keyCapCovers[0];

        Initialise();
        GenerateSequence();
    }

    private void Update()
    {
        PressButtonCheck();
    }
    private void Initialise()
    {
        possibleInputs.Add("Q");
        possibleInputs.Add("W");
        possibleInputs.Add("E");
        possibleInputs.Add("A");
        possibleInputs.Add("S");
        possibleInputs.Add("D");
    }
    private void GenerateSequence()
    {
        buttonSequenceCodes = new List<string>();
        currKeyNum = 0;

        int valueToAdd = Random.Range(0, possibleInputs.Count);
        buttonSequenceCodes.Add(possibleInputs[valueToAdd]);
        buttonSequenceInt.Add(valueToAdd);


        desiredValue = buttonSequenceCodes[0];

        for (int i = 1; i < sequenceLength; i++)
        {
            valueToAdd = Random.Range(0, possibleInputs.Count);

            if (possibleInputs[valueToAdd] == buttonSequenceCodes[i - 1])
            {
                valueToAdd = Random.Range(0, possibleInputs.Count);
            }
            
            buttonSequenceCodes.Add(possibleInputs[valueToAdd]);
            buttonSequenceInt.Add(valueToAdd);
        }

        keyCap.sprite = keyCaps[buttonSequenceInt[0]];
    }
    private void PressButtonCheck()
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
    private void CompareInputToDesired()
    {
        if (playing)
        {
            if (inputValue != desiredValue && inputValue != "Null")
            {
                canInput = false;
                Debug.Log("WrongButton");
                FindObjectOfType<AudioManager>().Play("IncorrectButton");
                keyCapCover.sprite = keyCapCovers[2];
                Invoke("IncorrectButton", waitTime);
            }
            else if (inputValue == desiredValue)
            {
                keyCapCover.sprite = keyCapCovers[1];
                FindObjectOfType<AudioManager>().Play("CorrectButton");
                Debug.Log("CorrectButton");
                Invoke("CorrectButton", 0.2f);
            }
            else if (inputValue == "Null")
            {
                return;
            }
        }
    }
    private void IncorrectButton()
    {
        canInput = true;
        keyCapCover.sprite = keyCapCovers[0];
        Debug.Log("Cooldown Finished");
    }

    private void CorrectButton()
    {
        if (currKeyNum == buttonSequenceCodes.Count - 1)
        {
            keyCapCover.sprite = keyCapCovers[0];
            FindObjectOfType<AudioManager>().Play("Success");
            Debug.Log("Success");

            if (looping && numberOfLoops != 1)
            {
                GenerateSequence();
                numberOfLoops--;
                return;
            }
            else if (looping && numberOfLoops == 1)
            {
                Debug.Log("Finished Loop");
            }

            playing = false;
            keyCap.sprite = keyCaps[6];
            return;

        }
        else
        {
            currKeyNum++;
        }

        desiredValue = buttonSequenceCodes[currKeyNum];
        keyCap.sprite = keyCaps[buttonSequenceInt[currKeyNum]];
        keyCapCover.sprite = keyCapCovers[0];
    }

}
