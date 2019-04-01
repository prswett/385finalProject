using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss1Controller : MonoBehaviour {

	//Awake variables
	private float playerX;
	private float enemyX;
	private float playerY;
	private float enemyY;
	public Transform target;
	public Animator anim;

	public GameObject bullet;
	Vector2 bulletPos;

	public BossHealth myHealth;
	int baseDamage = 20;
	int damage = 150;
	public float increaseDamage;

	public float shootTime;
	public float attackWindow;
	public bool shooting = false;
	public float shootAgain;
	public bool set = false;


	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
		anim = GetComponent<Animator> ();
		myHealth = GetComponent<BossHealth> ();
	}

	void Start () {
		increaseDamage = Time.time;
		attackWindow = Time.time;
		shootTime = Time.time;
		shootAgain = Time.time;
	}

	void Update () {
		if (Time.time - increaseDamage > 15f) {
			damage += baseDamage;
			increaseDamage = Time.time;
		}

		playerX = target.transform.position.x;
		enemyX = transform.position.x;
		playerY = target.transform.position.y;
		enemyY = transform.position.y + 1.1f;

		if (Time.time - attackWindow < 10f) {
			if (myHealth.currentHealth <= myHealth.maxHealth / 2) {
				if (Time.time - shootTime > .1f) {
					fire ();
					shootTime = Time.time;
					baseDamage = 30;
				}
			} else {
				if (Time.time - shootTime > .3f) {
					fire ();
					shootTime = Time.time;
				}
			}
		} else {
			shooting = true;
			if (!set) {
				shootAgain = Time.time;
				set = true;
			}
		}

		if (shooting) {
			if (myHealth.currentHealth <= myHealth.maxHealth / 2) {
				if (Time.time - shootAgain >= 2f) {
					attackWindow = Time.time;
					shooting = false;
					set = false;
				}
			} else {
				if (Time.time - shootAgain >= 4f) {
					attackWindow = Time.time;
					shooting = false;
					set = false;
				}
			}
		}
	}

	void fire() {
		float divider = Mathf.Sqrt (Mathf.Pow (playerX - enemyX, 2) + Mathf.Pow (playerY - enemyY , 2));
		BulletController shot = bullet.GetComponent<BulletController>();
		shot.setVelocity ((playerX - enemyX) / divider, (playerY - enemyY) / divider);
		shot.damage = damage;
		bulletPos = new Vector2 (enemyX, enemyY);
		Instantiate (bullet, bulletPos, Quaternion.identity);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerStatistics.takeDamage(damage);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerStatistics.takeDamage(damage);
		}
	}
}
