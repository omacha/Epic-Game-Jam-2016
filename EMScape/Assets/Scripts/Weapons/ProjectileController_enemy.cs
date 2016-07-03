using UnityEngine;
using System.Collections;

public class ProjectileController_enemy : MonoBehaviour {
	public float maxTime = 10.0f;
	public float speed = 10.0f;

	private float damage = 1.0f;
	private GameObject player;
	private float startTime = 0.0f;
	private AudioClip hitSound = null;

	// Use this for initialization
	void Start () {
		startTime = Time.time;

		speed = -speed;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (speed * Time.deltaTime, 0.0f, 0.0f));

		if (Time.time - startTime > maxTime) {
			Destroy (gameObject);
			Debug.Log ("Destroyed overaged projectile");
		}
	}

	public void SetDamage(float damage) {
		this.damage = damage;
	}

	public void SetHitSound(AudioClip audio) {
		this.hitSound = audio;
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag ("Player") && other.gameObject.GetComponent<Health> () != null) {
			other.gameObject.GetComponent<Health> ().Damage (damage);
			Debug.Log (other.gameObject.name + " has taken " + damage + " damage.");

			if (hitSound != null) {
				AudioSource.PlayClipAtPoint(hitSound, transform.position);
			}
			Destroy (gameObject);
		}
	}
}
