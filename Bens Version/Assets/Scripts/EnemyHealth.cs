using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	public int maxHealth;
	public int currentHealth;
	public Transform target;
	public float lastHit;

	public float spawnTime;
	void Start () {
		spawnTime = Time.time;
		//If maxhealth hasnt been initialized, default value of 100
		if (maxHealth == 0) {
			maxHealth = 100;
		}
		lastHit = 0;
		target = GameObject.FindWithTag ("Player").transform;
		currentHealth = maxHealth;
	}

	void Update () {
		if (currentHealth <= 0) {
			Destroy (gameObject);
		}
	}

	//Takes in an int and decreases player health by an amount
	//Records previous time since last hit and doesn't inflict damage
	//unless time since last hit is past the point
	public void takeDamage(int damage) {
		if (transform.position.x - target.position.x < 0) {
			transform.position += Vector3.left * 0.05f;
		} else {
			transform.position += Vector3.right * 0.05f;
		}

		if (Time.time - lastHit >= 0.1 || lastHit == 0) {
			currentHealth -= damage;
			if (currentHealth <= 0) {
				Player killCount = target.GetComponent<Player> ();
				killCount.killCount++;
			}
			lastHit = Time.time;
		}
	}
}
