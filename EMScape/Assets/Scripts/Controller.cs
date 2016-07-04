using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public float velocityUpDown = 10.0f;
	public float velocityLeftRight = 10.0f;
	public float borderPadding = 1.0f;

	public AudioClip[] stepSounds = new AudioClip[0];
	public float stepRate = 0.5f;
	private float timeToStep = 0.0f;
	private int curFootStep = 0;

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
		} else {
			Vector3 terrainPosition = terrain.transform.position;
			Vector3 terrainSize = terrain.terrainData.size;

			terrainXMin = terrainPosition.x + borderPadding;
			terrainXMax = terrainPosition.x + terrainSize.x - borderPadding;

		terrainZMin = terrainPosition.z + borderPadding;
		terrainZMax = terrainPosition.z + terrainSize.z - borderPadding;

		}
	}
	
	// Update is called once per frame
	void Update () {
		float upMvmt = Input.GetAxis ("Vertical");
		float sideMvmt = Input.GetAxis ("Horizontal");

		float depthTranslation = velocityUpDown * upMvmt * Time.deltaTime;
		float sideTranslation  = velocityLeftRight * sideMvmt * Time.deltaTime;

		this.transform.Translate (new Vector3 (sideTranslation, 0.0f,  0.0f));
		this.transform.Translate (new Vector3 (0.0f, 0.0f, depthTranslation));

		if (sideTranslation < 0.0f) {
			Vector3 curScale = this.transform.localScale;
			curScale.x = -Mathf.Abs (curScale.x);
			this.transform.localScale = curScale;
		} else if (sideTranslation > 0.0f) {
			Vector3 curScale = this.transform.localScale;
			curScale.x = Mathf.Abs (curScale.x);
			this.transform.localScale = curScale;
		}

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

		if (sideTranslation * sideTranslation + depthTranslation * depthTranslation > 0.0f) {
			GetComponent<Animator> ().SetBool ("Walking", true);
			if (stepSounds.Length > 0 && Time.time > timeToStep) {
				timeToStep = Time.time + 1 / stepRate;
				AudioSource.PlayClipAtPoint (stepSounds [curFootStep++ % stepSounds.Length], transform.position);
			}
		} else {
			GetComponent<Animator> ().SetBool ("Walking", false);
		}
	}
}
