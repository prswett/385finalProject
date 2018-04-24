using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEnemyWep : MonoBehaviour {

	//Start variables
	public float lastFire;
	public Transform target;
	public Animator anim;

	//Update variables
	public float playerX;
	public float enemyX;
	public float playerY;
	public float enemyY;
	public float jumpTime;
	public bool jumping;
	public float MinDist = 0.1f;
	public float fireRate = 1;
	public bool location;

	//collide variables
	public float speed;
	public float jumpSpeed;
	public bool facing = false;

	void Start () {
		lastFire = 0;
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

		if (playerY - enemyY > .3) {
			jumping = true;
			jumpTime = Time.time;
		}

		collideMove ();

		if (!(enemyX - playerX > MinDist) && !(enemyX - playerX < -MinDist)) {
			if (Time.time - lastFire > fireRate) {
				anim.SetBool ("attacking", true);
				anim.SetBool ("walking", false);
				Invoke ("slash", .1f);
				lastFire = Time.time;
			}
		}
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
				anim.SetBool ("slash", false);
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

	void slash() {
		anim.SetBool ("slash", true);
	}

	//If collide with player, make them take damage
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Player health = other.GetComponent<Player> ();
			health.takeDamage (1);
		}
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
