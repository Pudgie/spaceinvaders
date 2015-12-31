using UnityEngine;
using System.Collections;

public class UFO : MonoBehaviour {

	public float minDelayTime = 5.0f;
	public float maxDelayTime = 10.0f;
	public float speed= 1f;

	public float startX = -3.8f;
	public float endX = 3.8f;

	bool _moving;
	float _timer;

	// Use this for initialization
	void Start () {
	WaitToAppear(); 
	}
	
	// Update is called once per frame
	void Update () {
				if (_moving) {
						transform.Translate (Vector3.right * speed);
						if (transform.position.x > endX) {
								WaitToAppear ();
				renderer.enabled = true;
						}
				} else {
						_timer -= Time.deltaTime;
						if (_timer < 0.0f) {
								_moving = true;
								audio.Play ();

						}
				}
		}
		
		void WaitToAppear() {
		_moving = false;
		transform.position = new Vector2 (startX, transform.position.y);
		_timer = Random.Range (minDelayTime, maxDelayTime);

	}
}



			                                
	
				//transform.Translate (Vector3.right * Time.deltaTime);
					



