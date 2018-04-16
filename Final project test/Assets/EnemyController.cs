﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float playerX;
	public float enemyX;
	public float playerY;
	public float enemyY;
	public Transform target;

	public int speed;
	public float MinDist = 0.1f;

	public GameObject bullet;
	Vector2 bulletPos;
	public float fireRate = 1;

	public float lastFire;
	public float attackAnim;
	public float attackAnimDelay = 0.1f;
	public Animator anim;

	public bool noWep = false;
	public bool facing = false;

	void Start () {
		lastFire = 0;
		target = GameObject.FindWithTag ("Player").transform;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Get the coordinates of enemy and player
		if (noWep) {
			noCollideMove ();
		} else {
			collideMove ();
		}

		//if enemy is within a certain distance, start shooting
		if (!(enemyX - playerX > MinDist) && !(enemyX - playerX < -MinDist)) {
			if (Time.time - lastFire > fireRate) {
				anim.SetBool ("attacking", true);
				if (noWep) {
					fire ();
				} else {
					slash ();
				}
				lastFire = Time.time;
				attackAnim = Time.time;
			}
		}
	}

	void noCollideMove() {
		anim.SetBool ("attacking", false);
		playerX = target.transform.position.x;
		enemyX = transform.position.x;
		playerY = target.transform.position.y;
		enemyY = transform.position.y;
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
		if (enemyY - playerY < -MinDist) {
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if (enemyY - playerY > MinDist) {
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
	}

	void collideMove() {
		playerX = target.transform.position.x;
		enemyX = transform.position.x;
		playerY = target.transform.position.y;
		enemyY = transform.position.y;

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

	//Declare a bullet object and send it at a velocity.
	void fire() {
		float divider = Mathf.Sqrt (Mathf.Pow (playerX - enemyX, 2) + Mathf.Pow (playerY - enemyY, 2));
		BulletController shot = bullet.GetComponent<BulletController>();
		shot.setVelocity ((playerX - enemyX) / divider, (playerY - enemyY) / divider);
		bulletPos = transform.position;
		Instantiate (bullet, bulletPos, Quaternion.identity);
	}

	void slash() {

	}

	//If collide with player, make them take damage
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Player health = other.GetComponent<Player> ();
			health.takeDamage (1);
		}
	}
		
	void flip() {
		facing = !facing;
		Vector3 charscale = transform.localScale;
		charscale.x *= -1;
		transform.localScale = charscale;
	}

	public GameObject getBullet() {
		return bullet;
	}
		
}
