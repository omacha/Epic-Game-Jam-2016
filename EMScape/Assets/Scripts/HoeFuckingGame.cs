using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEditor;

public class HoeFuckingGame : MonoBehaviour {

	GameObject counter;
	float time = 180.0f;
	GameObject jauge;
	GameObject slider;

	Vector3 jaugePos;
	Vector3 sliderPos;
	public float sizeJauge = 300;
	float minJaugeY = 0;
	float maxJaugeY = 0;

	bool goUp = true;
	public float speed = 2;
	int nbFrame = 20;

	public float maxScore = 2000.0f;
	public float score = 0;

	bool win = false;

	// Use this for initialization
	void Start () {
		jauge = GameObject.Find ("Jauge");
		slider = GameObject.Find ("Slider");

		jaugePos = jauge.transform.position;

		maxJaugeY = jaugePos.y + sizeJauge / 2;
		minJaugeY = jaugePos.y - sizeJauge / 2;

		counter = GameObject.Find ("Counter");
		if (counter == null) {
			Debug.LogError ("Can't find counter gameobject");
		} else {
			counter.GetComponent<Text> ().text = "3:00";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!win) {
			ChangeSpeed ();
			UpdateTimeGUI ();
		} else {
			speed = 0;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			ComputeScore ();
		}

		AnimateSlider ();
		UpdateScoreGUI ();
		if(score >= maxScore){
			Debug.Log ("YOU WIN");
			win = true;
			GameObject.Find ("WIN").GetComponent<Text> ().enabled = true;
			StartCoroutine ("EndGame");
				
		}
		if (time <= 0) {
			ShowGameOverBox ();
		}
	}

	void UpdateTimeGUI(){
		time -= Time.deltaTime;
		float minutes = Mathf.Floor (time / 60.0f);
		float seconds = (time - minutes * 60);
		counter.GetComponent<Text> ().text = (minutes.ToString () + "m:" + seconds.ToString () + "s");
	}


	void ShowGameOverBox(){
		Debug.Log ("GAMEOVER");
	}

	void AnimateSlider(){
		sliderPos = slider.transform.position;
		if (goUp) {
			if (sliderPos.y < maxJaugeY) {
				sliderPos.y += 1 * speed;
				slider.transform.position = sliderPos;
			} else {
				goUp = false;
			}
		}else{
			if (sliderPos.y > minJaugeY) {
				sliderPos.y -= 1 * speed;
				slider.transform.position = sliderPos;
			} else {
				goUp = true;
			}
		}
	}

	void ChangeSpeed(){
		nbFrame--;
		//Each 20 frame, change velocity randomly
		if (nbFrame == 0) {
			float bo = UnityEngine.Random.value;
			int a = 1;
			if (bo < 0.5f) {
				a = -a;
			}
			speed += a*1.2f * UnityEngine.Random.value;
			if (speed < 0.2f) {
				speed = 0.2f;
			}
			if (speed > 8) {
				speed = 8.0f;
			}
			nbFrame = 20;
		}
	}

	private void ComputeScore(){
		sliderPos = slider.transform.position;
		jaugePos = jauge.transform.position;

		float zero = jaugePos.y;
		float pressed = sliderPos.y;

		float distance = Math.Abs (zero - pressed);

		if (distance > 40.0f) {
			score -= distance;
		} else {
			score += 60-distance / 130;
		}

		if (score < 0) {
			score = 0;
		}
	}


	void UpdateScoreGUI(){
		Image progress = GameObject.Find ("Progress").transform.GetComponent<Image>();
		progress.fillAmount = score / maxScore;
	}

	IEnumerator EndGame(){
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		float fadeTime = GameObject.Find("GameManager").GetComponent<Fading>().BeginFade(1);

		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel (2);
	}
}
