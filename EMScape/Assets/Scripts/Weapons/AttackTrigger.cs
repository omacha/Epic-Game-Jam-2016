using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	private float dmg = 2;
	private AudioClip hitSound = null;

	void OnTriggerEnter(Collider col) {
		if (!col.isTrigger && col.CompareTag("Enemy") && col.GetComponent<Health>() != null) {
			col.SendMessageUpwards ("Damage", dmg);
			if (hitSound != null) {
				AudioSource.PlayClipAtPoint (hitSound, transform.position);
			}
			GetComponent<BoxCollider> ().enabled = false;
			Debug.Log (col.gameObject.name + " has received " + dmg + " damage!");
		}
	}

	public void SetDamage(float dmg) {
		this.dmg = dmg;
	}

	public void SetHitSound(AudioClip audio) {
		hitSound = audio;
	}

}
