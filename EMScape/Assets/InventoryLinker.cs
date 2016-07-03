using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InventoryLinker : MonoBehaviour {
	public ItemDatabase itDatabase;
	public int itIndex;

	void Start(){
		Image image = this.transform.GetComponent<Image> ();
		Item it = itDatabase.itemList [itIndex];
		if (it!=null && it.itemIcon != null && image != null) {
			image.sprite = it.itemIcon;
		}
	}

	void Update(){
		Image image = this.transform.GetComponent<Image> ();
		if (image == null) {
			Debug.LogError ("no image in parent");
		}
		Item it = itDatabase.itemList [itIndex];
		if (it.itemIcon != null) {
			image.sprite = it.itemIcon;
		}
	}
}
