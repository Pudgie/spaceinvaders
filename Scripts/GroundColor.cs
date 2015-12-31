using UnityEngine;
using System.Collections;

public class GroundColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.renderer.material.color = new Color(28,227,38);
	}
}
