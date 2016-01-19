using UnityEngine;
using System.Collections;

public class CallBlur : MonoBehaviour {
    private GameObject BlurCam;
    private GameObject Player;
    private CameraFollow CameraMove;
	// Use this for initialization
	void Awake () {
        Player = GameObject.Find("Player");
        BlurCam = GameObject.Find("Camera");
        CameraMove = GetComponent<CameraFollow>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddBlur() 
    {
        BlurCam.GetComponent<UnityStandardAssets.ImageEffects.Blur>().enabled = true;
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponentInChildren<CameraFollow>().enabled = false;
    }

    public void RemoveBlur() 
    {
        BlurCam.GetComponent<UnityStandardAssets.ImageEffects.Blur>().enabled = false;
        Player.GetComponent<PlayerMovement>().enabled = true;
        Player.GetComponentInChildren<CameraFollow>().enabled = true;
    }
}
