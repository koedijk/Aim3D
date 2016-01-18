using UnityEngine;
using System.Collections;

public class KeyboardMovement : MonoBehaviour
{
	private Vector3 movementVector;
	private CharacterController characterController; 
   

    //Speeds
    private float speed;
   	private float movementSpeed = 10;
    private float runSpeed = 16;


    //Jump
	public float jumpPower = 18;
	private float gravity = 40;
    private bool Grounded = false;

    
    //Controller Sensitivity
    private float minSensitivity = 0.1f;

    
    //Ladder 
    private bool Climb = false;
    
    //Rotation
    private Quaternion playerRotation;
    private float turnInput;
    private float rotateSpeed = 125f;
	

	void Start()
	{
		characterController = GetComponent<CharacterController>();
        speed = movementSpeed;
        playerRotation = transform.rotation;
        
       
	}
	
	void Update()
	{
        transform.rotation = playerRotation;
        Movement();
        Rotation();
        Buttons();
	}

    void Movement() {
        if (Input.GetAxisRaw("Horizontal") > minSensitivity || Input.GetAxisRaw("Horizontal") < -minSensitivity)
        {
            movementVector.x = Input.GetAxis("Horizontal") * speed;
        }
        else 
        {
            movementVector.x = 0;
        }
        if (Input.GetAxisRaw("Vertical") > minSensitivity || Input.GetAxisRaw("Vertical") < -minSensitivity)
        {
            movementVector.z = Input.GetAxis("Vertical") * speed;
        }
           
        else
        {
            movementVector.z = 0;
        }
    }

    void Rotation()
    {

        if (Input.GetAxisRaw("MouseX") > minSensitivity || Input.GetAxisRaw("MouseX") < -minSensitivity)
        {
            playerRotation *= Quaternion.AngleAxis(rotateSpeed * Input.GetAxis("MouseX") * Time.deltaTime, Vector3.up);
            
        }
 
    }

    void Buttons() {
        if (characterController.isGrounded)
        {
            movementVector.y = 0;

            if (Input.GetButtonDown("A"))
            {
                movementVector.y = jumpPower;
                Debug.Log("Player.cs: A");
            }
            if (Input.GetButtonDown("B"))
            {
                Debug.Log("Player.cs: B");
            }
            if (Input.GetButtonDown("X"))
            {
                Debug.Log("Player.cs: X");
            }
            if (Input.GetButtonDown("Y"))
            {
                Debug.Log("Player.cs: Y");
            }
            if (Input.GetButtonDown("LeftStickClick"))
            {
               speed = runSpeed;
               //Debug.Log("Player.cs: LeftStickClick");
            }
            else if (Input.GetButtonUp("LeftStickClick"))
            {
               speed = movementSpeed;
            }
        }

        movementVector.y -= gravity * Time.deltaTime;

        movementVector = transform.TransformDirection(movementVector);
        characterController.Move(movementVector * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Stair")
        {
            Climb = true;
            Debug.Log(Climb);
        }
        else
        {
            Climb = false;
        }
       

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            Climb = false;
        }
        

    }

  
}
