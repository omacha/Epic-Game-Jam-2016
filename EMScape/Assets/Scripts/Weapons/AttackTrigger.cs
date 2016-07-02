using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	private float dmg = 2;

	void OnTriggerEnter(Collider col) {
		if (!col.isTrigger && col.CompareTag("Enemy") && col.GetComponent<Health>() != null) {
			col.SendMessageUpwards ("Damage", dmg);
			this.enabled = false;
			Debug.Log (col.gameObject.name + " has received " + dmg + " damage!");
		}
	}

	public void setDamage(float dmg) {
		this.dmg = dmg;
	}

}
