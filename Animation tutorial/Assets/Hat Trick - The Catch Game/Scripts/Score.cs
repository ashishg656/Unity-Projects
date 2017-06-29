using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	public int ballValue;

	private int score;

	// Use this for initialization
	void Start () {
		score = 0;

		updateScore();
	}

	void OnTriggerEnter2D(Collider2D other){
		score += ballValue;
		updateScore();
	}
	void updateScore(){
		scoreText.text = "Score: "+score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
