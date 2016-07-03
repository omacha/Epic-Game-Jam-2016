using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	public float duration = 5.0f;
	public int sceneToLoad = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		duration = duration - Time.deltaTime;

		if (duration <= 0) {
			StartCoroutine ("EndGame");
		}
	}


	IEnumerator EndGame(){
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		float fadeTime = this.GetComponent<Fading>().BeginFade(1);

		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel (sceneToLoad);
	}
}
