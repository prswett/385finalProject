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
			if (PlayerStatistics.level <= 5) {
				PlayerStatistics.takeDamage (1 + PlayerStatistics.level / 7);
			} else if (PlayerStatistics.level <= 10) {
				PlayerStatistics.takeDamage (1 + PlayerStatistics.level / 4);
			} else {
				PlayerStatistics.takeDamage (1 + PlayerStatistics.level / 2);
			}
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			if (PlayerStatistics.level <= 5) {
				PlayerStatistics.takeDamage (1 + PlayerStatistics.level / 7);
			} else if (PlayerStatistics.level <= 10) {
				PlayerStatistics.takeDamage (1 + PlayerStatistics.level / 4);
			} else {
				PlayerStatistics.takeDamage (1 + PlayerStatistics.level / 2);
			}
		}
	}
}
