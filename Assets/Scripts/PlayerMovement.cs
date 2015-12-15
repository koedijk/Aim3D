using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private Vector3 movementVector;
	private CharacterController characterController;    
    private float speed;
    private float rotateSpeed = 250;
	private float movementSpeed = 8;
    private float runSpeed = 20;
	private float jumpPower = 15;
	private float gravity = 40;
    private float minSensitivity = 0.1f;
    private bool Climb = false;
    private bool Grounded = false;
    private Quaternion playerRotation;
    private float turnInput;
	
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
        if (Input.GetAxisRaw("LeftJoystickX") > minSensitivity || Input.GetAxisRaw("LeftJoystickX") < -minSensitivity)
        {
            movementVector.x = Input.GetAxis("LeftJoystickX") * speed;   
        }
        else 
        {
            movementVector.x = 0;
        }
        if (Input.GetAxisRaw("LeftJoystickY") > minSensitivity || Input.GetAxisRaw("LeftJoystickY") < -minSensitivity)
        {           
            movementVector.z = Input.GetAxis("LeftJoystickY") * speed;
            
           if (Climb == true)
            {
                movementVector.z = 0;
                movementVector.y = Input.GetAxis("LeftJoystickY") * speed;
            }
            
        }
        else
        {
            movementVector.z = 0;
        }
    }

    void Rotation()
    {
        
        if (Input.GetAxisRaw("RightJoystickX") > minSensitivity || Input.GetAxisRaw("RightJoystickX") < -minSensitivity)
        {
            playerRotation *= Quaternion.AngleAxis(rotateSpeed * Input.GetAxis("RightJoystickX") * Time.deltaTime, Vector3.up);
            //transform.rotation = playerRotation;
        }
        else
        {
            
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
               Debug.Log("Player.cs: LeftStickClick");
            }
            else if (Input.GetButtonUp("LeftStickClick"))
            {
               speed = movementSpeed;
            }
        }

        movementVector.y -= gravity * Time.deltaTime;

        //characterController.Move(movementVector * Time.deltaTime);
        movementVector = transform.TransformDirection(movementVector);
        characterController.Move(movementVector * Time.deltaTime);
    }
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Ladder")
        {
            Climb = true;
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
