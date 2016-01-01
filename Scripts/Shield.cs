using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

public float toughness = 1.0f;
	float health; 

	// Use this for initialization
	void Start () {
		health = toughness;
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D coll) {
	Destroy(coll.gameObject);

	health -= 1.0f;
	
	}
	
		}

	