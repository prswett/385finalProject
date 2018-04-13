using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float velocityX;
	public float velocityY;
	Rigidbody2D rb2d;
	public Transform target;


	// Use this for initialization
	void Start () {
		rb2d = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2 (velocityX, velocityY);
		Destroy (gameObject, 4f);
	}

	public void setVelocity(float x, float y) {
		velocityX = x;
		velocityY = y;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerController health = other.GetComponent<PlayerController> ();
			health.takeDamage (1);
			Destroy (gameObject);
		}
		if (other.gameObject.CompareTag ("Ground")) {
			Destroy (gameObject);
		}
	}
}
