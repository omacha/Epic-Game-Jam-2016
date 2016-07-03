using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public GameObject deathPrefab = null;
	public GameObject element = null;
	public float health = 20.0f;

	public bool isDead() {
		return health <= 0.0f;
	}

	public void Damage(float dmg) {
		health -= dmg;

		if (isDead()) {
			if (deathPrefab != null) {
				Instantiate (deathPrefab, element.transform.position, element.transform.rotation);
			}
			Destroy (gameObject);
		}
	}
}
