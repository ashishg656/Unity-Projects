using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Camera cam;

	public GameObject ball;

	private float maxWidth;
	public float timeLeft;

	public Text timerText;

	public GameObject restartButton, gameOverText;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}

		Renderer ballRenderer = ball.GetComponent<Renderer> ();

		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		// calculating the width of the hat object dynamically
		float ballWidth = ballRenderer.bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;

		StartCoroutine (Spawn());
		UpdateText();
	}

	void FixedUpdate(){
		timeLeft -= Time.deltaTime;
		if(timeLeft<0){
			timeLeft = 0;
		}
		UpdateText();
	}

	void UpdateText(){
		timerText.text = "Time Left: " + Mathf.RoundToInt(timeLeft).ToString();
	}

	IEnumerator Spawn(){
		yield return new WaitForSeconds (1f);

		while (timeLeft>0) {
			Vector3 spawnPosition = new Vector3 (
				Random.Range(-maxWidth,maxWidth),
				transform.position.y,
				0.0f);

			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (ball, spawnPosition, spawnRotation);

			yield return new WaitForSeconds (Random.Range(1f,2f));
		}

		yield return new WaitForSeconds(1f);
		gameOverText.SetActive(true);
		yield return new WaitForSeconds(1f);
		restartButton.SetActive(true);
	}
}
