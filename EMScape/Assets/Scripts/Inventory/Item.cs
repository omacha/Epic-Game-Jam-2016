using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item	 {
	// declaration

	public string itemName;
	public int itemID;
	public string itemDesc;
	public int itemPower;
	public Texture itemIcon;
	public ItemType itemType;
	public bool itemAquired;
	public bool itemEquiped;

	public enum ItemType
	{
		Weapon,
		Consumable,
		Quest,
		Accessory
	}


	public Item(string _name, int _id, string _desc, int _power, ItemType _type)
	{
		this.itemName = _name;
		this.itemID = _id;
		this.itemDesc = _desc;
		this.itemPower = _power;
		/*Texture tex = Resources.Load ("Assets/Sprites/Items/test.png", typeof(Texture)) as Texture;
		if (tex == null) {
			Debug.LogError ("Error on loading texture");
		} else {
			this.itemIcon = tex;
		}*/
		this.itemType = _type;
		this.itemAquired = false;
	}

	public Item()
	{
		this.itemAquired = false;
	}

}