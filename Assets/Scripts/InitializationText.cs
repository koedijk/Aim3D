using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InitializationText : MonoBehaviour {

	public Text sentenceEmpty;
    public Text HeaderText;
	void Start () {

		//This makes sure no UI text is shown at the start
		sentenceEmpty.text = "";
        HeaderText.text = "";
	}  
}
