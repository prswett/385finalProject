using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	//Public variables
	public float velocityX;
	public float velocityY;
	Rigidbody2D rb2d;
	public bool enemyUnit = true;
	public bool groundCollide = true;

	// Declare rigid body for bullet
	void Start () {
		rb2d = this.GetComponent<Rigidbody2D>();
	}
	
	//Add velocity to the bullet
	//If its an enemy shooting, remove after 4 seconds, if its a boss
	//Remove after 8 seconds
	void Update () {
		rb2d.velocity = new Vector2 (velocityX, velocityY) * 3;
		if (enemyUnit) {
			Destroy (gameObject, 4f);
		} else {
			Destroy (gameObject, 8f);
		}

	}

	//Set velocity
	public void setVelocity(float x, float y) {
		velocityX = x;
		velocityY = y;
	}

	//On collision with player do damage
	//On collision with ground dissapear
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Player health = other.GetComponent<Player> ();
			health.takeDamage (1);
			Destroy (gameObject);
		}
		if (other.gameObject.CompareTag ("Ground")) {
			if (groundCollide) {
				Destroy (gameObject);
			}
		}
	}

	public void setGroundCollide(bool input) {
		groundCollide = input;
	}
}
