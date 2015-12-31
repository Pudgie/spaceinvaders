using UnityEngine;
using System.Collections;

public class ShieldBroken : MonoBehaviour {

public Sprite[] damageSprites;
	
SpriteRenderer spriteRenderer;

// Use this for initialization
void Start () {
	spriteRenderer = GetComponent<SpriteRenderer>();
}

// Update is called once per frame
void Update () {
	
}
void OnDamaged(float normalisedHealth) {
		int spriteIndex = Mathf.FloorToInt(normalisedHealth * (damageSprites.Length - 0.01f)); 
	   spriteRenderer.sprite = damageSprites[spriteIndex]; 
	                                   }
	                                   }
	                                   
