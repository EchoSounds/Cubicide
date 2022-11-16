using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public PlayerInputs controls;
    [SerializeField] protected bool AllowVerticalMovement;
    [SerializeField] protected bool AllowHorizontalMovement;
    [SerializeField] protected bool AllowJumping;
    [SerializeField] protected bool isJumpingRestricted;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float jumpHeight;
    protected float desiredKBInputH;
    protected float desiredKBInputV;
    protected float desiredKBInputJ;
    protected Vector3 movementH;
    protected Vector3 movementV;
    protected Vector3 Transform;
    protected float mass;
    protected Rigidbody rb;
    protected bool isInAir = false;
    protected Rigidbody gameObj;

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
        gameObj = this.gameObject.GetComponent<Rigidbody>();
    }

    protected private void Update()
    {
        if (AllowVerticalMovement) 
        {
            VerticalMovement();
        }
        if (AllowHorizontalMovement) 
        {
            HorizontalMovement();
        }
        if (AllowJumping)
        {
            if(!isInAir && isJumpingRestricted || !isJumpingRestricted)
            {
                Jumping();
            }
        }
    }

    protected void VerticalMovement()
    {
        desiredKBInputH = (controls.StandardMovement.HorizMove.ReadValue<float>()); // Go to the StandardMoivement action map and read the HorizMove Vector3 of that mapping.

        if (desiredKBInputH == 1) // If the key that is pressed is the positive binding
        {
            gameObj.velocity = transform.up * moveSpeed; // Create new Vector 3 for moving up.
            //movementH = new Vector3(0, 1, 0); // Create new Vector 3 for moving down.
        }
        else if (desiredKBInputH == -1) // If the key that is pressed is the negative binding
        {
            gameObj.velocity = -transform.up * moveSpeed;
            //movementH = new Vector3(0, -1, 0); // Create new Vector 3 for moving down.
        }
        else // If neither the positive or negative bindings are being detected
        {
            
            gameObj.velocity = Vector3.Scale((gameObj.velocity), new Vector3(1,0,1));
            //movementH = new Vector3(0, 0, 0); // Create new Vector 3 for stopping movement.
        }

        //gameObject.transform.position += (moveSpeed * movementH) * Time.deltaTime; // Times desired movement by speed over the time between the frames then add to object transform
    }

    protected void HorizontalMovement()
    {
        desiredKBInputV = (controls.StandardMovement.VertMove.ReadValue<float>()); // Go to the StandardMoivement action map and read the VertMove Vector3 of that mapping.

        if (desiredKBInputV == 1) // If the key that is pressed is the positive binding
        {
            gameObj.velocity = transform.right * moveSpeed;// * Time.deltaTime;
            //movementV = new Vector3(1, 0, 0); // Create new Vector 3 for moving right.
        }
        else if (desiredKBInputV == -1) // If the key that is pressed is the negative binding
        {
            gameObj.velocity = -transform.right * moveSpeed;
            //movementV = new Vector3(-1, 0, 0); // Create new Vector 3 for moving left.
        }
        else // If neither the positive or negative bindings are being detected
        {
            //this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.Scale(new Vector3(0, 1, 1);
            gameObj.velocity = Vector3.Scale((gameObj.velocity), new Vector3(0,1,1));
            //movementV = new Vector3(0, 0, 0); // Create new Vector 3 for stopping movement.
        }

        //gameObject.transform.position += (moveSpeed * movementV) * Time.deltaTime; // Times desired movement by speed over the time between the frames then add to object transform
    }

    protected private void Jumping()
    {
        desiredKBInputJ = (controls.StandardMovement.Jump.ReadValue<float>()); // Go to the StandardMoivement action map and read the HorizMove Vector3 of that mapping.

        if (desiredKBInputJ == 1 && (gameObj.velocity.y) < 0.001f) // If the key that is pressed is the 
        {
            gameObj.velocity += Vector3.up * jumpHeight;// / mass;
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
            Debug.Log("Collision!");
        }
    }

    // Function calls the goalConsequence event if a trigger tagged as GoalTrigger is entered.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GoalTrigger") // If the collider in question is tagged as "GoalTrigger"
        {
            //goalConsequence.Invoke(); // Invoke the Goal Consequence event.
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