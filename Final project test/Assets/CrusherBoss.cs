using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherBoss : MonoBehaviour {

	public float playerX;
	public float playerY;
	public Transform target;
	public Animator anim;

	public BossHealth myHealth;
	int baseDamage = 5;
	int damage = 25;
	public float increaseDamage;

	public float minDist = 0.3f;
	public float left;
	public float right;
	public float down;
	public float up;

	public float dropDown;
	public float stayDown;
	public bool stayDropped = false;

	public bool goLeft = true;
	public bool goRight = false;
	public bool goDown = true;
	public bool goUp = false;

	public bool attack = false;
	public float speed = 2f;

	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
		anim = GetComponent<Animator> ();
		myHealth = GetComponent<BossHealth> ();
	}
		
	void Start () {
		increaseDamage = Time.time;
		dropDown = Time.time;
	}

	void Update () {
		if (Time.time - increaseDamage > 10f) {
			damage += baseDamage;
			increaseDamage = Time.time;
		}

		if (myHealth.currentHealth <= (myHealth.maxHealth / 2)) {
			speed = 4f;
			baseDamage = 15;
		} else if (myHealth.currentHealth <= (myHealth.maxHealth / 4 * 3)) {
			speed = 3f;
			baseDamage = 10;
		}
		playerX = target.transform.position.x;
		playerY = target.transform.position.y;


		float dist = Mathf.Abs (transform.position.x - playerX);

		if (dist <= minDist) {
			attack = true;
		}

		if (attack) {
			if (transform.position.y > down && goDown) {
				transform.position += Vector3.down * speed * Time.deltaTime;
			} else {
				transform.position += Vector3.up * speed * Time.deltaTime;
				goDown = false;
			}
		}
		if (transform.position.y >= up) {
			attack = false;
			goDown = true;
		}
		if (!attack) {
			if (transform.position.x < playerX && transform.position.x < right) {
				transform.position += Vector3.right * (speed / 2f) * Time.deltaTime;
			} else if (transform.position.x > playerX && transform.position.x > left) {
				transform.position += Vector3.left * (speed / 2f) * Time.deltaTime;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerStatistics.takeDamage(damage + (float)(int)PlayerStatistics.maxHealth / 100);
			PlayerStatistics.takeDefDamage(damage + (float)(int)PlayerStatistics.maxHealth / 100);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerStatistics.takeDamage(damage + (float)(int)PlayerStatistics.maxHealth / 100);
			PlayerStatistics.takeDefDamage(damage + (float)(int)PlayerStatistics.maxHealth / 100);
		}
	}
}
