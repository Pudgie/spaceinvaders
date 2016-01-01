using UnityEngine;
using System.Collections;

public class animationSpeed : MonoBehaviour {

	public float animSpeed;
	public GameObject enemies;
	int speed = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (enemies.transform.position.y < 0.4 && enemies.transform.position.y > 0) {
			speed = 5;	
		} else if (enemies.transform.position.y < 0 && enemies.transform.position.y > -1.55) {
			speed = 8;
		} else if (enemies.transform.position.y < -1.55) {
			speed = 13;
		}

		gameObject.GetComponent<Animator>().speed = .1f * speed;
	}
}
