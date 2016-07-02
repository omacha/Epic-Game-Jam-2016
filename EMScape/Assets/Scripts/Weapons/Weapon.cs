using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float damage = 3;
	public float fireRate = 1.0f;

	public Collider attackTrigger;

	private float timeToFire = 0.0f;

	// Use this for initialization
	void Start () {
		attackTrigger.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Mouse0) && Time.time > timeToFire) {
			timeToFire = Time.time + 1 / fireRate;
			Shoot ();
		}
	}

	public void Shoot () {
		attackTrigger.enabled = true;
		// animator call animation
	}
}
