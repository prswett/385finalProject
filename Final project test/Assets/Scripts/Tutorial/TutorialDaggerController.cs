using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDaggerController : MonoBehaviour {

	public int damage = 1;
	void Start () {

	}

	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			TutorialEnemyHealth health = other.GetComponent<TutorialEnemyHealth> ();
			health.takeDamage (damage);
		}

		if (other.gameObject.CompareTag ("Boss")) {
			BossHealth health = other.GetComponent<BossHealth> ();
			health.takeDamage (damage);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			TutorialEnemyHealth health = other.GetComponent<TutorialEnemyHealth> ();
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
