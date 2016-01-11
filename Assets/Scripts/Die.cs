using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {
    public GameObject Player;
    public Respawn respawn;
    private Vector3 RespawnPos;
	// Use this for initialization

	void Start () {
        
        Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            Player.transform.position = respawn.CheckpointPos;
            Player.transform.eulerAngles = respawn.CheckpointRot;
        }
    }
}
