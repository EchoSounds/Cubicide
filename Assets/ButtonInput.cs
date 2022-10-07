using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInput : MonoBehaviour
{
    protected List<string> buttons = new List<string>();
    protected List<string> letters = new List<string>();
    protected int letter;

    void Awake()
    {
        AddToList();
    }

    protected void AddToList()
    {
        buttons.Add("W");
        buttons.Add("A");
        buttons.Add("S");
        buttons.Add("D");
        buttons.Add("Q");
        buttons.Add("E");
    }

    protected void InstMultiButton()
    {
        int letter = Random.Range(0, buttons.Count);
        letters.Add(buttons[letter]);
        Debug.Log(letters[0]);
    }


}
/*for (int i = 0; i <= buttons.Count - 1; i++)
 {
     Debug.Log(buttons[i]);
 }*/