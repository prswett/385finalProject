using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeController : MonoBehaviour {
	//Start variables
	public Transform target;
	public Animator anim;

	//Update variables
	public bool location;
	public float playerX;
	public float enemyX;
	public float playerY;
	public float enemyY;
	public bool jumping;
	public float jumpTime;

	//movement
	public bool facing = false;
	public float MinDist = 0.1f;
	public float jumpSpeed;
	public float speed = 1;

	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!location) {
			Destroy (gameObject);
		}

		playerX = target.transform.position.x;
		enemyX = transform.position.x;
		playerY = target.transform.position.y;
		enemyY = transform.position.y;
		if (Time.time - jumpTime > .4) {
			jumping = false;
		}

		if (playerY - enemyY > .3 && jumping == false) {
			jumping = true;
			jumpTime = Time.time;
		}

		collideMove ();
	}

	void collideMove() {
		anim.SetBool ("attacking", false);
		if (jumping) {
			transform.position += Vector3.up * jumpSpeed * .07f;
			if (enemyX - playerX < -MinDist) {
				if (facing) {
					flip ();
				}
				transform.position += Vector3.right * speed * Time.deltaTime;
			} else {
				if (!facing) {
					flip ();
				}
				transform.position += Vector3.left * speed * Time.deltaTime;
			}
		} else {
			if (enemyX - playerX < -MinDist || enemyX - playerX > MinDist) {
				anim.SetBool ("walking", true);
				if (enemyX - playerX < -MinDist) {
					if (facing) {
						flip ();
					}
					transform.position += Vector3.right * speed * Time.deltaTime;
				}
				if (enemyX - playerX > MinDist) {
					if (!facing) {
						flip ();
					}
					transform.position += Vector3.left * speed * Time.deltaTime;
				}
			}
		}
	}

	//If collide with player, make them take damage
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Ground")) {
			location = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Ground")) {
			location = false;
		}
	}

	void flip() {
		facing = !facing;
		Vector3 charscale = transform.localScale;
		charscale.x *= -1;
		transform.localScale = charscale;
	}
}
