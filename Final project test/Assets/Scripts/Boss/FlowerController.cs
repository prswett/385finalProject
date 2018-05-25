using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour {
	//Awake variables
	public Transform target;
	public Animator anim;
	public BossHealth myHealth;

	public float hitTime;

	int damage = 20;
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
			PlayerStatistics.takeDamage((PlayerStatistics.maxHealth / 100) * 2);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerStatistics.takeDamage(damage + PlayerStatistics.level);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerStatistics.takeDamage(damage + PlayerStatistics.level);
		}
	}
}
