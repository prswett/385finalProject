﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerController : MonoBehaviour {
	public int baseDamage = 5;
	public int damage = 5;
	void Start () {

	}

	void Update () {
		damage = baseDamage + (int)PlayerStatistics.calcPDDagger ();
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
