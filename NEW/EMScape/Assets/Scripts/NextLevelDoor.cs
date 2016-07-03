using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevelDoor : MonoBehaviour {

	int thisLevel = 1;
	int nextLevel = 1;
	int distance = 10;
	GameObject player;
	// Use this for initialization
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		if (player == null) {
			Debug.LogError ("Impossible to find Player");
		}
	}
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = player.transform.position;
		Vector3 thisPos = this.transform.position;
		if (Vector3.Distance (playerPos, thisPos) < distance) {
			SceneManager.LoadScene (nextLevel);
		}
	}
}
