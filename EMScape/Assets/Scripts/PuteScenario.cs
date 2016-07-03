using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PuteScenario : Scenario{

	public bool finishedScenario = false;
	public TextAsset beforeQuestTxt;
	public TextAsset endQuestTxt;
	public int indexOfQuestObject;
	public GameObject itemDatabase;
	public GameObject BoxManager;

	public int sceneToLoad;

	public override void Play(){
		Debug.Log ("Play puteScenario");

		if (!finishedScenario) {
			ItemDatabase database = itemDatabase.GetComponent<ItemDatabase> ();
			//We already have the pill Box
			if (database.itemList [indexOfQuestObject].itemAquired) {
				if (endQuestTxt != null) {
					BoxManager.GetComponent<TextBoxManager> ().textFile = endQuestTxt;
					BoxManager.GetComponent<TextBoxManager> ().ReadLines ();
					BoxManager.GetComponent<TextBoxManager> ().ActivateBox ();
					finishedScenario = true;
				} else {
					Debug.LogError ("Impossible to Load endQuestText");
				}

			} else { //Quest is not finished
				if (beforeQuestTxt != null) {
					BoxManager.GetComponent<TextBoxManager> ().textFile = beforeQuestTxt;
					BoxManager.GetComponent<TextBoxManager> ().ActivateBox ();
				}
			}
		}
	}

	public override void EndScenario(){
		if (finishedScenario) {
			Debug.Log ("Scenario Has ended");
			StartCoroutine ("EndGame");
		} else {
			Debug.Log ("Scenario not ended");
		}
	}


	IEnumerator EndGame(){
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		float fadeTime = GameObject.Find("GameManager").GetComponent<Fading>().BeginFade(1);

		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene (sceneToLoad);
	}
}
