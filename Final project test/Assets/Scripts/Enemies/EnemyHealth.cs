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

	public bool tutorial = false;
	public float spawnTime;
	bool checkInvalid = false;

	public bool stay = false;
	void Awake() {
	}

	void Start () {
		//If maxhealth hasnt been initialized, default value of 100
		if (maxHealth == 0) {
			maxHealth = 100;
		}
		if (PlayerStatistics.level <= 10) {
			maxHealth = (maxHealth * PlayerStatistics.level) / 4f;
		} else if (PlayerStatistics.level <= 10) {
			maxHealth = (maxHealth * PlayerStatistics.level) / 2f;
		} else {
			maxHealth = (maxHealth * PlayerStatistics.level);
		}
		lastHit = Time.time;
		target = GameObject.FindWithTag ("Player").transform;
		parent = transform.parent.gameObject;
		parentController = parent.GetComponent<EnemyController> ();

		currentHealth = maxHealth;
		control = GetComponentInChildren<TextMesh> ();
		control.text = monsterName;
		render = parent.GetComponent<Renderer> ();

		current = transform.position;
	}

	void Update () {
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
			if (transform.position.x - target.position.x < 0) {
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
				if (Random.Range (0, 10) < 5 + (int)(PlayerStatistics.luk / 50)) {
					dropCoin ();
				}
				int dropRate = Random.Range (0, 100);
				if (dropRate < 25 + (int)(PlayerStatistics.luk / 50)) {
					int roll = Random.Range (0, 100);
					if (roll < 15 + (int)(PlayerStatistics.luk / 100)) {
						dropRareItem ();
					} else {
						dropItem ();
					}
				}
				dropRate = Random.Range (0, 100);
				if (dropRate < 5 + (int)(PlayerStatistics.luk / 50)) {
					dropSpell ();
				}
				Player killCount = target.GetComponent<Player> ();
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
					if (PlayerStatistics.level <= 5) {
						PlayerStatistics.takeDamage (1 + PlayerStatistics.level / 7);
					} else if (PlayerStatistics.level <= 10) {
						PlayerStatistics.takeDamage (1 + PlayerStatistics.level / 4);
					} else {
						PlayerStatistics.takeDamage (1 + PlayerStatistics.level / 2);
					}
			}
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (!tutorial) {
			if (other.gameObject.CompareTag ("Player")) {
					if (PlayerStatistics.level <= 5) {
						PlayerStatistics.takeDamage (1 + PlayerStatistics.level / 7);
					} else if (PlayerStatistics.level <= 10) {
						PlayerStatistics.takeDamage (1 + PlayerStatistics.level / 4);
					} else {
						PlayerStatistics.takeDamage (1 + PlayerStatistics.level / 2);
					}
			}
		}
	}
}