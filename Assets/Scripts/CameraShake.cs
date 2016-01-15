using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
    private Vector3 NormalPos;
    private Vector3 ShakePos;
    private Quaternion OriginalRot;
    private int ShakeCount = 20;
    private bool Shaking = false;
    private float ShakeIntensity = 0.3f;   
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void ScreenShake() 
    {
        
            if(ShakeCount >= 0)
            {
                ShakePos = this.transform.position;
                this.transform.position = ShakePos + Random.insideUnitSphere * ShakeIntensity;
                ShakeCount--;           
            }
    }
}
