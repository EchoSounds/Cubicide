using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SecondPlayerMovement : MonoBehaviour
{
    public PlayerInputs controls;
    [SerializeField] private bool AllowVerticalMovement;
    [SerializeField] private bool AllowHorizontalMovement;
    [SerializeField] private bool AllowJumping;
    [SerializeField] private bool isJumpingRestricted;
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
    private bool isInAir = false;
    private Rigidbody gameRigid;
    private GameObject gameObj;


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
        gameRigid = this.gameObject.GetComponent<Rigidbody>();
        gameObj = this.gameObject;
    }

    private void Update()
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

    private void VerticalMovement()
    {
        desiredKBInputH = (controls.StandardMovement.HorizMove.ReadValue<float>()); // Go to the StandardMoivement action map and read the HorizMove Vector3 of that mapping.

        if (desiredKBInputH == 1 ) // If the key that is pressed is the positive binding
        {
            gameRigid.velocity = new Vector3(gameRigid.velocity.x, 1 * moveSpeed, gameRigid.velocity.z);
            //movementH = new Vector3(0, 1, 0); // Create new Vector 3 for moving down.
        }
        else if (desiredKBInputH == -1) // If the key that is pressed is the negative binding
        {
            gameRigid.velocity = new Vector3(gameRigid.velocity.x, -1 * moveSpeed, gameRigid.velocity.z);
            //movementH = new Vector3(0, -1, 0); // Create new Vector 3 for moving down.
        }
        else // If neither the positive or negative bindings are being detected
        {
            
            gameRigid.velocity = new Vector3(gameRigid.velocity.x, 0, gameRigid.velocity.z);
            //movementH = new Vector3(0, 0, 0); // Create new Vector 3 for stopping movement.
        }

        //gameObject.transform.position += (moveSpeed * movementH) * Time.deltaTime; // Times desired movement by speed over the time between the frames then add to object transform
    }

    private void HorizontalMovement()
    {
        desiredKBInputV = (controls.StandardMovement.VertMove.ReadValue<float>()); // Go to the StandardMoivement action map and read the VertMove Vector3 of that mapping.

        if (desiredKBInputV == 1) // If the key that is pressed is the positive binding
        {
            gameRigid.velocity = new Vector3(1 * moveSpeed, gameRigid.velocity.y, gameRigid.velocity.z);
            
            //movementV = new Vector3(1, 0, 0); // Create new Vector 3 for moving right.
        }
        else if (desiredKBInputV == -1) // If the key that is pressed is the negative binding
        {
            
            gameRigid.velocity = new Vector3(-1 * moveSpeed, gameRigid.velocity.y, gameRigid.velocity.z);
            
            //movementV = new Vector3(-1, 0, 0); // Create new Vector 3 for moving left.
        }
        else // If neither the positive or negative bindings are being detected
        {
            gameRigid.velocity = new Vector3(0 , gameRigid.velocity.y, gameRigid.velocity.z);
            //movementV = new Vector3(0, 0, 0); // Create new Vector 3 for stopping movement.
        }
        //gameObject.transform.position += (moveSpeed * movementV) * Time.deltaTime; // Times desired movement by speed over the time between the frames then add to object transform
    }

    private void Jumping()
    {
        desiredKBInputJ = (controls.StandardMovement.Jump.ReadValue<float>()); // Go to the StandardMoivement action map and read the HorizMove Vector3 of that mapping.

        if (desiredKBInputJ == 1 && (gameRigid.velocity.y) < 0.001f) // If the key that is pressed is the 
        {
            gameRigid.velocity += Vector3.up * jumpHeight;// / mass;
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
}