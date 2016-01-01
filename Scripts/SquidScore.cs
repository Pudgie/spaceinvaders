using UnityEngine;
using System.Collections;

public class SquidScore : MonoBehaviour {

	int pointValue = 40;
	
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
