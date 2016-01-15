using UnityEngine;
using System.Collections;

public class RotateStorm : MonoBehaviour {
    private GameObject[] childs;
	// Use this for initialization
	void Start () {
        childs = new GameObject[transform.childCount];
        for (int i = 0; i < 3; i++)
        {
            childs[i] = transform.GetChild(i).gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
        childs[0].transform.Rotate(0, 0.1f, 0, 0);
        childs[1].transform.Rotate(0, 0.3f, 0, 0);
        childs[2].transform.Rotate(0, 0.5f, 0, 0);
	
	}
}
