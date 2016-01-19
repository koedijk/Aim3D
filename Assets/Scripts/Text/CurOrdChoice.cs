using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurOrdChoice : MonoBehaviour {

	float timeLeft;
	public Text sentenceShow;
	public Text headerText;
	private bool curOrdChoice;
	private bool decreaseTimer;
	private string curOrdChoiceSentence = ("Do you follow the will of others, or seek your own?");
	private string headerSentence = ("Choice");
    public CallBlur callblur;
	// Use this for initialization
	void Start () {
		decreaseTimer = false;
		timeLeft = 4f;
	}

	// Update is called once per frame
	void Update () {
		if (curOrdChoice == true) {
			CurOrdChoiceSentence ();
		}
	}

	//This will activate the ending of the game.
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{       
			timeLeft = 4f;
			sentenceShow.color = Color.blue;
			curOrdChoice = true;
		}
	}

	void CurOrdChoiceSentence(){
		headerText.text = headerSentence;
		sentenceShow.text = curOrdChoiceSentence;
        callblur.AddBlur();
		decreaseTimer = true;
		if (decreaseTimer == true && timeLeft >= 0f) 
		{
			timeLeft -= Time.deltaTime;
		}
		else if (timeLeft <= 0f) 
		{
			decreaseTimer = false;
			headerText.text = "";
			sentenceShow.text = "";
			curOrdChoice = false;
            callblur.RemoveBlur();
			Debug.Log ("CurOrd End");
		}
	}
}