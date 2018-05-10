using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	/**
	 * This class controls enemy bullets. It controls how they move
	 * when to remove them, dealing damage, etc
	 **/

	//Public variables
	public float velocityX;
	public float velocityY;
	Rigidbody2D rb2d;
	public bool enemyUnit = true;
	public bool groundCollide = true;
	public Transform target;
	public Animator anim;
	public bool explosion = false;
	public bool portal = false;

	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
	}
	// Declare rigid body for bullet
	void Start () {
		rb2d = this.GetComponent<Rigidbody2D>();
		transform.rotation = Quaternion.LookRotation (Vector3.forward, target.position - transform.position);
		if (portal) {
			if (target.position.x < transform.position.x) {
				transform.position = new Vector3 (transform.position.x - 0.1f, transform.position.y, 1);
			} else {
				transform.position = new Vector3 (transform.position.x + 0.1f, transform.position.y, 1);
			}
		}
	}
	
	//Add velocity to the bullet
	//If its an enemy shooting, remove after 4 seconds, if its a boss
	//Remove after 8 seconds
	void Update () {
		//transform.localScale = new Vector3 (1, 1, 1f);
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
			PlayerStatistics.takeDamage(1);
			if (!explosion) {
				Destroy (gameObject);
			} else {
				Invoke ("remove", 1f);
				anim.SetBool ("hit", true);
				setVelocity (0, 0);
			}
		}
		if (other.gameObject.CompareTag ("Ground")) {
			if (groundCollide) {
				if (!explosion) {
					Destroy (gameObject);
				} else {
					Invoke ("remove", 1f);
					anim.SetBool ("hit", true);
					setVelocity (0, 0);
				}
			}
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerStatistics.takeDamage(1 + PlayerStatistics.level / 2);
		}
	}

	void remove() {
		Destroy (gameObject);
	}

	//Used 
	public void setGroundCollide(bool input) {
		groundCollide = input;
	}
}
