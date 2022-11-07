using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public PlayerInputs controls;

    [Header("Enable/Disable Movement Controls")]
    [SerializeField] protected private bool AllowVerticalMovement;
    [SerializeField] protected private bool AllowHorizontalMovement;
    [SerializeField] protected private bool AllowJumping;
    [SerializeField] protected private bool isJumpingRestricted;
    /*[SerializeField] protected private bool BoundaryEnabled;
    [SerializeField] protected private Vector3 Boundary;*/

    [Header("Movement Speed/Power")]
    [SerializeField] protected private float moveSpeed;
    [SerializeField] protected private float jumpHeight;

    [Header("Unity Events")]
    [SerializeField] protected private UnityEvent gameBeginEvents;
    [SerializeField] protected private UnityEvent goalConsequence;

    protected private float desiredKBInputH;
    protected private float desiredKBInputV;
    protected private float desiredKBInputJ;
    protected private Vector3 movementH;
    protected private Vector3 movementV;
    protected private Vector3 Transform;
    protected private float mass;
    protected private Rigidbody rb;
    protected private bool isInAir = false;


    // Start is called before the first frame update

    protected private void OnEnable()
    {
        controls.Enable();
    }

    protected private void OnDisable()
    {
        controls.Disable();
    }

    protected private void Awake()
    {
        controls = new PlayerInputs();
        rb = GetComponent<Rigidbody>();
        mass = rb.mass;
        gameBeginEvents.Invoke();
    }

    protected private void Update()
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
            if(!isInAir && isJumpingRestricted || !isJumpingRestricted)
            {
                Jumping();
            }
        }
    }

    protected private void HorizontalMovement()
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

    protected private void VerticalMovement()
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

        gameObject.transform.position += (moveSpeed * movementV) * Time.deltaTime/* + CheckBoundary(gameObject.transform.position)*/; // Times desired movement by speed over the time between the frames then add to object transform
        

    }

    protected private void Jumping()
    {
        desiredKBInputJ = (controls.StandardMovement.Jump.ReadValue<float>()); // Go to the StandardMoivement action map and read the HorizMove Vector3 of that mapping.

        if (desiredKBInputJ == 1 && Mathf.Abs(this.GetComponent<Rigidbody>().velocity.y) < 0.001f) // If the key that is pressed is the 
        {
            this.GetComponent<Rigidbody>().velocity += Vector3.up * this.jumpHeight / mass;
            if(isJumpingRestricted)
            {
                isInAir = true;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Collided");
        }

        if(collision.gameObject.tag == "floor")
        {
            isInAir = false;
        }
    }

    // Function calls the goalConsequence event if a trigger tagged as GoalTrigger is entered.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GoalTrigger") // If the collider in question is tagged as "GoalTrigger"
        {
            goalConsequence.Invoke(); // Invoke the Goal Consequence event.
            Debug.Log("Touched goal."); // Send string to debug log.
        }
    }

    /*Vector3 CheckBoundary(Vector3 pos) 
    {
        if (BoundaryEnabled == true) 
        {
            if (pos.x > Boundary.x)
            return new Vector3(1, 0, 0);
            Debug.Log("Hit right boundary.");

            if (pos.x < -Boundary.x)
            return new Vector3(-1, 0, 0);
            Debug.Log("Hit left boundary.");

            if (pos.y > Boundary.y)
            return new Vector3(0, 1, 0);

            if (pos.y < -Boundary.y)
            return new Vector3(0, -1, 0);

            return pos;
        }
        else 
        {
            return pos;
        }
    }*/
}