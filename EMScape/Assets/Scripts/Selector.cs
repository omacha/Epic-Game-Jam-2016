using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Selector : MonoBehaviour {

	List<GameObject> itemImageList = new List<GameObject>();
	public GameObject defaultSelectedWeapon;
	public GameObject defaultSelectedConsomable;
	public GameObject defaultSelectedQuests;
	public GameObject defaultSelectedAccessories;

	// Use this for initialization
	void Start () {
		ItemDatabase database = defaultSelectedWeapon.GetComponent<InventoryLinker> ().itDatabase;
		int defaultW = defaultSelectedWeapon.GetComponent<InventoryLinker> ().itIndex;	
		int defaultC = defaultSelectedConsomable.GetComponent<InventoryLinker> ().itIndex;
		int defaultQ = defaultSelectedQuests.GetComponent<InventoryLinker> ().itIndex;
		int defaultA = defaultSelectedAccessories.GetComponent<InventoryLinker> ().itIndex;

		for (int i = 0; i < database.itemList.Count; i++) {
			database.itemList [i].itemEquiped = false;
		}

		//Set default selected objects 
		database.itemList [defaultW].itemEquiped = true;
		database.itemList [defaultQ].itemEquiped = true;
		database.itemList [defaultC].itemEquiped = true;
		database.itemList [defaultA].itemEquiped = true;


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void selectImage(GameObject thisgo){
		InventoryLinker inLink =  thisgo.GetComponent<InventoryLinker> ();
		Item it = inLink.itDatabase.itemList [inLink.itIndex];
		if (it.itemAquired == false || it == null) {

			Color color = thisgo.GetComponent<Image> ().color;
			color.a = 0.0f;
			thisgo.GetComponent<Image> ().color = color;
		}
		if (it.itemAquired) {

			Debug.Log ("Cliked : " + thisgo.ToString ());
	
			Color color = thisgo.GetComponent<Image> ().color;
			color.a = 0.5f;
			thisgo.GetComponent<Image> ().color = color;
			it.itemEquiped = true;
			List<GameObject> otherGroupObjects = new List<GameObject> ();

			GameObject Parent = thisgo.transform.parent.gameObject;

			it.itemEquiped = true;	


			for (int i = 0; i < Parent.transform.childCount; i++) {
				GameObject otherObject = Parent.transform.GetChild (i).gameObject;
				InventoryLinker IL = otherObject.GetComponent<InventoryLinker> ();
				Item item = IL.itDatabase.itemList [IL.itIndex];

				Debug.Log(item.ToString());

				//SET COLOR AS FULL
				Color c = otherObject.GetComponent<Image> ().color;
				c.a = 0.5f;
				otherObject.GetComponent<Image> ().color = c;
			}

			it.itemEquiped = true;	
			Color col = thisgo.GetComponent<Image> ().color;
			col.a = 1.0f;
			thisgo.GetComponent<Image> ().color = col;


		} else {
			thisgo.SetActive (false);
		}
	
	}
}
