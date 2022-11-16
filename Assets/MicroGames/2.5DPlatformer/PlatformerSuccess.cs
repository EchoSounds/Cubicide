using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformerSuccess : MonoBehaviour
{

    [SerializeField] private UnityEvent SuccessTriggered;

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
        SuccessTriggered.Invoke();
        Debug.Log("Success Triggered!");
    }
}
