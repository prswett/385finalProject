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
	public float currentHealth;


	public GameObject item;
	public GameObject coin;
	public GameObject spellBook;
	public GameObject rareItem;
	public int numberHeld = 1;

	Renderer render;
	public bool increaseKill = true;

	//Gets all variables and components before initialization
	void Awake() {
		anim = GetComponent<Animator> ();
		healthbar = GameObject.Find ("BossHealth").GetComponent<Image> ();

		if (PlayerStatistics.level <= 5) {
			currentHealth = currentHealth * (PlayerStatistics.level) / 2f;
		} else if (PlayerStatistics.level <= 15) {
			currentHealth = currentHealth * (PlayerStatistics.level);
		} else {
			currentHealth = currentHealth * (PlayerStatistics.level) * 2;
		}

		maxHealth = currentHealth;
		target = GameObject.FindWithTag ("Boss").transform;

		render = GetComponent<Renderer> ();
	}

	void Start () {
		lastHit = 0;
	}

	// Checks if health is less than 0
	//Checks if it should turn off the blinking animation
	//Updates health bar
	void Update () {
		if (currentHealth <= 0) {
			spawnPhase spawn = GetComponent<spawnPhase> ();
			if (spawn != null) {
				spawn.spawn ();
			}

			Destroy (gameObject);
			Player temp = GameObject.FindWithTag ("Player").transform.GetComponent<Player>();
			if (increaseKill) {
				temp.killedBoss = true;
			}
			if (temp.expBoost) {
				PlayerStatistics.exp += 2 * (10 * PlayerStatistics.level / 2);
			} else {
				PlayerStatistics.exp += 10 * PlayerStatistics.level / 2;
			}
			for (int i = 0; i < Random.Range (5, 10); i++) {
				
				Instantiate (item, new Vector3 ((transform.position.x + Random.Range (-.3f, .3f)), transform.position.y, 0), 
					Quaternion.identity);
			}
			for (int i = 0; i < Random.Range (10, 20); i++) {
				Instantiate (coin, new Vector3 ((transform.position.x + Random.Range (-.3f, .3f)), transform.position.y, 0), 
					Quaternion.identity);
			}
			for (int i = 0; i < Random.Range (3, 7); i++) {
				Instantiate (rareItem, new Vector3 ((transform.position.x + Random.Range (-.3f, .3f)), transform.position.y, 0), 
					Quaternion.identity);
			}
			for (int i = 0; i < Random.Range (2, 5); i++) {
				Instantiate (spellBook, new Vector3 ((transform.position.x + Random.Range (-.3f, .3f)), transform.position.y, 0), 
					Quaternion.identity);
			}
		}

		healthbar.fillAmount = currentHealth / maxHealth;
	}

	public void takeDamage(int damage) {

		if (Time.time - lastHit >= 0.7 || lastHit == 0) {
			currentHealth -= damage;
			damageAnimation();
			Invoke ("damageAnimation", .1f);
			lastHit = Time.time;
		}
	}

	public void damageAnimation() {
		render.enabled = !render.enabled;
	}
}