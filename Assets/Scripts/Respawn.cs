using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    public Vector3 CheckpointPos;
    public Vector3 CheckpointRot;
	// Use this for initialization
	void Awake () {
        CheckpointPos = new Vector3(32, 47, -210);
        CheckpointRot = this.transform.eulerAngles;
        Debug.Log(CheckpointRot);

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "CheckPoint") {
            
            Debug.Log("Walked Through");
            CheckpointPos = other.transform.position;
            CheckpointRot = transform.rotation.eulerAngles;
            Debug.Log(CheckpointPos);
            Debug.Log(CheckpointRot);
            Destroy(other);
            
        }
    }
}
