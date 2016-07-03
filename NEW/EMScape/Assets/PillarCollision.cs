using UnityEngine;
using System.Collections;

public class PillarCollision : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			Debug.Log ("Collision");
			Destroy(GameObject.Find ("fluffyFish"));
			GameObject.Find ("ItemDatabase").GetComponent<ItemDatabase> ().itemList [10].itemAquired = true;
		}
	}
}
