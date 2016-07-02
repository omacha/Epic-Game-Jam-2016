using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevelCollider : MonoBehaviour {

	public int levelToLoad = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			SceneManager.LoadScene (levelToLoad);
		}
	}
}
