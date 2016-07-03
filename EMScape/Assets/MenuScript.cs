using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	int sceneToLoad;
	public void LoadLevel(int Level){
		sceneToLoad = Level;
		StartCoroutine ("EndGame");
	}

	IEnumerator EndGame(){
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		float fadeTime = this.GetComponent<Fading>().BeginFade(1);

		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel (sceneToLoad);
	}
}
