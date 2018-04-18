using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * This is the BossHealth class, whose main role is to manage the hp of
 * bosses and related functions. It controls when the boss will switch
 * animations and also contains the take damage function. It links
 * the current hp with the boss health bar.
 **/

public class BossHealth : MonoBehaviour {

	//Awake variables
	public Animator anim;
	Image healthbar;
	public float maxHealth;
	public Transform target;
	//Start variables
	public float lastHit;
	//Update variables
	public float currentHealth = 100;
	private float hitAnimationDuration = .6f;

	//Gets all variables and components before initialization
	void Awake() {
		anim = GetComponent<Animator> ();
		healthbar = GameObject.Find ("BossHealth").GetComponent<Image> ();
		maxHealth = currentHealth;
		target = GameObject.FindWithTag ("Boss").transform;
	}

	void Start () {
		lastHit = 0;
	}

	// Checks if health is less than 0
	//Checks if it should turn off the blinking animation
	//Updates health bar
	void Update () {
		if (currentHealth <= 0) {
			Destroy (gameObject);
			Player temp = GameObject.FindWithTag ("Player").transform.GetComponent<Player>();
			temp.killedBoss = true;
		}

		healthbar.fillAmount = currentHealth / maxHealth;


		if (Time.time - lastHit >= hitAnimationDuration) {
			anim.SetBool ("TookDamage", false);
		}
	}

	public void takeDamage(int damage) {

		if (Time.time - lastHit >= 0.5 || lastHit == 0) {
			currentHealth -= damage;
			anim.SetBool ("TookDamage", true);
			lastHit = Time.time;
		}


	}
}
