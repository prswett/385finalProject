using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			float damage = PlayerStatistics.maxHealth / 200f;
			PlayerStatistics.takeDamage (damage);
			PlayerStatistics.takeDefDamage (damage);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			float damage = PlayerStatistics.maxHealth / 200f;
			PlayerStatistics.takeDamage (damage);
			PlayerStatistics.takeDefDamage (damage);
		}
	}
}
