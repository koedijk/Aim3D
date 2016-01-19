using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartTutorial : MonoBehaviour {
	public Text sentenceShow;
	private bool startBool1;
	private bool startBool2;
	private bool startBool3;
	private bool startBool4;

    public CallBlur callblur;

	float timeLeft = 2f;
	private bool decreaseTimer;

	//Tutorial Sentences
	private string startSentence1 = ("The ordeal you're about to take will function as a personality test.");
	private string startSentence2 = ("During your journey to the top you'll encounter several choices.");
	private string startSentence3 = ("Each of these will impact the world around you.");
	private string startSentence4 = ("The choices you make will ultimately show your true nature.");

	// Use this for initialization
	void Start () {
		decreaseTimer = false;
		timeLeft = 2f;
		sentenceShow.color = Color.yellow;
	}
	
	// Update is called once per frame
	void Update () {
		if (startBool1 == true) {
			StartSentence1 ();
		} else if (startBool2 == true) {
			StartSentence2 ();
		}else if (startBool3 == true) {
			StartSentence3 ();
		}else if (startBool4 == true) {
			StartSentence4 ();
		}
	}

	void ResetTimer(){
		timeLeft = 3f;
	}

	//This will activate the ending of the game.
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{       
			startBool1 = true;
		}
	}

	void StartSentence1(){
		sentenceShow.text = startSentence1;
        callblur.AddBlur();
		decreaseTimer = true;
		if (decreaseTimer == true && timeLeft >= 0f) 
		{
			timeLeft -= Time.deltaTime;
		}
		else if (timeLeft <= 0f) 
		{
			decreaseTimer = false;
			startBool1 = false;
			ResetTimer ();
			startBool2 = true;           
		}
	}

	void StartSentence2 (){
		sentenceShow.text = startSentence2;
		decreaseTimer = true;
		if (decreaseTimer == true && timeLeft >= 0f) 
		{
			timeLeft -= Time.deltaTime;
		}
		else if (timeLeft <= 0f) 
		{
			decreaseTimer = false;
			startBool2 = false;
			ResetTimer ();
			startBool3 = true;
		}
	}
	void StartSentence3 (){
		sentenceShow.text = startSentence3;
		decreaseTimer = true;
		if (decreaseTimer == true && timeLeft >= 0f) 
		{
			timeLeft -= Time.deltaTime;
		}
		else if (timeLeft <= 0f) 
		{
			decreaseTimer = false;
			startBool3 = false;
			ResetTimer ();
			startBool4 = true;
		}
	}
	void StartSentence4 (){
		sentenceShow.text = startSentence4;
		decreaseTimer = true;
		if (decreaseTimer == true && timeLeft >= 0f) 
		{
			timeLeft -= Time.deltaTime;
		}
		else if (timeLeft <= 0f) 
		{
			decreaseTimer = false;
			sentenceShow.text = "";
			startBool4 = false;
			Debug.Log ("End Tutorial");
            callblur.RemoveBlur();
            Destroy(this.gameObject);
		}
	}

}
