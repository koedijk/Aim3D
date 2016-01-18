using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial : MonoBehaviour {

	float timeLeft = 2f;
	private bool decreaseTimer;

	public Text headerText;
	public Text sentenceShow;

	//Tutorial Sentences
	private string startSentence1 = ("The ordeal you're about to take will function as a personality test.");
	private string startSentence2 = ("During your journey to the top you'll encounter several choices.");
	private string startSentence3 = ("Each of these will impact the world around you.");
	private string startSentence4 = ("The choices you make will ultimately show your true nature.");

	//Headers
	private string choiceSentence = ("Choice");
	private string chosenSentence = ("Chosen");

	//Choice/Chosen sentences
	private string curOrdChoiceSentence = ("Do you follow the will of others, or seek your own?");
	private string curOrdChosenSentence= ("Within this world, your will does not matter, only your choices within do.");
	private string intPerChoiceSentence = ("Some paths aren't shown initially.");
	private string intPerChosenSentence = ("Destiny leads you.");
	private string danSafChoiceSentence = ("A two-pronged path.. Which will you choose?");
	private string danSafChosenSentence = ("Sometimes makingthe distinction between danger and safety won't matter.");
	private string animalsChoiceSentence = ("Which of these do you resemble? Endurance..? Insight..? or... Agility?");

	// Use this for initialization
	void Start () {
		decreaseTimer = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TimeEvent(){
		timeLeft = 2f;
		decreaseTimer = true;
		if (decreaseTimer == true && timeLeft >= 0f) 
		{
			timeLeft -= Time.deltaTime;
		}
		else if (timeLeft <= 0f) 
		{
			decreaseTimer = false;
			sentenceShow.text = "";
		}
	}

	//Activates every tutorial or sentence
	void OnTriggerEnter(Collider other){
		
		//Tutorial Start 1
		if(this.tag == "PillarStart1"){
			if(other.tag == "Player")
			{
				sentenceShow.text = startSentence1;
				decreaseTimer = true;
				if (decreaseTimer == true && timeLeft >= 0f) 
				{
					timeLeft -= Time.deltaTime;
				}
				else if (timeLeft <= 0f) 
				{
					decreaseTimer = false;
					StartSentence2 ();
				}
			}	
		}

		//CurOrd Choice
		if(this.tag == "CurOrdChoice"){
			if(other.tag == "Player")
			{
				CurOrdChoice();
			}	
		}
		//CurOrd Chosen
		if(this.tag == "CurOrdChosen"){
			if(other.tag == "Player")
			{
				CurOrdChosen();
			}	
		}
		//IntPerChoice
		if(this.tag == "IntPerChoice"){
			if(other.tag == "Player")
			{
				IntPerChoice();
			}	
		}
		//IntPerChosen
		if(this.tag == "IntPerChosen"){
			if(other.tag == "Player")
			{
				IntPerChosen();
			}	
		}
		//DanSafChoice
		if(this.tag == "DanSafChoice"){
			if(other.tag == "Player")
			{
				DanSafChoice();
			}	
		}
		//DanSafChosen
		if(this.tag == "DanSafChosen"){
			if(other.tag == "Player")
			{
				DanSafChosen();
			}	
		}
		//AnimalsChoice
		if(this.tag == "AnimalPillar"){
			if(other.tag == "Player")
			{
				AnimalChoice();
			}	
		}
	}

	void StartSentence2 (){
		sentenceShow.text = startSentence2;
		timeLeft = 2f;
		decreaseTimer = true;
		if (decreaseTimer == true && timeLeft >= 0f) 
		{
			timeLeft -= Time.deltaTime;
		}
		else if (timeLeft <= 0f) 
		{
			decreaseTimer = false;
			StartSentence3 ();
		}
	}
	void StartSentence3 (){
		sentenceShow.text = startSentence3;
		timeLeft = 2f;
		decreaseTimer = true;
		if (decreaseTimer == true && timeLeft >= 0f) 
		{
			timeLeft -= Time.deltaTime;
		}
		else if (timeLeft <= 0f) 
		{
			decreaseTimer = false;
			StartSentence4 ();
		}
	}
	void StartSentence4 (){
		sentenceShow.text = startSentence4;
		timeLeft = 2f;
		decreaseTimer = true;
		if (decreaseTimer == true && timeLeft >= 0f) 
		{
			timeLeft -= Time.deltaTime;
		}
		else if (timeLeft <= 0f) 
		{
			decreaseTimer = false;
			sentenceShow.text = "";
		}
	}

	//All the "Before and after" sentences
	//These show informative texts
	void CurOrdChoice(){
		headerText.text = "Choice";
		sentenceShow.text = curOrdChoiceSentence;
		TimeEvent ();
	}

	void CurOrdChosen(){
		headerText.text = "Chosen";
		sentenceShow.text = curOrdChosenSentence;
		TimeEvent ();
	}

	void IntPerChoice(){
		headerText.text = "Choice";
		sentenceShow.text = intPerChoiceSentence;
		TimeEvent ();
	}

	void IntPerChosen(){
		headerText.text = "Chosen";
		sentenceShow.text = intPerChosenSentence;
		TimeEvent ();
	}

	void DanSafChoice(){
		headerText.text = "Choice";
		sentenceShow.text = danSafChoiceSentence;
		TimeEvent ();
	}

	void DanSafChosen(){
		headerText.text = "Chosen";
		sentenceShow.text = danSafChoiceSentence;
		TimeEvent ();
	}

	void AnimalChoice(){
		headerText.text = "Choice";
		sentenceShow.text = animalsChoiceSentence;
		TimeEvent ();
	}
}
