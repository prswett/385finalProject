using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
	public float maxHealth;
	public float currentHealth;
	public Transform target;
	public float lastHit;
	public GameObject parent;
	public EnemyController parentController;
	public float fill;

	public Image healthbar;
	//Drops
	public GameObject coin;

	void Awake() {
	}

	void Start () {
		//If maxhealth hasnt been initialized, default value of 100
		if (maxHealth == 0) {
			maxHealth = 100;
		}
		lastHit = 0;
		target = GameObject.FindWithTag ("Player").transform;
		parent = transform.parent.gameObject;
		parentController = parent.GetComponent<EnemyController> ();

		currentHealth = maxHealth;

	}

	void Update () {
		healthbar.fillAmount = currentHealth / maxHealth;
		if (currentHealth <= 0) {
			dropCoin ();
			parentController.destroy();
		}
	}

	//Takes in an int and decreases player health by an amount
	//Records previous time since last hit and doesn't inflict damage
	//unless time since last hit is past the point
	public void takeDamage(int damage) {
		

		//if (Time.time - lastHit >= 0.1 || lastHit == 0) {
			if (transform.position.x - target.position.x < 0) {
				parentController.moveLeft ();
			} else {
				parentController.moveRight ();
			}
			currentHealth -= damage;
			if (currentHealth <= 0) {
				Player killCount = target.GetComponent<Player> ();
				killCount.killCount++;
				if (killCount.exp < 200) {
					killCount.localPlayer.exp += 5;
				}
			}
			lastHit = Time.time;
		//}
	}

	public void dropCoin() {
		Instantiate (coin, transform.position, Quaternion.identity);
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Player health = other.GetComponent<Player> ();
			health.takeDamage (1);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Player health = other.GetComponent<Player> ();
			health.takeDamage (1);
		}
	}
		
}
