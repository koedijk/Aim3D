using UnityEngine;
using System.Collections;

public class FallingRock : MonoBehaviour {

    public GameObject fallingrock;

	// Use this for initialization
	void Start () {
        Physics.gravity = new Vector3(0, 0, 0);

	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") 
        {
            Physics.gravity = new Vector3(0, -10, 0);
            Destroy(this.gameObject);
        }
    }
}
