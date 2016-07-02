using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryOutdated : MonoBehaviour {

	public int slotsX, slotsY;
	public List<Item> inventory = new List<Item> ();
	public List<Item> slots = new List<Item> ();
	private ItemDatabase database;
	private bool showInventory = false;
	private GameObject overlay;
	private List<GameObject> glowList = new List<GameObject>();
	private int currentWeapon;
	private int currentConsumable;
	private int currentQuest;
	private int currentAccessory;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < (slotsX * slotsY); i++) {
			slots.Add (new Item ());
			inventory.Add(new Item ());
		}
		database = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemDatabase>();
		if (database == null) {
			Debug.LogError ("DatabaseNULL");
		}
		inventory [0] = database.itemList [0];
		inventory [6] = database.itemList [1];
		inventory [10] = database.itemList [2];
		inventory [11] = database.itemList [3];

		inventory [0].itemAquired = true;
		inventory [6].itemAquired = true;
		inventory [10].itemAquired = true;
		inventory [11].itemAquired = true;

		overlay = GameObject.Find ("InventoryOverlay");
		for (int i = 0; i < (slotsX * slotsY); i++) {
			glowList.Add(GameObject.Find ("selected-spot (" + i.ToString () + ")"));
			glowList [i].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Inventory")){
			showInventory = !showInventory;
		}

	}

	// On gui event
	void OnGUI()
	{
		overlay.SetActive (showInventory);
		if (showInventory) {
			DrawInventory ();
		}	
	}

	void DrawInventory(){
		GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.MiddleCenter; 

		int i = 0;
		for (int y = 0; y < slotsY; y++) {
			for (int x = 0; x < slotsX; x++) {
				Rect cellRect = new Rect (100 + 100 * x, 100 + 100 * y, 100, 100);
				//GUI.Box (cellRect, (y*10 + x).ToString());

				slots [i] = inventory [i];

				if (slots [i].itemName != null && slots[i].itemAquired) {
					GUI.Label (new Rect (100 + 100 * x, 100 + 100 * y, 100, 100), slots[i].itemIcon);
					if (cellRect.Contains (Event.current.mousePosition)){
						GUI.Box (new Rect (Event.current.mousePosition.x+100, Event.current.mousePosition.y+100, 200, 100),showTooltip(slots[i]));
						if (Event.current.button == 0 && Event.current.type == EventType.mouseDown) {
							print ("banane");
							if (i == 0 || i== 1 || i==4 || i==5) {
								slots [currentWeapon].itemEquiped = false;
								glowList [currentWeapon].SetActive (false);
								currentWeapon = i;
								slots [i].itemEquiped = true;
								glowList [i].SetActive (true);
							} else if (i == 2 || i == 3 || i== 6 || i==7){
								slots [currentConsumable].itemEquiped = false;
								glowList [currentConsumable].SetActive (false);
								currentConsumable = i;
								slots [i].itemEquiped = true;
								glowList [i].SetActive (true);
							}else if(i ==8 || i == 9 || i == 12 || i == 13){
								slots [currentQuest].itemEquiped = false;
								glowList [currentQuest].SetActive (false);
								currentQuest = i;
								slots [i].itemEquiped = true;
								glowList [i].SetActive (true);
							}else{
								slots [currentAccessory].itemEquiped = false;
								glowList [currentAccessory].SetActive (false);
								currentAccessory = i;
								slots [i].itemEquiped = true;
								glowList [i].SetActive (true);
							}
						}
					}
				} 

				i++;
			}
		}
	}

	void AquireObject(Item item , bool isAquired){
		item.itemAquired = isAquired;
	}

	string showTooltip(Item item){
		string r = "";
		r += item.itemDesc;
		return r;
	}
}
