using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRestart : MonoBehaviour
{
    [SerializeField] private GameObject gameObj;
    [SerializeField] private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = gameObj.transform.position;
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObj.transform.position = playerPos;
            Debug.Log("IsTriggered");
        }

    }
}
