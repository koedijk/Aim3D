using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private Vector3 movementVector;
	private CharacterController characterController;

    private float speed;
	private float movementSpeed = 8;
    private float runSpeed = 25;
	private float jumpPower = 15;
	private float gravity = 40;
    private float minSensitivity = 0.1f;
	
	void Start()
	{
		characterController = GetComponent<CharacterController>();
        speed = movementSpeed;
	}
	
	void Update()
	{
        Movement();
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

        characterController.Move(movementVector * Time.deltaTime);
    }
}
