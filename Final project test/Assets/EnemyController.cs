using System.Collections;
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

	// Use this for initialization
	void Start () {
		lastFire = 0;
	}
	
	// Update is called once per frame
	void Update () {
		playerX = target.transform.position.x;
		enemyX = transform.position.x;
		playerY = target.transform.position.y;
		enemyY = transform.position.y;
		//transform.LookAt (target);
		if (enemyX - playerX < -0.1) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} 
		if (enemyX - playerX > 0.1) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		if ((enemyX - playerX > MinDist) || (enemyX - playerX < MinDist)) {
			if (Time.time - lastFire > fireRate) {
				fire ();
				lastFire = Time.time;
			}
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
	}
		
}
