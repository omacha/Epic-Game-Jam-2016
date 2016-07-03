using UnityEngine;
using System.Collections;

public class RangedWeapon : MonoBehaviour {
	public float damage = 3.0f;
	public float fireRate = 1.0f;

	public AudioClip[] hitSounds;

	public GameObject prefab;
	public GameObject firePoint;

	private float timeToFire = 0.0f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Mouse0) && Time.time > timeToFire) {
			timeToFire = Time.time + 1 / fireRate;
			Attack ();
		}
	}

	public void Attack () {
		/* attack is being done in animation behavior script */
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ().SetBool ("AttackThrow", true);
	}
}
