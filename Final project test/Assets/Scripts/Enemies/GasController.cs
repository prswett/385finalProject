using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasController : MonoBehaviour {
	public float gasTime = 4f;
	public bool inGas = false;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, gasTime);
	}
	
	// Update is called once per frame
	void Update () {
		if (inGas) {
			float damage = PlayerStatistics.maxHealth / 200f;
			PlayerStatistics.takeDamage (damage);
			PlayerStatistics.takeDefDamage (damage);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			inGas = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			inGas = false;
		}
	}
}
