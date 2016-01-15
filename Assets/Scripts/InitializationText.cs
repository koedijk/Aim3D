using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InitializationText : MonoBehaviour {

	public Text sentenceEmpty;

	void Start () {

		//This makes sure no UI text is shown at the start
		sentenceEmpty.text = "";
	}
}
