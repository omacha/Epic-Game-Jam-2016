using UnityEngine;
using System.Collections;

public class FreeGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Backup> ().Save ();
	}

}
