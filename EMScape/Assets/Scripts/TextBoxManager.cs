using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBoox;
	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;

	public Controller player;
	public GameObject scenarioObject;

	void Start(){
		ReadLines ();
	}

	public void ReadLines(){
		currentLine = 0;
		player = FindObjectOfType<Controller> ();

		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		} 

		if (endAtLine == 0) {

			endAtLine = textLines.Length - 1;
		}
	}

	void Update(){
		theText.text = textLines [currentLine];
		if(Input.GetKeyDown(KeyCode.Return) && textBoox.activeSelf){
			currentLine +=1;
		}

		if (currentLine >= endAtLine) {
			textBoox.SetActive (false);
			currentLine = 0;
			scenarioObject.GetComponent<PuteScenario> ().EndScenario();
		}
	}

	public void ActivateBox(){
		Debug.Log ("Activated box");
		textBoox.SetActive (true);
	}
}
