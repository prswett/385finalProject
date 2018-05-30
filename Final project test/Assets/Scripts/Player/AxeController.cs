using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour {
	public int baseDamage = 30;
	public int damage = 30;
	void Start () {

	}

	void Update () {
		damage = baseDamage + (int)PlayerStatistics.calcPDAxe();
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
