﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PisanController : MonoBehaviour {
	public float lastHit;
	public float health = 5;
	public float maxhealth;

	public float playerX;
	public float enemyX;
	public float playerY;
	public float enemyY;
	public Transform target;

	public GameObject bullet;
	Vector2 bulletPos;
	public float fireRate = 1;
	public float lastFire;

	public float left;
	public float right;
	public float up;
	public float down;
	public int speed = 1;
	int count = 1;

	public Animator anim;
	Image healthbar;

	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
		anim = GetComponent<Animator> ();
		maxhealth = health;
		healthbar = GameObject.Find ("BossHealth").GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthbar.fillAmount = health / maxhealth;
		if (transform.position.x > left && count == 1) {
			transform.position += Vector3.left * speed * Time.deltaTime;
			if (transform.position.x < left) {
				count++;
			}
		} else if (transform.position.y > down && count == 2) {
			transform.position += Vector3.down * speed * Time.deltaTime;
			if (transform.position.y < down) {
				count++;
			}

		} else if (transform.position.x < right && count == 3) {
			transform.position += Vector3.right * speed * Time.deltaTime;
			if (transform.position.y > right) {
				count++;
			}
		} else {
			transform.position += Vector3.up * speed * Time.deltaTime;
			if (transform.position.y > up) {
				count = 1;
			}
		}

		playerX = target.transform.position.x;
		enemyX = transform.position.x;
		playerY = target.transform.position.y;
		enemyY = transform.position.y;
		if (health < 0) {
			this.gameObject.SetActive (false);
		}
		if (Time.time - lastFire > fireRate) {
			anim.SetBool ("Attacking", true);
			fire ();
			lastFire = Time.time;
		} else {
			anim.SetBool ("Attacking", false);
		}
	}

	void fire() {
		float divider = Mathf.Sqrt (Mathf.Pow (playerX - enemyX, 2) + Mathf.Pow (playerY - enemyY, 2));
		BulletController shot = bullet.GetComponent<BulletController>();
		shot.setVelocity ((playerX - enemyX) / divider, (playerY - enemyY) / divider);
		bulletPos = transform.position;
		Instantiate (bullet, bulletPos, Quaternion.identity);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerController health = other.GetComponent<PlayerController> ();
			health.takeDamage (1);
		}
		if (other.gameObject.CompareTag ("Weapon")) {
			if (Time.time - lastHit >= 0.5 || lastHit == 0) {
				health -= 1;
				lastHit = Time.time;
			}
		}
	}
}
