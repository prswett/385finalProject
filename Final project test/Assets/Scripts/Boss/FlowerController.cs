using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour {
	//Awake variables
	public Transform target;
	public Animator anim;
	public BossHealth myHealth;

	int damage = 20;
	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
		anim = GetComponent<Animator> ();
		myHealth = GetComponent<BossHealth> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length <= 10) {
			int selectEnemy = Random.Range (0, EnemyList.numberEnemies);
			Instantiate (EnemyList.enemyList[selectEnemy],transform.position, Quaternion.identity);
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
