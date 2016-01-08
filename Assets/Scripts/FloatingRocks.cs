using UnityEngine;
using System.Collections;

public class FloatingRocks : MonoBehaviour {
    public GameObject[] Points;
    private Vector3 Point1;
    private Vector3 Point2;
    private bool dirRight = true;
    private float speed = 2.0f;
	// Use this for initialization
	void Start () 
    {
        Point1 = Points[0].transform.position;
        Point2 = Points[1].transform.position;        
	}
	
	// Update is called once per frame
	void Update () 
    {
        float Distance = Vector3.Distance(this.transform.position, Point1);
        
        if (dirRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, Point1, speed);
            Debug.Log(Distance);
            if (transform.position.z >= Point1.z)
            {
                dirRight = false;
            }
        }
        else 
        {
            transform.position = Vector3.MoveTowards(transform.position, Point2, 0.1f);
            if(transform.position.z <= Point2.z)
            {
                dirRight = true;
            }
        }

        
    
       
        
	}
}
