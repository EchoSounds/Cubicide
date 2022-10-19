using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInputs controls;
    //[SerializeField] private bool AllowVerticalMovement;
    [SerializeField] private bool AllowHorizontalMovement;
    [SerializeField] private bool AllowJumping;
    [SerializeField] private float moveSpeed;
    private float desiredKBInputH;
    //private float desiredKBInputV;
    private Vector3 movement;
    private Vector3 Transform;


    // Start is called before the first frame update

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Awake()
    {
        controls = new PlayerInputs();
    }

    private void Update()
    {
        if (AllowHorizontalMovement == true) 
        {
            HorizontalMovement();
        }
       /* if (AllowVerticalMovement == true) 
        {
            VerticalMovement();
        } */
    }

    private void HorizontalMovement()
    {
        desiredKBInputH = (controls.StandardMovement.HorizMove.ReadValue<float>()); // Go to the action mapping and read the Vector2 of that mapping.

        if (desiredKBInputH == 1) 
        {
            movement = new Vector3(0, 0, 1); // Create new Vector 3 for desired movement
        }
        else if (desiredKBInputH == -1)
        {
            movement = new Vector3(0, 0, -1); // Create new Vector 3 for desired movement
        }
        else 
        {
            movement = new Vector3(0, 0, 0); // Create new Vector 3 for desired movement
        }

        gameObject.transform.position += (moveSpeed * movement) * Time.deltaTime; // Times desired movement by speed over the time between the frames then add to object transform
        Debug.Log(desiredKBInputH);
    }

    /*private void VerticalMovement()
    {
        desiredKBInputV = (controls.StandardMovement.VertMove.ReadValue<float>()); // Go to the action mapping and read the Vector2 of that mapping.

        movement = new Vector3(desiredKBInputV.x, 0, 0); // Create new Vector 3 for desired movement

        gameObject.transform.position += (moveSpeed * movement) * Time.deltaTime; // Times desired movement by speed over the time between the frames then add to object transform
        Debug.Log(desiredKBInputV);
    }*/
}
