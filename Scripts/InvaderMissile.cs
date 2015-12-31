using UnityEngine;
using System.Collections;

public class InvaderMissile : MonoBehaviour {
	
	float maxY = -3f;
	
	float missileSpeed = -0.04f;
	
	Vector2 howToMove;
	
	// Use this for initialization
	void Start () {
		howToMove = new Vector2 (0f, missileSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (howToMove);
		if (gameObject.transform.position.y < maxY) {
			Destroy (gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "PlayerMissile" || collision.gameObject.tag == "Player"){
			GameObject.Destroy(collision.gameObject);
			GameObject.Destroy(this.gameObject);
		}
		if (collision.gameObject.tag == "Shield") {
			GameObject.Destroy (this.gameObject);
			GameObject.Destroy(collision.gameObject);
		}
	}
}
