using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Backup : MonoBehaviour {

	public string pathAcquired;
	public string pathEquiped;

	ItemDatabase itemDatabase;
	string[] textLines;
	string[] acquired;
	string[] equiped;

	void Start(){

		itemDatabase = GameObject.Find ("ItemDatabase").GetComponent<ItemDatabase> ();
		if (File.Exists (pathAcquired)) {
			Debug.Log (pathAcquired + "already exists");
		} else {
			var sr = File.CreateText (pathAcquired);
		}

		if (File.Exists (pathEquiped)) {
			Debug.Log (pathEquiped + "already exists");
		} else {
			var sr = File.CreateText (pathEquiped);
		}
	}

	public void Save(){

		itemDatabase = GameObject.Find ("ItemDatabase").GetComponent<ItemDatabase> ();
		while (File.Exists (pathAcquired)) {
			File.Delete (pathAcquired);
		}
		while (File.Exists (pathEquiped)) {
			File.Delete (pathEquiped);
		}
		var sa = File.Create (pathAcquired);
		var se = File.Create (pathEquiped);
		sa.Close ();
		se.Close ();

		if(File.Exists(pathAcquired) && File.Exists(pathEquiped)){
			Debug.Log("Files created");
		}


		Debug.Log ("Saving...");
		string a = "";
		string e = "";
		for (int i = 0; i < itemDatabase.itemList.Count; i++) {
			if (itemDatabase.itemList [i].itemAquired) {
				a += i+"\n";
			}
			if (itemDatabase.itemList [i].itemEquiped) {
				e += i+"\n";
			}
		}
	
		//File.WriteAllText (pathAcquired, a);
		using (StreamWriter writer = new StreamWriter (pathAcquired)) {
			writer.WriteLine (a);
		}
		using (StreamWriter writer = new StreamWriter (pathEquiped)) {
			writer.WriteLine (e);
		}
		//File.WriteAllText (pathAcquired ,e);

		Debug.Log("Acquired :"+a);
		Debug.Log("Equiped :"+e);

		sa.Close ();
		se.Close ();
	}

	public void Load(){

		itemDatabase = GameObject.Find ("ItemDatabase").GetComponent<ItemDatabase> ();
		Debug.Log ("Loading...");
		if (File.Exists (pathAcquired)) {
			acquired = File.ReadAllLines (pathAcquired);
		}
		if (File.Exists (pathEquiped)) {
			equiped = File.ReadAllLines (pathEquiped);
		}
		Debug.Log ("acquired"+ acquired.ToString());
		Debug.Log ("equiped" + equiped.ToString());

		for (int i = 0; i < acquired.Length-1; i++) {
			Debug.Log ("set acquired : " + acquired [i]);
			itemDatabase.itemList[int.Parse(acquired [i])].itemAquired = true;
		}
		for (int i = 0; i < equiped.Length-1; i++) {
			Debug.Log ("set equiped : " + equiped [i]);
			itemDatabase.itemList [int.Parse(equiped [i])].itemEquiped = true;
		}
	}
}
