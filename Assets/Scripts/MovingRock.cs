using UnityEngine;
using System.Collections;

public class MovingRock : MonoBehaviour {
    public GameObject[] Points;
    private Vector3 Point1;
    private Vector3 Point2;
    private bool dirRight = true;
    private float speed = 0.1f;
	// Use this for initialization
	void Start () 
    {
        Point1 = Points[0].transform.position;
        Point2 = Points[1].transform.position;        
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        if (dirRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, Point1, speed);
            if (transform.position.y >= Point1.y)
            {
                dirRight = false;
            }
        }
        else 
        {
            transform.position = Vector3.MoveTowards(transform.position, Point2, speed);
            if(transform.position.y <= Point2.y)
            {
                dirRight = true;
            }
        }

        
    
       
        
	}
}
