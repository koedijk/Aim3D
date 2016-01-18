using UnityEngine;
using System.Collections;

public class CheckPoints : MonoBehaviour {
    [AddComponentMenu("Image Effects/Blur/Blur")]
    public Respawn respawn;
    public GameObject BlurCam;
    private GameObject Player;
    private CameraFollow CameraMove;
    public ColorChange colorchange;
    private int index;
    private string ObjectTag;
    private float waitTime = 20.0f;
	[SerializeField]
	public Ending endCol;

    void Start() 
    {
        Player = GameObject.Find("Player");
    }

    void AddBlur() 
    {
        BlurCam.GetComponent<UnityStandardAssets.ImageEffects.Blur>().enabled = true;
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponentInChildren<CameraFollow>().enabled = false;

        
    }

    void RemoveBlur() 
    {
        BlurCam.GetComponent<UnityStandardAssets.ImageEffects.Blur>().enabled = false;
        Player.GetComponent<PlayerMovement>().enabled = true;
        Player.GetComponentInChildren<CameraFollow>().enabled = true;
    }

    IEnumerator OnTriggerEnter (Collider other) 
    {
		//Curiosity
        if(this.gameObject.tag == "Cave1")
        {
            if (other.tag == "Player")
            {                
				endCol.curiositySwitch = true;
                Destroy(GameObject.FindWithTag("FloatingRock"));                
                AddBlur();
                yield return new WaitForSeconds(2);                               
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[5];
                yield return new WaitForSeconds(1);
                RemoveBlur();
                Destroy(this.gameObject);

                
            }
        }
		//Order
        if(this.gameObject.tag == "FloatingRock")
        {
            if (other.tag == "Player")
            {
				endCol.orderSwitch = true;
                Destroy(GameObject.FindWithTag("Cave1"));
                AddBlur();
                yield return new WaitForSeconds(2);
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[1];
                yield return new WaitForSeconds(1);
                RemoveBlur();
                Destroy(this.gameObject);
            }
        }
		//Perception
        if (this.gameObject.tag == "Invisible")
        {
            if (other.tag == "Player")
            {
				endCol.perceptionSwitch = true;
                Destroy(GameObject.FindWithTag("Path"));
                AddBlur();
                yield return new WaitForSeconds(2);
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[2];
                yield return new WaitForSeconds(1);
                RemoveBlur();
                Destroy(this.gameObject);
            }
        }
		//Intelligence
        if (this.gameObject.tag == "Path")
        {
            if (other.tag == "Player")
            {
				endCol.intelligenceSwitch = true;
                Destroy(GameObject.FindWithTag("Invisible"));
                AddBlur();
                yield return new WaitForSeconds(2);
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[3];
                yield return new WaitForSeconds(1);
                RemoveBlur();
                Destroy(this.gameObject);
            }
        }
		//Safety
        if (this.gameObject.tag == "Cave2Choice1")
        {
            if (other.tag == "Player")
            {
				endCol.safetySwitch = true;
                Destroy(GameObject.FindWithTag("Cave2Choice2"));
                AddBlur();
                yield return new WaitForSeconds(2);
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[4];
                yield return new WaitForSeconds(1);
                RemoveBlur();
                Destroy(this.gameObject);
            }
        }
		//Danger
        if (this.gameObject.tag == "Cave2Choice2")
        {
            if (other.tag == "Player")
            {
				endCol.dangerSwitch = true;
                Destroy(GameObject.FindWithTag("Cave2Choice1"));
                AddBlur();
                yield return new WaitForSeconds(2);
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[5];
                yield return new WaitForSeconds(1);
                RemoveBlur();              
                Destroy(this.gameObject);
            }
        }
		//Bear
        if (this.gameObject.tag == "Stair1")
        {
            if (other.tag == "Player")
            {
				endCol.bearSwitch = true;
                Destroy(GameObject.FindWithTag("Stair2"));
                Destroy(GameObject.FindWithTag("Stair3"));
                AddBlur();
                yield return new WaitForSeconds(2);
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[6];
                yield return new WaitForSeconds(1);
                RemoveBlur();                
                Destroy(this.gameObject);
            }
        }
		//Eagle
        if (this.gameObject.tag == "Stair2")
        {
            if (other.tag == "Player")
            {
				endCol.eagleSwitch = true;
                Destroy(GameObject.FindWithTag("Stair1"));
                Destroy(GameObject.FindWithTag("Stair3"));
                AddBlur();
                yield return new WaitForSeconds(2);
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[7];
                yield return new WaitForSeconds(1);
                RemoveBlur();
                Destroy(this.gameObject);
            }
        }
		//Rabbit
        if (this.gameObject.tag == "Stair3")
        {
            if (other.tag == "Player")
            {
				endCol.rabbitSwitch = true;
                Destroy(GameObject.FindWithTag("Stair1"));
                Destroy(GameObject.FindWithTag("Stair2"));
                AddBlur();
                yield return new WaitForSeconds(2);
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[8];
                yield return new WaitForSeconds(1);
                RemoveBlur();             
                Destroy(this.gameObject);
            }
        }

        if (other.tag == "Player")
        {
            respawn.CheckpointPos = this.transform.position;
        }

    }
}
