using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodProgression : MonoBehaviour
{
    [SerializeField] private List<GameObject> food = new List<GameObject>();
    public UnityEngine.Events.UnityEvent FinishedFood;
    int progress = 5;
    public void NomNoms()
    {
        progress--;
        food[progress].gameObject.SetActive(false);
    }

    private void Update()
    {
        if (progress == 0)
        {
            FinishedFood.Invoke();
        }
    }

}
