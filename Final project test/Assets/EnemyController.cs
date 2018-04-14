﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float distance;

	public float playerX;
	public float enemyX;
	public float playerY;
	public float enemyY;
	public Transform target;

	public int speed;
	public int MinDist;

	public GameObject bullet;
	Vector2 bulletPos;
	public float fireRate = 1;

	public float lastFire;

	//set target to player, which is the object the enemy will chase
	void Start () {
		lastFire = 0;
		target = GameObject.FindWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//Get the coordinates of enemy and player
		playerX = target.transform.position.x;
		enemyX = transform.position.x;
		playerY = target.transform.position.y;
		enemyY = transform.position.y;
		//Move right if player is to the right, move left if player is
		//to the left
		if (enemyX - playerX < -0.1) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} 
		if (enemyX - playerX > 0.1) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		//if enemy is within a certain distance, start shooting
		if ((enemyX - playerX > MinDist) || (enemyX - playerX < MinDist)) {
			if (Time.time - lastFire > fireRate) {
				fire ();
				lastFire = Time.time;
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

	//If collide with player, make them take damage
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerController health = other.GetComponent<PlayerController> ();
			health.takeDamage (1);
		}
	}

	public GameObject getBullet() {
		return bullet;
	}
		
}
