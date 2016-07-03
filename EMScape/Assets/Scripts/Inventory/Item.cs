using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item	 {
	// declaration

	public string itemName;
	public int itemID;
	public string itemDesc;
	public int itemPower;
	public Sprite itemIcon;
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
		this.itemType = _type;
		this.itemAquired = false;
	}

	public Item()
	{
		this.itemAquired = false;
	}

	public override string ToString(){
		string s = itemName + " " + itemID + " Acquired = " + itemAquired + " Equiped = " + itemEquiped;
		return s;
	}
}