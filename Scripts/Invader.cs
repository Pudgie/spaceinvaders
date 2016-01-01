using UnityEngine;
using System.Collections;

public class Invader : MonoBehaviour {

	const int deathThroesLength = 20;
	int deathThroeCounter = 0;
	
//	public Sprite deathExplode;

	public GameObject deathSprite;
	public GameObject missile;
	public GameObject otherAlien;

	public float minShoot = 1.0f;
	public float maxShoot = 4.0f;
	private float nextShoot = 1.0f;
	
	bool dying = false;
	bool allowFire = false;

	GameObject currentMissileObject;
	GameObject[] maxMissiles;

	// Use this for initialization
	void Start () {
		//deathSprite = transform.FindChild ("invader_splode").gameObject;
		nextShoot = Random.Range(minShoot, maxShoot);
	}
	
	// Update is called once per frame
	void Update () {
		maxMissiles = GameObject.FindGameObjectsWithTag ("AlienMissile");
		if (currentMissileObject != null || otherAlien != null) {
			allowFire = false;
		} else {
			allowFire = true;
		}

		if (allowFire && maxMissiles.Length <= 2) {
			RandomShoot ();
		}

		if (dying) {
			deathThroeCounter++;
			if (deathThroeCounter == deathThroesLength) { 
				GameObject deathThroes = Instantiate(deathSprite, transform.position, Quaternion.identity) as GameObject;
				Destroy(deathThroes, 0.08f);
				Destroy (gameObject);
			}
		}
	}
	
	void OnTriggerEnter2D (Collider2D theOtherCollider){
		if (theOtherCollider.gameObject.tag == "PlayerMissile") {
			audio.Play ();
			// destroys the missile
			Destroy (theOtherCollider.gameObject);
			dying = true;
		}
		//if (theOtherCollider.gameObject.tag == "Player") {
			//Destroy (theOtherCollider.gameObject);
		//}
	}

	void RandomShoot () {
		if (Time.time > nextShoot){
			nextShoot = Time.time * Random.Range(minShoot, maxShoot);
			currentMissileObject = (GameObject) Instantiate(missile, transform.position, Quaternion.identity);
		}
	}
	
}