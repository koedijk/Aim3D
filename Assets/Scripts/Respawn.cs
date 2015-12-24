using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    public Vector3 RespawnPos;
    public Vector3 CheckpointPos; 
	// Use this for initialization
	void Start () {
        CheckpointPos = new Vector3(32, 47, -210);
        RespawnPos = CheckpointPos;
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            CheckpointPos = this.transform.position;
            RespawnPos = CheckpointPos;
            Debug.Log("Walked Through");
            
            
        }
    }
}
