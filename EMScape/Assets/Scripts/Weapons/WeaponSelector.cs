using UnityEngine;
using System.Collections;

public class WeaponSelector : MonoBehaviour {
	private ItemDatabase db;
	private Item current;

	// Use this for initialization
	void Start () {
		db = GameObject.FindObjectOfType<ItemDatabase> ();
		if (db == null) {
			Debug.LogError ("Object has no component ItemDatabase");
		}
	}
	
	// Update is called once per frame
	void Update () {
		Item e = null;
		foreach (Item i in db.itemList) {
			if (i.itemEquiped) {
				e = i;
			}
		}

		if (e != current) {
			GetComponent<Weapon> ().enabled = false;
			GetComponent<RangedWeapon> ().enabled = false;

			current = e;

			if (e.itemName == "Frying pan") {
				Debug.Log ("Frying pan selected as weapon");
				GetComponent<Weapon> ().enabled = true;
			} else if (e.itemName == "Syringe") {
				Debug.Log ("Syringe selected as weapon");
				GetComponent<RangedWeapon> ().enabled = true;
			}
		}
	}
}
