using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour {

	public float playerX;
	public float enemyX;
	public float playerY;
	public float enemyY;
	public Transform target;

	public GameObject bullet;
	Vector2 bulletPos;
	public float fireRate = 1;
	public float lastFire;
	public int baseDamage = 15;

	public float left;
	public float right;
	public float up;
	public float down;
	public int speed = 1;
	int count = 1;

	public bool bulletGround = true;
	public Animator anim;

	public Transform myself;
	public BossHealth temp;

	float currentHealth;
	float maxHealth;

	void Awake () {
		target = GameObject.FindWithTag ("Player").transform;
		anim = GetComponent<Animator> ();
		myself = GameObject.FindWithTag("Boss").transform;
		temp = myself.GetComponent<BossHealth>();
	}

	void Update () {
		currentHealth = temp.currentHealth;
		maxHealth = temp.maxHealth;
		if (currentHealth / maxHealth <= .5) {
			bulletGround = false;
			speed = 2;
			fireRate = .5f;
		}

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
		//Get the positions of player and enemy
		playerX = target.transform.position.x;
		enemyX = transform.position.x;
		playerY = target.transform.position.y;
		enemyY = transform.position.y;
		//Attack only at a particular interval (fire rate)
		if (Time.time - lastFire > fireRate) {
			if (bulletGround == false) {
				fire2 ();
			} else {
				fire ();
			}
			lastFire = Time.time;
		}
	}

	void fire2() {
		BulletController shot = bullet.GetComponent<BulletController>();
		shot.setVelocity(-2,0);
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(2,0);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(0,2);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(0,-2);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(-2,-2);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(2,2);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(-2,2);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(2,-2);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.setVelocity(-1,3);
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(1,3);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(-1,-3);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(1,-3);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(3,1);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(3,-1);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(-3,1);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(-3,-1);
		Instantiate (bullet, transform.position, Quaternion.identity);
	}

	void fire() {
		BulletController shot = bullet.GetComponent<BulletController>();
		 
		shot.setVelocity(-2,0);
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(2,0);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(0,2);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(0,-2);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(-2,-2);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(2,2);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(-2,2);
		Instantiate (bullet, transform.position, Quaternion.identity);

		shot = bullet.GetComponent<BulletController>();
		 
		shot.damage = (int)(baseDamage + PlayerStatistics.level / 5);
		shot.setVelocity(2,-2);
		Instantiate (bullet, transform.position, Quaternion.identity);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerStatistics.takeDamage (baseDamage + PlayerStatistics.level / 5);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerStatistics.takeDamage (baseDamage + PlayerStatistics.level / 5);
		}
	}
}
