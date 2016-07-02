using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public float velocityUpDown = 10.0f;
	public float velocityLeftRight = 10.0f;
	public float borderPadding = 1.0f;

	public GameObject floor;
	private Terrain terrain;

	private float terrainXMin;
	private float terrainXMax;
	private float terrainZMin;
	private float terrainZMax;

	// Use this for initialization
	void Start () {
		if (floor != null) {
			terrain = (Terrain)floor.GetComponent ("Terrain");
		}
		if (terrain == null) {
			Debug.Log ("Floor has no \"Terrain\" Component.");
		}else{
			Vector3 terrainPosition = terrain.transform.position;
			Vector3 terrainSize = terrain.terrainData.size;

			terrainXMin = terrainPosition.x + borderPadding;
			terrainXMax = terrainPosition.x + terrainSize.x - borderPadding;

			terrainZMin = -terrainSize.z / 2 + borderPadding;
			terrainZMax = terrainSize.z / 2 - borderPadding;

		}
	}
	
	// Update is called once per frame
	void Update () {
		float upMvmt = Input.GetAxis ("Horizontal");
		float sideMvmt = Input.GetAxis ("Vertical");

		this.transform.Translate (new Vector3 (velocityUpDown * upMvmt * Time.deltaTime, 0.0f,  0.0f));
		this.transform.Translate (new Vector3 (0.0f, 0.0f, velocityLeftRight * sideMvmt * Time.deltaTime));

		// check for border collisions
		Vector3 playerPos = this.transform.position;

		if (playerPos.x < terrainXMin) {
			playerPos.x = terrainXMin;
		} else if (playerPos.x > terrainXMax) {
			playerPos.x = terrainXMax;
		}

		if (playerPos.z < terrainZMin) {
			playerPos.z = terrainZMin;
		} else if (playerPos.z > terrainZMax) {
			playerPos.z = terrainZMax;
		}

		this.transform.position = playerPos;
	}
}
