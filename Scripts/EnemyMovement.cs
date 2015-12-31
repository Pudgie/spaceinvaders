using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	
	float leftEdge;
	float rightEdge;
	
	string currentState;

	// Use this for initialization
	void Start () {
		leftEdge = -1;
		rightEdge = 1;
		
		currentState = "movingRight";
	}
	
	// Update is called once per frame
	void Update () {
		if (currentState == "movingRight") {
			if (gameObject.transform.position.x > rightEdge) {
				currentState = "movingLeft";
			} else {
				gameObject.transform.Translate (.008f,0,0);
			}
		} else if (currentState == "movingLeft") {
			if (gameObject.transform.position.x < leftEdge) {
				currentState = "movingRight";
			} else {
				gameObject.transform.Translate (-.008f,0,0);
			}
		}
		if (gameObject.transform.position.x < leftEdge || gameObject.transform.position.x > rightEdge) {
			gameObject.transform.Translate (0,-0.09f,0);
		}

	}
	
}