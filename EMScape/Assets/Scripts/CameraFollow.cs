using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
//	public GameObject floor;
	public float movementBuffer = 10.0f;
	public float borderBuffer = 2.0f;

//	private Terrain terrain;
	private GameObject cam;

	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		if (cam == null) {
			Debug.Log ("Can't find the GameObject MainCamera");
		}

		/*terrain = (Terrain) floor.GetComponent ("Terrain");
		if (terrain == null) {
			Debug.Log ("Floor has no \"Terrain\" Component.");
		}
		*/
		//UpdateCameraPos ();
	}
	
	// Update is called once per frame
	void Update () {
		//UpdateCameraPos ();
		Vector3 camPos = cam.transform.position;
		Vector3 thisPos = this.transform.position;
		camPos.x = thisPos.x;
		cam.transform.position = camPos;

	}
	/*
	private void UpdateCameraPos() {
		Vector3 terrainSize = terrain.terrainData.size;
		Vector3 playerPos = this.transform.position;
		Vector3 camPos = cam.transform.position;

		// check player movement
		if (Mathf.Abs (playerPos.x - camPos.x) > movementBuffer) {
			camPos.x = playerPos.x - Mathf.Sign (playerPos.x - camPos.x) * movementBuffer;
		}
	/*
		// check world borders
		if (camPos.x < floor.transform.position.x + borderBuffer) {
			camPos.x = floor.transform.position.x + borderBuffer;
		} else if (camPos.x > terrainSize.x - borderBuffer) {
			camPos.x = terrainSize.x - borderBuffer;
		}

		cam.transform.position = camPos;
	}*/
}
