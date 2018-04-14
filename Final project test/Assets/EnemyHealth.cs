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

	//Takes in an int and decreases player health by an amount
	//Records previous time since last hit and doesn't inflict damage
	//unless time since last hit is past the point
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
