using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	public int maxHealth = 5;
	public int currentHealth = 5;

	public double lastHit;
	public double currentTime;
	// Use this for initialization
	void Start () {
		lastHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime = Time.realtimeSinceStartup;
	}

	public void takeDamage(int damage) {
		if (currentTime - lastHit >= .35 || lastHit == 0) {
			currentHealth -= damage;
			if (currentHealth <= 0) {
				this.gameObject.SetActive (false);
			}
			lastHit = currentTime;
		}
	}
}
