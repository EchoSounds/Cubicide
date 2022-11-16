using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BottomUpTrigger : MonoBehaviour
{

    [SerializeField] private UnityEvent successTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            successTrigger.Invoke();
        }

    }
}
