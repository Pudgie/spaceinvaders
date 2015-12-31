using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OctopusScore : MonoBehaviour {

	int pointValue = 10;
	
	GameObject scoreObject;
	ScoreDisplay scoreScript;
	
	//	bool selfDestruct = false;
	
	void Start () {	
		scoreObject = GameObject.Find ("Score");
		scoreScript = scoreObject.GetComponent<ScoreDisplay>();	
	}
	
	void Update () {
		//		if (selfDestruct) {
		//			Destroy (gameObject);
		//		}
	}
	
	void OnTriggerEnter2D (Collider2D otherCollider) {
		if (otherCollider.gameObject.tag == "PlayerMissile") {
			scoreScript.UpdateScore (pointValue);
		}
	}
}
