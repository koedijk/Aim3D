using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private float cameraSensitivity = 0.3f;
    private float rotateSpeed = 250f;
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
            this.transform.rotation *= Quaternion.AngleAxis(rotateSpeed * Input.GetAxis("RightJoystickY") * Time.deltaTime, Vector3.left);
        }
        
    }
}
