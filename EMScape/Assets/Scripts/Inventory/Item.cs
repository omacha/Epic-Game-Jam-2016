using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
	// declaration

	public string itemName;
	public int itemID;
	public string itemDesc;
	public int itemPower;
	public Texture2D itemIcon;
	public ItemType itemType;

	public enum ItemType
	{
		Weapon,
		Consumable,
		Quest
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}