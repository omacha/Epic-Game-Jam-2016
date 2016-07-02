using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 20.0f;

	public bool isDead() {
		return health <= 0.0f;
	}

	public void Damage(float dmg) {
		health -= dmg;
	}
}
