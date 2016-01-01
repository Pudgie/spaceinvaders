using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	float maxY = 5f;

	float missileSpeed = 0.15f;

	Vector2 howToMove;

	// Use this for initialization
	void Start () {
		howToMove = new Vector2 (0f, missileSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (howToMove);
		if (gameObject.transform.position.y > maxY) {
			Destroy (gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Shield") {
			GameObject.Destroy(this.gameObject);
			GameObject.Destroy(collision.gameObject);
		}
	

		if (collision.gameObject.tag == "drawingsprites_0") {
			GameObject.Destroy(this.gameObject);
			GameObject.Destroy(collision.gameObject);
	
}
	}
}
