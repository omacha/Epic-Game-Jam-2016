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
		GameObject obj = (GameObject)Instantiate (prefab, firePoint.transform.position, firePoint.transform.rotation);
		obj.GetComponent<ProjectileController> ().SetDamage (damage);

		if (hitSounds.Length > 0) {
			int index = (int)Mathf.Floor (Random.value * hitSounds.Length);
			AudioClip hitSound = hitSounds [index];
			obj.GetComponent<ProjectileController> ().SetHitSound (hitSound);
		}

		Vector3 curScale = obj.transform.localScale;
		Vector3 playerScale = GameObject.FindGameObjectWithTag("Player").transform.localScale;
		curScale.x = Mathf.Sign (playerScale.x) * Mathf.Abs (curScale.x);
		obj.transform.localScale = curScale;
	}
}
