using UnityEngine;
using System.Collections;

public class CheckPoints : MonoBehaviour {
    [AddComponentMenu("Image Effects/Blur/Blur")]
    public Respawn respawn;
    public CallBlur callblur;
    public ColorChange colorchange;
    private int index;
    private string ObjectTag;
    private float waitTime = 20.0f;
	[SerializeField]
	public Ending endCol;

    void Start() 
    {
        
    }

    /*void AddBlur() 
    {
        callblur.GetComponent<UnityStandardAssets.ImageEffects.Blur>().enabled = true;
        callblur.GetComponent<PlayerMovement>().enabled = false;
        callblur.GetComponentInChildren<CameraFollow>().enabled = false;        
    }

    void RemoveBlur() 
    {
        callblur.GetComponent<UnityStandardAssets.ImageEffects.Blur>().enabled = false;
        callblur.GetComponent<PlayerMovement>().enabled = true;
        callblur.GetComponentInChildren<CameraFollow>().enabled = true;
    }*/

    IEnumerator OnTriggerEnter (Collider other) 
    {
		//Curiosity
        if(this.gameObject.tag == "Cave1")
        {
            if (other.tag == "Player")
            {                
				endCol.curiositySwitch = true;
                Destroy(GameObject.FindWithTag("FloatingRock"));                
                callblur.AddBlur();
                yield return new WaitForSeconds(1);                               
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[0];
                yield return new WaitForSeconds(1);
                callblur.RemoveBlur();
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
                callblur.AddBlur();
                yield return new WaitForSeconds(1);
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[1];
                yield return new WaitForSeconds(1);
                callblur.RemoveBlur();
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
                callblur.AddBlur();
                yield return new WaitForSeconds(1);
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[2];
                yield return new WaitForSeconds(1);
                callblur.RemoveBlur();
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
                callblur.AddBlur();
                yield return new WaitForSeconds(1);
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[3];
                yield return new WaitForSeconds(1);
                callblur.RemoveBlur();
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
                callblur.AddBlur();
                yield return new WaitForSeconds(1);
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[4];
                yield return new WaitForSeconds(1);
                callblur.RemoveBlur();
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
                callblur.AddBlur();
                yield return new WaitForSeconds(1);
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[5];
                yield return new WaitForSeconds(1);
                callblur.RemoveBlur();             
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
                callblur.AddBlur();
                yield return new WaitForSeconds(1);
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[6];
                yield return new WaitForSeconds(1);
                callblur.RemoveBlur();               
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
                callblur.AddBlur();
                yield return new WaitForSeconds(1);
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[7];
                yield return new WaitForSeconds(1);
                callblur.RemoveBlur();
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
                callblur.AddBlur();
                yield return new WaitForSeconds(1);
                colorchange.rend.sharedMaterial = colorchange.ColorTexture[8];
                yield return new WaitForSeconds(1);
                callblur.RemoveBlur();             
                Destroy(this.gameObject);
            }
        }

        if (other.tag == "Player")
        {
            respawn.CheckpointPos = this.transform.position;
        }

    }
}
