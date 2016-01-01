using UnityEngine;
using System.Collections;

public class UFODeath : MonoBehaviour {
	
	const int deathThroesLength = 20;
	int deathThroeCounter = 0;
	//int shootCounter = 0;
	
	//public Sprite deathExplode;
	
	public GameObject deathSprite;
	
	bool dying = false;
	//bool allowFire = false;
	
	// Use this for initialization
	void Start () {
		//deathSprite = transform.FindChild ("invader_splode").gameObject;
		//nextShoot = Random.Range(minShoot, maxShoot);
	}
	
	// Update is called once per frame
	void Update () {

		if (dying) {
			deathThroeCounter++;
			if (deathThroeCounter == deathThroesLength) { 
				GameObject deathThroes = Instantiate(deathSprite, transform.position, Quaternion.identity) as GameObject;
				Destroy(deathThroes, 0.08f);
				renderer.enabled = false;
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
	}
}
