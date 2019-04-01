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
	public Vector3 current;

	Player killCount;

	public bool tutorial = false;
	public float spawnTime;
	bool checkInvalid = false;

	public bool stay = false;
	void Awake() {
	}

	void Start () {
		//If maxhealth hasnt been initialized, default value of 100
		maxHealth = 1000;
		if (PlayerStatistics.level <= 10) {
			maxHealth = (maxHealth * PlayerStatistics.level) / 4f;
		} else if (PlayerStatistics.level <= 10) {
			maxHealth = (maxHealth * PlayerStatistics.level) / 2f;
		} else {
			maxHealth = (maxHealth * PlayerStatistics.level);
		}
		lastHit = Time.time;
		target = GameObject.FindWithTag ("Player").transform;
		killCount = target.GetComponent<Player> ();
		parent = transform.parent.gameObject;
		parentController = parent.GetComponent<EnemyController> ();

		currentHealth = maxHealth;
		control = GetComponentInChildren<TextMesh> ();
		render = parent.GetComponent<Renderer> ();

		current = transform.position;
	}

	void Update () {
		if (parentController.active) {
			control.text = monsterName;
		}
		if (spawnTime == 0) {
			spawnTime = Time.time;
		}
		if (Mathf.Abs (transform.position.x - current.x) < .2f) {
			stay = true;
		} else {
			stay = false;
		}

		if (Time.time - spawnTime > 10 && stay && !checkInvalid) {
			parentController.destroy();
		}
		if (Time.time - spawnTime > 10) {
			checkInvalid = true;
		}
		healthbar.fillAmount = currentHealth / maxHealth;
	}

	//Takes in an int and decreases player health by an amount
	//Records previous time since last hit and doesn't inflict damage
	//unless time since last hit is past the point
	public void takeDamage(int damage) {
		if (parentController.active == true) {
			DamageNumber temp = damageNumber.GetComponent<DamageNumber> ();
			temp.setNumber (damage);
			Instantiate(temp, new Vector3(transform.position.x, healthbar.transform.position.y + .2f, 0), Quaternion.identity);
			if (parent.transform.position.x < killCount.transform.position.x) {
				parentController.moveLeft ();
			} else {
				parentController.moveRight ();
			}
			currentHealth -= damage;
			if (Time.time - lastHit > 0.5) {
				damageAnimation ();
				Invoke ("damageAnimation", .2f);
				lastHit = Time.time;
			}

			if (currentHealth <= 0) {
				int dropBoost = (int)(PlayerStatistics.luk / 50);
				if (dropBoost >= 15) {
					dropBoost = 15;
				}
				if (Random.Range (0, 100) < 50) {
					dropCoin ();
				}
				int dropRate = Random.Range (0, 100);
				if (dropRate < 25 + dropBoost) {
					int roll = Random.Range (0, 100);
					if (roll < 15 + dropBoost) {
						dropRareItem ();
					} else {
						dropItem ();
					}
				}
				dropRate = Random.Range (0, 100);
				if (dropRate < 10 + dropBoost) {
					dropSpell ();
				}

				killCount.killCount++;
				if (killCount.expBoost) {
					if (PlayerStatistics.level <= 10) {
						PlayerStatistics.exp += 2 * 3 * PlayerStatistics.level / 4;
					} else {
						PlayerStatistics.exp += 2 * 3 * PlayerStatistics.level / 2;
					}
				} else {
					if (PlayerStatistics.level <= 10) {
						PlayerStatistics.exp += 3 * PlayerStatistics.level / 4;
					} else {
						PlayerStatistics.exp += 3 * PlayerStatistics.level / 2;
					}
				}
				parentController.destroy();
			}
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
		if (!tutorial) {
			if (other.gameObject.CompareTag ("Player")) {
				float damage = PlayerStatistics.maxHealth / 200f;
				PlayerStatistics.takeDamage (damage);
				PlayerStatistics.takeDefDamage (damage);
			}
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (!tutorial) {
			if (other.gameObject.CompareTag ("Player")) {
				float damage = PlayerStatistics.maxHealth / 200f;
				PlayerStatistics.takeDamage (damage);
				PlayerStatistics.takeDefDamage (damage);
			}
		}
	}
}