using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodProgression : MonoBehaviour
{
    [SerializeField] private List<GameObject> food = new List<GameObject>();
    public UnityEngine.Events.UnityEvent FinishedFood;
    [SerializeField]int progress = 6;
    public void NomNoms()
    {
        progress--;
        food[progress].gameObject.SetActive(false);
    }

    private void Update()
    {
        if (progress == 2)
        {
            food[1].gameObject.SetActive(false);
        }
    }
}
