using UnityEngine;
using System.Collections;

public class RangedWeapon : MonoBehaviour {
	public float damage = 3.0f;
	public float fireRate = 1.0f;

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
		if (gameObject.GetComponent<Rigidbody> ().velocity.x > 0.0f) {
			Vector3 pos = gameObject.transform.position;
			pos.x = Mathf.Abs (pos.x);
			gameObject.transform.position = pos;
		} else if (gameObject.GetComponent<Rigidbody> ().velocity.x < 0.0f) {
			Vector3 pos = gameObject.transform.position;
			pos.x = -Mathf.Abs (pos.x);
			gameObject.transform.position = pos;
		}

		prefab.GetComponent<ProjectileController> ().SetDamage (damage);
		Instantiate (prefab, firePoint.transform.position, firePoint.transform.rotation);
	}
}
