using UnityEngine;
using System.Collections;

public class SpaceControlPlayer : MonoBehaviour {

	Vector3 initPos;
	public float dec ;
	void Start(){
		initPos = this.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Vector3 pos = this.transform.position;
			pos.x = initPos.x + dec;
			this.transform.position = Vector3.Lerp(initPos,pos,Time.deltaTime);
		} else {
			this.transform.position = initPos;
		}
	}
}
