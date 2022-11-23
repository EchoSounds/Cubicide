using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlatformerSuccess : MonoBehaviour
{

    [SerializeField] private UnityEvent SuccessTriggered;
    [SerializeField] private bool hasBeenTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenTriggered)
        {
            SuccessTriggered.Invoke();
            Debug.Log("Success Triggered!");
            hasBeenTriggered = true;
        }
    }
}