﻿using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public GameObject control;
	public GameObject explain;
	public GameObject tuto;
	// Use this for initialization
	void Start () {
		if (explain != null) {
			explain.transform.gameObject.SetActive (true);
			control.transform.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)){
		if (explain.transform.gameObject.activeSelf) {
				ShowNext();
			}else if (control.transform.gameObject.activeSelf){
				EndTuto();
			}
		}
	}

	public void ShowNext(){
		Debug.Log ("ShowNext");
		explain.transform.gameObject.SetActive (false);
		control.transform.gameObject.SetActive (true);
	}

	public void ShowPrec(){

		Debug.Log ("ShowPrec");
		explain.transform.gameObject.SetActive (true);
		control.transform.gameObject.SetActive (false);
	}

	public void EndTuto(){

		Debug.Log ("EndTuto");
		tuto.gameObject.SetActive (false);
	}
		
}
