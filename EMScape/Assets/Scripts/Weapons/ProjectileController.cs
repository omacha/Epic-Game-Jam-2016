using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
	public float maxTime = 10.0f;
	public float speed = 20.0f;

	private float damage;
	private GameObject player;
	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;

		player = GameObject.FindGameObjectWithTag ("Player");
		if (player == null) {
			Debug.LogError ("Player could not be found!");
		}
		if (player.GetComponent<Transform> ().localScale.x < 0) {
			speed = -speed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (speed * Time.deltaTime, 0.0f, 0.0f));

		if (Time.time - startTime > maxTime) {
			Destroy (gameObject);
		}
	}

	public void SetDamage(float damage) {
		this.damage = damage;
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Enemy")) {
			other.GetComponent<Health> ().Damage (damage);
			Destroy (gameObject);
		}
	}
}
