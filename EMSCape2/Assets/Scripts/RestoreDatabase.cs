﻿using UnityEngine;
using System.Collections;

public class RestoreDatabase : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("ItemDatabase").GetComponent<Backup> ().Load ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
