using UnityEngine;
using System.Collections;

public class CheckPointManager : MonoBehaviour {
    public GameObject[] checkpoints;
	// Use this for initialization
	void Start () {
        checkpoints = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            checkpoints[i] = transform.GetChild(i).gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") 
        {
            Destroy(GameObject.FindGameObjectWithTag("Cave1"));                     
            Debug.Log(other.name);
        }
        if (other.tag == "Player" ) 
        {
            Destroy(GameObject.FindGameObjectWithTag("FloatingRock"));
            Debug.Log("Player en Cave1");
        }
        
    }
}
