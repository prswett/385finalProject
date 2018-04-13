using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	public int maxHealth = 5;
	public int currentHealth = 5;
	public Transform target;
	public float lastHit;


	// Use this for initialization
	void Start () {
		lastHit = 0;
		target = GameObject.FindWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void takeDamage(int damage) {
		if (Time.time - lastHit >= .35 || lastHit == 0) {
			currentHealth -= damage;
			if (currentHealth <= 0) {
				this.gameObject.SetActive (false);
				PlayerController killCount = target.GetComponent<PlayerController> ();
				killCount.killCount++;
			}
			lastHit = Time.time;
		}
	}
}
