using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DanSafChoice : MonoBehaviour{

	float timeLeft;
	public Text sentenceShow;
	public Text headerText;
	private bool danSafChoice;
	private bool decreaseTimer;
	private string danSafChoiceSentence = ("A two-pronged path.. Which will you choose?");
	private string headerSentence = ("Choice");
    public CallBlur callblur;
	// Use this for initialization
	void Start () {
		decreaseTimer = false;
		timeLeft = 4f;
	}

	// Update is called once per frame
	void Update () {
		if (danSafChoice == true) {
			DanSafChoiceSentence ();
		}
	}

	//This will activate the ending of the game.
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{       
			timeLeft = 4f;
			sentenceShow.color = Color.green;
			danSafChoice = true;
		}
	}

	void DanSafChoiceSentence(){
		headerText.text = headerSentence;
		sentenceShow.text = danSafChoiceSentence;
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
			danSafChoice = false;
            callblur.RemoveBlur();
			Debug.Log ("DanSaf End");
		}
	}
}
