using UnityEngine;
using System.Collections;

public abstract class Scenario : MonoBehaviour {

	// Use this for initialization
	abstract public void Play();
	
	// Update is called once per frame
	abstract public void EndScenario();
}
