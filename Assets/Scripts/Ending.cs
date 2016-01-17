using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Ending : MonoBehaviour {

	private GameObject player;
    private GameObject PlayerCamera;
	private Vector3 playerPosY;
	private int rotateCount;
	private int heightCount;

	//Phase controle, This is so the ending can run properly and in order.(Ik had het anders kunnen doen door bijv 1 int ipv 5 bools te kunnen gebruiken..)
	private bool endPhase1; //Timer Phase
	private bool endPhase2; //Rotate Phase
	private bool endPhase3; //Sentence Check Phase
	private bool endPhase4; //Height Phase
	private bool endPhase5; //Sentence 1 Show Phase
	private bool endPhase6; //Sentence 2 Show Phase
	private bool endPhase7; //Sentence 3 Show Phase
	private bool endPhase8; //Sentence 4 Show Phase
	private bool endPhase9; //Thank you for playing sentence

	//This is the Canvas Text where all sentences will be shown.
	public Text sentenceShow;

	//Timer(Which is used at the start of the ending(to move the player to the correct spot)
	//And to show all sentences in order(2 seconds)
	float timeLeft = 2f;
	private bool decreaseTimer;
	private List<string> sentenceList;

	//These booleans get activated once the player passes through a checkpoint. These dictate which sentences will be shown at the end of the game.
	public bool curiositySwitch;
	public bool orderSwitch;

	public bool perceptionSwitch;
	public bool intelligenceSwitch;

	public bool dangerSwitch;
	public bool safetySwitch;

	public bool bearSwitch;
	public bool eagleSwitch;
	public bool rabbitSwitch;

	//These are the available sentences which can be shown to the player.

	//Choice 1
	private string curiositySentence = ("You like to stray off, and seek your own way.");
	private string orderSentence = ("You like to stay focused and follow the path in front of you.");
	//Choice 2
	private string perceptionSentence = ("Even though not all paths are shown, you search for every available one.");
	private string intelligenceSentence = ("You make use of the tools given to you to continue on.");
	//Choice 3
	private string dangerSentence = ("You approach danger with the knowledge that you'll learn.");
	private string safetySentence = ("You stay close to safety, while still facing danger.");
	//Choice 4
	private string bearSentence = ("You face challenges head on, and will conquer");
	private string eagleSentence = ("No matter what, you always keep moving towards your goal, without delay.");
	private string rabbitSentence = ("You are capable of changing your ways to accomplish your goal.");

	//Timer(Which is used at the start of the ending(to move the player to the correct spot)
	//And to show all sentences in order(2 seconds)
	void resetTimer(){
		decreaseTimer = true;
		timeLeft = 4f;
	}
	//Init
	void Start () {
		rotateCount = 0;
		heightCount = 0;
        player = GameObject.Find("Player");
        PlayerCamera = GameObject.Find("Camera");
	}
	//Phase activation, so the ending will run properly.
	void Update () {
		if (endPhase1 == true) {
			EndPhase1 ();
		} else if (endPhase2 == true) {
			EndPhase2 ();
		} else if (endPhase3 == true) {
			EndPhase3 ();
		} else if (endPhase4 == true) {
			EndPhase4 ();
		} else if (endPhase5 == true) {
			EndPhase5 ();
		}else if (endPhase6 == true) {
			EndPhase6 ();
		}else if (endPhase7 == true) {
			EndPhase7 ();
		}else if (endPhase8 == true) {
			EndPhase8 ();
		}else if (endPhase9 == true) {
			EndPhase9 ();
		}

	}

	//This will activate the ending of the game.
	void OnTriggerEnter(Collider other)
	{

        if (other.tag == "Player")
		{       
            Debug.Log(" Starting Ending");
            endPhase1 = true;
            decreaseTimer = true;
            timeLeft = 2f;
            Debug.Log(" Start Phase 1");
		}
	}

	//End Phase timer.(This makes sure the player is in the correct spot, and removes the player's control.)
	void EndPhase1(){
		Destroy(player.GetComponent ("PlayerMovement"));
        Destroy(PlayerCamera.GetComponent("CameraFollow"));
		player.transform.position = new Vector3 (50.5f, 386, -92);
		playerPosY = player.transform.position;
		playerPosY.y = 386f;

		if (decreaseTimer == true && timeLeft >= 0f) 
		{
			timeLeft -= Time.deltaTime;
		}
		else if (timeLeft <= 0f) 
		{
			decreaseTimer = false;
			endPhase1 = false;
			endPhase2 = true;
			Debug.Log (" Start Phase 2");
		}
	}
		
	//End Phase Rotate(Camera rotation)
	void EndPhase2(){
		if (rotateCount != 285) {
			player.transform.Rotate (-0.3f, 0, 0);
			rotateCount++;
			Debug.Log (player.transform.rotation);
			//Debug.Log (rotateCount);

			if (rotateCount == 285 || rotateCount >= 285) 
			{
				endPhase3 = true;
				endPhase2 = false;
				Debug.Log (" Start Phase 3");
			}
		}
	}
	// Sentence Check(Checks which sentences should be added to the "SentenceList" which will be shown later"
	void EndPhase3(){
		sentenceList = new List<string> ();

		//Sentence Switches/Bools
		//Choice 1
		if (curiositySwitch == true) {
			sentenceList.Add (curiositySentence);
			Debug.Log (" Curiosity added!");
		} else if (orderSwitch == true) {
			sentenceList.Add (orderSentence);
			Debug.Log (" Order added!");
		} 
		//Choice 2
		if (perceptionSwitch == true) {
			sentenceList.Add (perceptionSentence);
			Debug.Log (" Perception added!");
		} else if (intelligenceSwitch == true) {
			sentenceList.Add (intelligenceSentence);
			Debug.Log (" Intelligence added!");
		}
		//Choice 3
		if (dangerSwitch == true) {
			sentenceList.Add (dangerSentence);
			Debug.Log (" Danger added!");
		} else if (safetySwitch == true) {
			sentenceList.Add (safetySentence);
			Debug.Log (" Safety added!");
		}
		//Choice 4
		if (bearSwitch == true) {
			sentenceList.Add (bearSentence);
			Debug.Log (" Bear added!");
		} else if (eagleSwitch == true) {
			sentenceList.Add (eagleSentence);
			Debug.Log (" Eagle added!");
		} else if (rabbitSwitch == true) {
			sentenceList.Add (rabbitSentence);
			Debug.Log (" Rabbit added!");
		}
		Debug.Log (sentenceList.Count + " DL SentenceList Count");
		for (int i = 0; i < sentenceList.Count; i++) {
			Debug.Log(sentenceList[i] + " DL SentenceList[i]");
		}
        if (sentenceList.Count == 4)
        {
            endPhase4 = true;
            endPhase3 = false;
        }
	}

	//End Phase Height(moves player to the "eye of the storm")
	void EndPhase4(){
		if(heightCount !=100){
			//Debug.Log (playerPosY + " PlayerPosY");
			playerPosY.y += 0.2f;
			player.transform.position = playerPosY;
			heightCount++;
			//Debug.Log(heightCount);

			if(heightCount == 100 || heightCount >= 100){

				endPhase5 = true;
				endPhase4 = false;
				Debug.Log ("Start Phase 5 ");
				resetTimer ();
			}
		}
	}

	//End Phase Text(Shows 1st sentence)
	void EndPhase5(){
		if(sentenceList[0] == curiositySentence){
			sentenceShow.color = Color.yellow;
		}else{sentenceShow.color = Color.magenta;}
		sentenceShow.text = sentenceList [0];

		if (decreaseTimer == true && timeLeft >= 0f) 
		{
			timeLeft -= Time.deltaTime;
		}else if (timeLeft <= 0f) 
		{
			decreaseTimer = false;
			endPhase6 = true;
			endPhase5 = false;
			Debug.Log ("Start Phase 6 ");
			resetTimer ();
		}
	}

	//Show 2nd sentence
	void EndPhase6(){
		if(sentenceList[1] == perceptionSentence){
		sentenceShow.color = Color.gray;
		}else{sentenceShow.color = Color.magenta;}

		sentenceShow.text = sentenceList [1];
		if (decreaseTimer == true && timeLeft >= 0f) 
		{
			timeLeft -= Time.deltaTime;
		}else if (timeLeft <= 0f) 
		{
			decreaseTimer = false;
			endPhase7 = true;
			endPhase6 = false;
			Debug.Log ("Start Phase 7 ");
			resetTimer ();
		}
	}
	//Show 3rd sentence
	void EndPhase7(){
		if(sentenceList[2] == dangerSentence){
			sentenceShow.color = Color.red;
		}else{sentenceShow.color = Color.white;}

		sentenceShow.text = sentenceList [2];
		if (decreaseTimer == true && timeLeft >= 0f) 
		{
			timeLeft -= Time.deltaTime;
		}else if (timeLeft <= 0f) 
		{
			decreaseTimer = false;
			endPhase8 = true;
			endPhase7 = false;
			Debug.Log ("Start Phase 8 ");
			resetTimer ();
		}
	}
	//Show 4th sentence
	void EndPhase8(){
		if(sentenceList[3] == bearSentence){
			sentenceShow.color = Color.red;
		}else if(sentenceList[3] == eagleSentence){
			sentenceShow.color = Color.blue;
		}else if(sentenceList[3] == rabbitSentence){
			sentenceShow.color = Color.green;
		}
		sentenceShow.text = sentenceList [3];
		if (decreaseTimer == true && timeLeft >= 0f) 
		{
			timeLeft -= Time.deltaTime;
		}else if (timeLeft <= 0f) 
		{
			decreaseTimer = false;
			endPhase9 = true;
			endPhase8 = false;
			Debug.Log ("Start Phase 9 ");
			resetTimer ();
		}
	}
	//Show Thank you text
	void EndPhase9(){
		sentenceShow.color = Color.green;
		sentenceShow.text = "Thank you for playing!";
	}
}
