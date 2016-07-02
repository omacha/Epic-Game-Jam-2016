using UnityEngine;
using System.Collections;

public class CreditsScroll : MonoBehaviour {
	public float endingPosition = -50.0f;
	public float speed = 1.0f;

	private GameObject cam;

	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		if (cam == null) {
			Debug.Log ("Couldn't find main camera.");
		}
	}
	
	// Update is called once per frame
	void Update () {
		cam.transform.Translate (new Vector3 (0, -Time.deltaTime * speed, 0));

		if (cam.transform.position.y < endingPosition) {
			// Switch Scene here

		}
	}
}
