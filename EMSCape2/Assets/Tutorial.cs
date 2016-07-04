using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

	public GameObject control;
	public GameObject explain;
	public GameObject tuto;
	// Use this for initialization
	void Start () {
		GameObject.Find ("ItemDatabase").GetComponent<Backup> ().Load ();
		if (GameObject.Find ("ItemDatabase").GetComponent<ItemDatabase>().itemList[15].itemAquired == false){
				explain.transform.gameObject.SetActive (true);
				control.transform.gameObject.SetActive (false);
			GameObject.Find ("ItemDatabase").GetComponent<ItemDatabase> ().itemList [15].itemAquired = true;

			GameObject.Find ("ItemDatabase").GetComponent<Backup> ().Save ();
			Debug.Log ("First time");
		} else {
			explain.transform.gameObject.SetActive (false);
			control.transform.gameObject.SetActive (false);
			tuto.transform.gameObject.SetActive (false);
			GameObject.Find ("ItemDatabase").GetComponent<Backup> ().Load ();
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
