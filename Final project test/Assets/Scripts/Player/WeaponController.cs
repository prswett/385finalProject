using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public int damage = 1;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			EnemyHealth health = other.GetComponent<EnemyHealth> ();
			health.takeDamage (5);
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
