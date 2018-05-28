using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingController : MonoBehaviour {
	public int baseHealing = 3;
	public int modifiedHealing = 0;

	public string description = "Heal yourself";
	// Use this for initialization
	void Start () {
		float healing = (modifiedHealing + PlayerStatistics.calcMD ()) / 2;
		if (PlayerStatistics.maxHealth - PlayerStatistics.health < healing) {
			PlayerStatistics.health = PlayerStatistics.maxHealth;
		} else {
			PlayerStatistics.health += healing;
		}
		Invoke ("Destroy", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = GameObject.FindGameObjectWithTag ("Player").transform.position;
	}

	void Destroy() {
		Destroy (gameObject);
	}
}
