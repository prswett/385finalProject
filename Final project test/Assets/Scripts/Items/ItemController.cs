using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

	public int ID;
	//Potion or Item
	public string type;
	public bool setItem = false;

	public Transform target;
	public Player player;

	public bool location = false;
	float spawnTime;

	public bool rareItem = false;
	public bool set = false;

	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		player = target.GetComponent<Player> ();

		typeSet ();
	}

	void typeSet() {
		if (!setItem) {
			int randType = Random.Range (0, 10);
			if (randType < 4) {
				type = "Item";
			} else if (randType < 8) {
				type = "Potion";
			} else {
				Destroy (gameObject);
			}

			if (type == "Item") {
				if (PlayerStatistics.level <= 3) {
					generateBeginnerItem ();
				} else if (PlayerStatistics.level <= 8) {
					generateIntermediateItem ();
				} else if (PlayerStatistics.level <= 12) {
					generateIntermediateItemv2 ();
				} else if (PlayerStatistics.level <= 16) {
					generateAdvancedItem ();
				} else if (PlayerStatistics.level <= 22) {
					generateAdvancedItemv2 ();
				} else {
					generateGodItem ();
				}
			} else {
				generatePotion ();
			}
		}
	}

	void generateBeginnerItem() {
		ID = Random.Range (0, 12);
	}

	void generateIntermediateItem() {
		int roll = Random.Range (0, 100);
		if (roll < 30) {
			ID = Random.Range (12, 36);
		} else {
			ID = Random.Range (0, 36);
		}
	}

	void generateIntermediateItemv2() {
		int roll = Random.Range (0, 100);
		if (roll < 30) {
			ID = Random.Range (36, 67);
		} else if (roll < 60) {
			ID = Random.Range (12, 67);
		} else {
			ID = Random.Range (0, 67);
		}
	}

	void generateAdvancedItem() {
		int roll = Random.Range (0, 100);
		if (roll < 20) {
			ID = Random.Range (67, 91);
		} else if (roll < 50) {
			ID = Random.Range (36, 91);
		} else if (roll < 80) {
			ID = Random.Range (12, 91);
		} else {
			ID = Random.Range (0, 91);
		}
	}

	void generateAdvancedItemv2() {
		int roll = Random.Range (0, 100);
		if (roll < 30) {
			ID = Random.Range (91, 109);
		} else if (roll < 50) {
			ID = Random.Range (67, 109);
		} else if (roll < 80) {
			ID = Random.Range (36, 109);
		} else {
			ID = Random.Range (12, 109);
		}
	}
		
	void generateGodItem() {
		if (rareItem) {
			int roll = Random.Range (0, 100);
			if (roll < 1) {
				ID = Random.Range (109, 133);
			} else if (roll < 10) {
				ID = Random.Range (133, 139);
			} else {
				generateAdvancedItemv2 ();
			}
		} else {
			generateAdvancedItemv2 ();
		}
	}

	void generatePotion() {
		int potionSize = Random.Range (0, 10);
		if (potionSize < 1) {
			int hm = Random.Range (0, 10);
			if (hm < 3) {
				ID = 7;
			} else {
				ID = 6;
			}
		} else if (potionSize < 4) {
			int hm = Random.Range (0, 10);
			if (hm < 3) {
				ID = 5;
			} else {
				ID = 4;
			}
		} else {
			int hm = Random.Range (0, 10);
			if (hm < 3) {
				ID = 1;
			} else {
				ID = 0;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!set) {
			spawnTime = Time.time;
			set = true;
		}
		if (!location) {
			transform.position = target.position;
		}
		if (Time.time - spawnTime > 10) {
			transform.position = target.position;
			spawnTime = Time.time;
		}
	}

	void pickUP() {
		if (type == "Potion") {
			if (player.pInv.checkEmpty()) {
				player.addPotion (ID);
				Destroy (transform.parent.gameObject);
			}
		} else {
			if (player.inv.checkEmpty ()) {
				player.addItem (ID);
				Destroy (transform.parent.gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			pickUP ();
		}

		if (other.gameObject.CompareTag ("outofbounds")) {
			location = true;
		}
	}
	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			pickUP ();
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		
	}
}
