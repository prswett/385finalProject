using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour {

	public int baseDamage = 15;
	public int damage = 15;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		damage = baseDamage + (int)PlayerStatistics.calcPDSword ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("EnemyHealth")) {
			EnemyHealth health = other.GetComponent<EnemyHealth> ();
			health.takeDamage (damage);
		}

		if (other.gameObject.CompareTag ("Boss")) {
			BossHealth health = other.GetComponent<BossHealth> ();
			health.takeDamage (damage);
		}
			
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag ("EnemyHealth")) {
			EnemyHealth health = other.GetComponent<EnemyHealth> ();
			health.takeDamage (damage);
		}

		if (other.gameObject.CompareTag ("Boss")) {
			BossHealth health = other.GetComponent<BossHealth> ();
			health.takeDamage (damage);
		}
	}

	public void changeDamage(int input) {
		damage = input;
	}
}
