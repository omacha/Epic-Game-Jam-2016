using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float velocityUpDown = 0.8f;
	public float velocityLeftRight = 0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.DownArrow)) {
			this.transform.Translate (new Vector3 (0.0f, 0.0f, -1*velocityUpDown));
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			this.transform.Translate (new Vector3 (0.0f, 0.0f, 1*velocityUpDown));
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.Translate (new Vector3 (1*velocityLeftRight, 0.0f, 0.0f));
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.Translate (new Vector3 (-1*velocityLeftRight, 0.0f, 0.0f));
		}
		else{
			this.transform.Translate(new Vector3 (0,0,0));
		}
	}
}
