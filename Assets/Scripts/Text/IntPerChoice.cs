using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntPerChoice : MonoBehaviour {

	float timeLeft;
	public Text sentenceShow;
	public Text headerText;
	private bool intPerChoice;
	private bool decreaseTimer;
	private string intPerChoiceSentence = ("Some paths aren't shown initially.");
	private string headerSentence = ("Choice");
    public CallBlur callblur;
	// Use this for initialization
	void Start () {
		decreaseTimer = false;
		timeLeft = 4f;
	}

	// Update is called once per frame
	void Update () {
		if (intPerChoice == true) {
			IntPerChoiceSentence ();
		}
	}

	//This will activate the ending of the game.
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{       
			timeLeft = 4f;
			sentenceShow.color = Color.red;
			intPerChoice = true;
		}
	}

	void IntPerChoiceSentence(){
		headerText.text = headerSentence;
		sentenceShow.text = intPerChoiceSentence;
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
			intPerChoice = false;
            callblur.RemoveBlur();
			Debug.Log ("IntPer End");
		}
	}
}
