using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private float cameraSensitivity = 0.3f;
    private float rotateSpeed = 60f;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        Rotate();        
	}

    void Rotate() 
    {
        if (Input.GetAxisRaw("RightJoystickY") > cameraSensitivity || Input.GetAxisRaw("RightJoystickY") < -cameraSensitivity)
        {
            this.transform.rotation *= Quaternion.AngleAxis(rotateSpeed * Input.GetAxis("RightJoystickY") * Time.deltaTime, Vector3.right);
        }
        if (Input.GetAxisRaw("MouseY") > cameraSensitivity || Input.GetAxisRaw("MouseY") < -cameraSensitivity)
        {
            this.transform.rotation *= Quaternion.AngleAxis(rotateSpeed * Input.GetAxis("MouseY") * Time.deltaTime, Vector3.right);
        }
    }
}
