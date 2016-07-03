using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public float damage = 3.0f;
	public float fireRate = 1.0f;

	public Collider attackTrigger;

	public AudioClip[] hitSounds;

	private float timeToFire = 0.0f;

	// Use this for initialization
	void Start () {
		attackTrigger.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Mouse0) && Time.time > timeToFire) {
			timeToFire = Time.time + 1 / fireRate;
			Attack ();
		} else {
			attackTrigger.enabled = false;
		}
	}

	public void Disable () {
		this.enabled = false;
		GameObject.FindObjectOfType<AttackTrigger> ().GetComponent<BoxCollider> ().enabled = false;
	}

	public void Enable () {
		this.enabled = true;
		GameObject.FindObjectOfType<AttackTrigger> ().GetComponent<BoxCollider> ().enabled = true;
	}

	public void Attack () {
		attackTrigger.GetComponent<AttackTrigger>().SetDamage (damage);
		if (hitSounds.Length > 0) {
			int index = (int)Mathf.Floor (Random.value * hitSounds.Length);
			AudioClip hitSound = hitSounds [index];
			attackTrigger.GetComponent<AttackTrigger> ().SetHitSound (hitSound);
		}
		attackTrigger.enabled = true;
		// animator call animation
	}
}
