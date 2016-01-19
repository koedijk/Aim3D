using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimalChoice : MonoBehaviour {

	float timeLeft;
	public Text sentenceShow;
	public Text headerText;
	private bool animalChoice;
	private bool decreaseTimer;
	private string animalsChoiceSentence = ("Which of these do you resemble? Endurance..? Insight..? Or... Agility?");
	private string headerSentence = ("Choice");
    public CallBlur callblur;
	// Use this for initialization
	void Start () {
		decreaseTimer = false;
		timeLeft = 4f;
	}

	// Update is called once per frame
	void Update () {
		if (animalChoice == true) {
			AnimalsChoiceSentence ();
		}
	}

	//This will activate the ending of the game.
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{       
			timeLeft = 4f;
			sentenceShow.color = Color.blue;
			animalChoice = true;
		}
	}

	void AnimalsChoiceSentence(){
		headerText.text = headerSentence;
		sentenceShow.text = animalsChoiceSentence;
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
			animalChoice = false;
            callblur.RemoveBlur();
			Debug.Log ("Animals End");
		}
	}
}
