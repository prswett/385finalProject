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
	public string monsterName;

	public Image healthbar;
	//Drops
	public GameObject coin;
	public GameObject item;
	public GameObject spell;
	public GameObject rareItem;

	public TextMesh control;
	public GameObject damageNumber;
	Renderer render;


	void Awake() {
	}

	void Start () {
		//If maxhealth hasnt been initialized, default value of 100
		if (maxHealth == 0) {
			maxHealth = 100;
		}
		maxHealth = (maxHealth * PlayerStatistics.level) / 2f;
		lastHit = 0;
		target = GameObject.FindWithTag ("Player").transform;
		parent = transform.parent.gameObject;
		parentController = parent.GetComponent<EnemyController> ();

		currentHealth = maxHealth;
		control = GetComponentInChildren<TextMesh> ();
		control.text = monsterName;
		render = parent.GetComponent<Renderer> ();
	}

	void Update () {
		healthbar.fillAmount = currentHealth / maxHealth;
		if (currentHealth <= 0) {
			dropCoin ();
			int dropRate = Random.Range (0, 10);
			if (dropRate < 4) {
				int roll = Random.Range (0, 10);
				if (roll < 2) {
					dropRareItem ();
				} else {
					dropItem ();
				}
			}
			dropRate = Random.Range (0, 10);
			if (dropRate < 1) {
				dropSpell ();
			}
			Player killCount = target.GetComponent<Player> ();
			killCount.killCount++;
			if (killCount.expBoost) {
				PlayerStatistics.exp += 2 * (5 * PlayerStatistics.level / 4);
			} else {
				PlayerStatistics.exp += 5 * PlayerStatistics.level / 4;
			}
			parentController.destroy();
		}
	}

	//Takes in an int and decreases player health by an amount
	//Records previous time since last hit and doesn't inflict damage
	//unless time since last hit is past the point
	public void takeDamage(int damage) {
		if (parentController.active == true) {
			DamageNumber temp = damageNumber.GetComponent<DamageNumber> ();
			temp.setNumber (damage);
			Instantiate(temp, new Vector3(transform.position.x, healthbar.transform.position.y + .2f, 0), Quaternion.identity);
			if (transform.position.x - target.position.x < 0) {
				parentController.moveLeft ();
			} else {
				parentController.moveRight ();
			}
			currentHealth -= damage;
			if (Time.time - lastHit > 0.5) {
				damageAnimation ();
				Invoke ("damageAnimation", .1f);
			}
			lastHit = Time.time;
		}
	}

	public void damageAnimation() {
		render.enabled = !render.enabled;
	}

	public void dropCoin() {
		Instantiate (coin, transform.position, Quaternion.identity);
	}

	public void dropItem() {
		Instantiate (item, transform.position, Quaternion.identity);
	}

	public void dropSpell() {
		Instantiate (spell, transform.position, Quaternion.identity);
	}

	public void dropRareItem() {
		Instantiate (rareItem, transform.position, Quaternion.identity);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			if (parentController.active == true) {
				PlayerStatistics.takeDamage (1 + PlayerStatistics.level / 2);
			}
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			if (parentController.active == true) {
				PlayerStatistics.takeDamage (1 + PlayerStatistics.level / 2);
			}
		}
	}
}