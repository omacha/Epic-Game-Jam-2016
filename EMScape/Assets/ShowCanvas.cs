using UnityEngine;
using System.Collections;

public class ShowCanvas : MonoBehaviour {

	// Use this for initialization
	bool show = false;
	int i = 0;
	void Start () {
		this.transform.GetComponent<Canvas>().enabled = show;
	}
	
	// Update is called once per frame
	void Update () {
		if (i > 0) {
			i = i-1;
		}
		if (Input.GetKey (KeyCode.E) && i<=0) {
			show = !show;
			this.transform.GetComponent<Canvas>().enabled = show;
			i = 10;
		}
	}
}
