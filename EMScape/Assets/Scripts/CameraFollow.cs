using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	GameObject cam;
	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		if (cam == null) {
			Debug.Log ("Can't find the main Camera");
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = cam.transform.position;
		Vector3 thisPos = this.transform.position;
		pos.x = thisPos.x;
		cam.transform.position = pos;
	}
}
