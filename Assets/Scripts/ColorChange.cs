using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorChange : MonoBehaviour {
    public Material[] ColorTexture;
    public GameObject ColorTest;

    private int index;
    private bool Color = true;

    private int maxTextures;
    private int arrayPos;
    public Renderer rend;
	// Use this for initialization
	void Start () {
        index = ColorTexture.Length-1;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = ColorTexture[0];
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    void OnTriggerEnter(Collider other)
    {        
        if (other.tag == "Player")
        {
            rend.sharedMaterial = ColorTexture[1];            
        }        
    }
}
