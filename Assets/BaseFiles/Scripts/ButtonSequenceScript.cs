using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;

public class ButtonSequenceScript : MonoBehaviour
{
    public char[] alpha = "QWEASD".ToCharArray();
    public PlayerInputs inputs;
    public float keyNumber;
    public float keyNumber2;

    private void Awake()
    {
        inputs = new PlayerInputs();
    }

    void Start()
    {
        /*keyNumber = Random.Range(0, alpha.Length);
        keyNumber2 = Random.Range(0, alpha.Length);
        if (keyNumber == keyNumber2)
        {
            keyNumber2 = Random.Range(0, alpha.Length);
        }
        Debug.Log(alpha[(int)keyNumber]);
        Debug.Log(alpha[(int)keyNumber2]);*/
    }








    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    private void Update()
    {
        if (inputs.Space.Space.WasPerformedThisFrame())
        {
            keyNumber = Random.Range(0, alpha.Length);
            keyNumber2 = Random.Range(0, alpha.Length);
            if (keyNumber == keyNumber2)
            {
                keyNumber2 = Random.Range(0, alpha.Length);
            }
            Debug.Log(alpha[(int)keyNumber]);
            Debug.Log(alpha[(int)keyNumber2]);
            fireAction.ApplyBindingOverride(1, default);
            //inputs.Buttons.Button1.ApplyBindingOverride(new InputBinding {path = "keyboard/#space", overridePath = "keyboard/#" + keyNumber});
        }
    }

}
