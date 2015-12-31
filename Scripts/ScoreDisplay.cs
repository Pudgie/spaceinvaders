using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour {

	int currentScore = 0;
	//	int highScore = 0;
	public TextMesh currentScoreText;
	
	void Start () {
		currentScoreText = GetComponentInChildren<TextMesh>();
	}
	
	void Update () {
		
	}
	
	public void UpdateScore(int pointsToAdd) {
		currentScore += pointsToAdd;
		currentScoreText.text = "SCORE: "+currentScore.ToString ();
		
		//		int score = 4;
		//		string scoreString = "4"; <-this
	}
}
