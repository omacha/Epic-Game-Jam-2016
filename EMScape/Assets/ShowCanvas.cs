using UnityEngine;
using System.Collections;

public class ShowCanvas : MonoBehaviour {

	// Use this for initialization
	bool show = false;
	int i = 0;
	void Start () {
		this.transform.GetChild (0).gameObject.SetActive (false);
		this.transform.GetChild (1).gameObject.SetActive (false);
		this.transform.GetChild (2).gameObject.SetActive (false);
		this.transform.GetChild (3).gameObject.SetActive (false);
		this.transform.GetChild (4).gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (i > 0) {
			i = i-1;
		}
		if (Input.GetKey (KeyCode.E) && i<=0) {
			show = !show;
			this.transform.GetChild (0).gameObject.SetActive (show);
			this.transform.GetChild (1).gameObject.SetActive (show);
			this.transform.GetChild (2).gameObject.SetActive (show);
			this.transform.GetChild (3).gameObject.SetActive (show);
			this.transform.GetChild (4).gameObject.SetActive (show);
			i = 10;
		}
	}
}
