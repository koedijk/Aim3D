using UnityEngine;
using System.Collections;

public class AntiGravity : MonoBehaviour {
    public PlayerMovement JumpPower;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col) 
    {
        if (col.tag == "Anti-Gravity") 
        {
            JumpPower.jumpPower = 65;
        }
        if (col.tag == "Fall") 
        {

        }
    }

    void OnTriggerExit(Collider col) 
    {
        JumpPower.jumpPower = 18;
    }
}
