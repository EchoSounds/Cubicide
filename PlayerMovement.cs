using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public InputControls controls;
    [SerializeField] private float moveSpeed;
    private Vector2 desiredKBInput;
    private Vector3 movement;


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
        controls = new InputControls();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        desiredKBInput = (controls.PCControls.WASD.ReadValue<Vector2>()); // Go to the action mapping and read the Vector2 of that mapping.

        movement = new Vector3(desiredKBInput.x, 0, desiredKBInput.y); // Create new Vector 3 for desired movement

        gameObject.transform.position += (moveSpeed * movement) * Time.deltaTime; // Times desired movement by speed over the time between the frames then add to object transform
        Debug.Log(desiredKBInput);
    }
}
