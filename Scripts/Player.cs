using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject missilePrefab;
	public GameObject enemy;
	public GameObject UFO;
	public GameObject gameOver;
	public GameObject deathSprite;

	public GameObject threeLives;
	public GameObject twoLives;
	public GameObject oneLife;
	int lives = 3;

	GameObject currentMissileObject;

	bool allowFire = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// Can only shoot once when missile is destroyed
		if (currentMissileObject != null) {
			allowFire = false;
		} else {
			allowFire = true;
		}
		// For player dying and showing death animation

		// For movement and player input
		if (Input.GetKeyDown (KeyCode.Space) && allowFire) {
			Fire();
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			gameObject.transform.Translate (0.03f, 0, 0);
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			gameObject.transform.Translate (-0.03f, 0, 0);
		}

		if (Input.GetKey (KeyCode.Return)) {
			Reload ();	
		}

	}

	void Fire() {
		//Instantiate (missilePrefab);
		//restarts the missile fire prefab
		audio.Play ();
		currentMissileObject = (GameObject) Instantiate (missilePrefab, transform.position, Quaternion.identity);
		//GameObject currentMissileObject = Instantiate (missilePrefab, transform.position, Quaternion.identity) as GameObject;
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Alien") {
			enemy.SetActive (false);
			gameOver.SetActive(true);
			UFO.SetActive(false);
			Reload ();
		} 
		else if (collision.gameObject.tag == "AlienMissile" && lives > 0) {
			GameObject.Destroy(collision.gameObject);
			lives--;
			Lives();
			StartCoroutine (respawn ());
		} 
		else if (lives == 0) {
			enemy.SetActive (false);
			gameOver.SetActive(true);
			UFO.SetActive(false);
			renderer.enabled = false;
			GameObject deathThroes = Instantiate (deathSprite, transform.position, Quaternion.identity) as GameObject;
			Reload ();
		}
	}

	IEnumerator respawn(){
		renderer.enabled = false;
		GameObject deathThroes = Instantiate (deathSprite, transform.position, Quaternion.identity) as GameObject;
		Destroy (deathThroes, 1f);
		yield return new WaitForSeconds(2);
		transform.position = new Vector2 (0f, -2.8f); 
		renderer.enabled = true;
	}
	void Lives(){
		if (lives == 3) {
			threeLives.SetActive(true);	
		}else if (lives == 2) {
			threeLives.SetActive(false);
			twoLives.SetActive(true);
		}else if (lives == 1) {
			twoLives.SetActive(false);
			oneLife.SetActive(true);
		}else if (lives == 0) {
			oneLife.SetActive(false);
		}
	}
	void Reload (){
//			DontDestroyOnLoad(transform.gameObject);
			Application.LoadLevel (Application.loadedLevel);
	}

}
