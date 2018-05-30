using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour {
	//Awake variables
	public Transform target;
	public Animator anim;
	public BossHealth myHealth;

	public float hitTime;

	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
		anim = GetComponent<Animator> ();
		myHealth = GetComponent<BossHealth> ();
	}

	// Use this for initialization
	void Start () {
		hitTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length <= 5) {
			int selectEnemy = Random.Range (0, EnemyList.numberEnemies);
			Instantiate (EnemyList.enemyList[selectEnemy],transform.position, Quaternion.identity);
		}
		if (Time.time - hitTime > 3f) {
			if (PlayerStatistics.level <= 5) {
				PlayerStatistics.takeDamage ((PlayerStatistics.maxHealth / 100) * 3);
			} else if (PlayerStatistics.level <= 15) {
				PlayerStatistics.takeDamage ((PlayerStatistics.maxHealth / 100) * 4);
			} else {
				PlayerStatistics.takeDamage ((PlayerStatistics.maxHealth / 100) * 5);
			}
			hitTime = Time.time;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerStatistics.takeDamage(PlayerStatistics.maxHealth / 200f);
			PlayerStatistics.takeDefDamage (PlayerStatistics.maxHealth / 200f);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerStatistics.takeDamage(PlayerStatistics.maxHealth / 200f);
			PlayerStatistics.takeDefDamage (PlayerStatistics.maxHealth / 200f);
		}
	}
}
