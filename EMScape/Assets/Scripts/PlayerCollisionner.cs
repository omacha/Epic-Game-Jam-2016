using UnityEngine;
using System.Collections;

public class PlayerCollisionner : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			Debug.Log ("Collision");
			Scenario sce = this.transform.GetComponent<Scenario> ();
			sce.Play ();
		}
	}
}
