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


	List<GameObject> we = new List<GameObject> ();
	List<GameObject> co = new List<GameObject> ();
	List<GameObject> ac = new List<GameObject> ();
	List<GameObject> qu = new List<GameObject> ();

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

		GameObject weapons = this.transform.GetChild (1).gameObject;
		GameObject conso = this.transform.GetChild (2).gameObject;
		GameObject acc = this.transform.GetChild (3).gameObject;
		GameObject quests = this.transform.GetChild (4).gameObject;

		for (int i = 0; i < 4; i++) {
			we.Add (weapons.transform.GetChild (i).gameObject);
			co.Add (conso.transform.GetChild (i).gameObject);
			ac.Add (acc.transform.GetChild (i).gameObject);
			qu.Add (quests.transform.GetChild (i).gameObject);
		}
		UpdateCanvas (we.ToArray (), co.ToArray (), ac.ToArray (), qu.ToArray ());

	}
	
	// Update is called once per frame
	void UpdateCanvas(GameObject[] w, GameObject[] c, GameObject[] a, GameObject[] q) {
		for (int i = 0; i < 4; i++) {
			UpdateImage (w [i]);
			UpdateImage (c [i]);
			UpdateImage (a [i]);
			UpdateImage (q [i]);
		}
		
	}


	void UpdateImage (GameObject g){
		Image image = g.GetComponent<Image> ();
		Color color = image.color;
		InventoryLinker IL = g.GetComponent<InventoryLinker> ();
		ItemDatabase itdata = IL.itDatabase;
		int index = IL.itIndex;

		color.a = 0.0f;
		image.color = color;

		if (itdata.itemList [index].itemAquired) {
			color.a = 0.5f;
			image.color = color;
		}
		if (itdata.itemList [index].itemEquiped) {
			color.a = 1.0f;
			image.color = color;
		}
	}

	public void selectImage(GameObject thisgo){
		Debug.Log ("Cliked : " + thisgo.ToString ());

		InventoryLinker inLink =  thisgo.GetComponent<InventoryLinker> ();
		Item it = inLink.itDatabase.itemList [inLink.itIndex];


		if (it.itemAquired == false || it == null) {

			Color color = thisgo.GetComponent<Image> ().color;
			color.a = 0.0f;
			thisgo.GetComponent<Image> ().color = color;
		}

		if (it.itemAquired) {
			Debug.Log ("Cliked : " + thisgo.ToString ());

			SetAllImageFalseInGroup (thisgo);

			it.itemEquiped = true;	
		}
	

		UpdateCanvas (we.ToArray (), co.ToArray (), ac.ToArray (), qu.ToArray ());
	}

	public void SetAllImageFalseInGroup (GameObject go){
		GameObject group = go.transform.parent.gameObject;
		for (int i = 0; i < group.transform.childCount; i++) {
			InventoryLinker IL = group.transform.GetChild (i).GetComponent<InventoryLinker> ();
			IL.itDatabase.itemList [IL.itIndex].itemEquiped = false;

		}
		
	}

	public void SetObjectUnequiped(GameObject g){
		Image image = g.GetComponent<Image> ();
		Color color = image.color;
		InventoryLinker IL = g.GetComponent<InventoryLinker> ();
		ItemDatabase itdata = IL.itDatabase;
		int index = IL.itIndex;

		itdata.itemList [index].itemEquiped = false;
	}
}
