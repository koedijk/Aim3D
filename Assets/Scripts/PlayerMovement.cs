using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private Vector3 movementVector;
	private CharacterController characterController;
	
	private float movementSpeed = 8;
	private float jumpPower = 15;
	private float gravity = 40;
	
	void Start()
	{
		characterController = GetComponent<CharacterController>();
	}
	
	void Update()
	{
        Movement();
        Buttons();		
	}

    void Movement() {
        if (Input.GetAxisRaw("LeftJoystickX") > 0.1 || Input.GetAxisRaw("LeftJoystickX") < -0.1)
        {
            movementVector.x = Input.GetAxis("LeftJoystickX") * movementSpeed;
        }
        else
        {
            movementVector.x = 0;
        }
        if (Input.GetAxisRaw("LeftJoystickY") > 0.1 || Input.GetAxisRaw("LeftJoystickY") < -0.1)
        {
            movementVector.z = Input.GetAxis("LeftJoystickY") * movementSpeed;
        }
        else
        {
            movementVector.z = 0;
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
        }

        movementVector.y -= gravity * Time.deltaTime;

        characterController.Move(movementVector * Time.deltaTime);
    }
}
