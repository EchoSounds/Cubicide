using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public PlayerInputs controls;
    [SerializeField] private bool AllowVerticalMovement;
    [SerializeField] private bool AllowHorizontalMovement;
    [SerializeField] private bool AllowJumping;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    private float desiredKBInputH;
    private float desiredKBInputV;
    private float desiredKBInputJ;
    private Vector3 movementH;
    private Vector3 movementV;
    private Vector3 Transform;
    private float mass;
    private Rigidbody rb;


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
        rb = GetComponent<Rigidbody>();
        mass = rb.mass;
    }

    private void Update()
    {
        if (AllowHorizontalMovement == true) 
        {
            HorizontalMovement();
        }
        if (AllowVerticalMovement == true) 
        {
            VerticalMovement();
        }
        if (AllowJumping == true)
        {
            Jumping();
        }
    }

    private void HorizontalMovement()
    {
        desiredKBInputH = (controls.StandardMovement.HorizMove.ReadValue<float>()); // Go to the StandardMoivement action map and read the HorizMove Vector3 of that mapping.

        if (desiredKBInputH == 1) // If the key that is pressed is the positive binding
        {
            movementH = new Vector3(0, 0, 1); // Create new Vector 3 for moving up.
        }
        else if (desiredKBInputH == -1) // If the key that is pressed is the negative binding
        {
            movementH = new Vector3(0, 0, -1); // Create new Vector 3 for moving down.
        }
        else // If neither the positive or negative bindings are being detected
        {
            movementH = new Vector3(0, 0, 0); // Create new Vector 3 for stopping movement.
        }

        gameObject.transform.position += (moveSpeed * movementH) * Time.deltaTime; // Times desired movement by speed over the time between the frames then add to object transform
    }

    private void VerticalMovement()
    {
        desiredKBInputV = (controls.StandardMovement.VertMove.ReadValue<float>()); // Go to the StandardMoivement action map and read the VertMove Vector3 of that mapping.

        if (desiredKBInputV == 1) // If the key that is pressed is the positive binding
        {
            movementV = new Vector3(1, 0, 0); // Create new Vector 3 for moving right.
        }
        else if (desiredKBInputV == -1) // If the key that is pressed is the negative binding
        {
            movementV = new Vector3(-1, 0, 0); // Create new Vector 3 for moving left.
        }
        else // If neither the positive or negative bindings are being detected
        {
            movementV = new Vector3(0, 0, 0); // Create new Vector 3 for stopping movement.
        }

        gameObject.transform.position += (moveSpeed * movementV) * Time.deltaTime; // Times desired movement by speed over the time between the frames then add to object transform
        

    }

    private void Jumping()
    {
        desiredKBInputJ = (controls.StandardMovement.Jump.ReadValue<float>()); // Go to the StandardMoivement action map and read the HorizMove Vector3 of that mapping.

        if (desiredKBInputJ == 1 && Mathf.Abs(this.GetComponent<Rigidbody>().velocity.y) < 0.001f) // If the key that is pressed is the 
        {
            this.GetComponent<Rigidbody>().velocity += Vector3.up * this.jumpHeight / mass;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Collided");
        }
    }
}