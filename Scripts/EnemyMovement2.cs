using UnityEngine;
using System.Collections;

public class EnemyMovement2 : MonoBehaviour{

	float leftEdge;
	float rightEdge;
	int movementSpeed = 1;
	string currentState;
	float lastMoved = 0f;
	
	// Use this for initialization
	void Start (){
		leftEdge = -3;
		rightEdge = 3;
		
		currentState = "movingRight";
	}
	
		// Update is called once per frame
	void Update (){
		if (gameObject.transform.position.y < 0.4 && gameObject.transform.position.y > 0) {
			movementSpeed = 5;	
		} else if (gameObject.transform.position.y < 0 && gameObject.transform.position.y > -1.55) {
			movementSpeed = 8;
		} else if (gameObject.transform.position.y < -1.55) {
			movementSpeed = 13;
		}
		if ((Time.time - lastMoved) > .2f) {
			lastMoved = Time.time;
			move ();	
			}
	}

	void move ()
		{
				Transform[] allChildren = GetComponentsInChildren<Transform> ();
				foreach (Transform child in allChildren) {
						if (currentState == "movingRight") {
								if (child.transform.position.x >= rightEdge) {
										currentState = "movingLeft";
								} else {
										child.transform.Translate (.005f * movementSpeed, 0, 0);
								}
						} else if (currentState == "movingLeft") {
								if (child.transform.position.x <= leftEdge) {
										currentState = "movingRight";
								} else {
										child.transform.Translate (-.005f * movementSpeed, 0, 0);
								}

						}
						if (child.transform.position.x <= leftEdge || child.transform.position.x >= rightEdge) {
								gameObject.transform.Translate (0, -0.1f, 0);
						}
				}
		}
	
}