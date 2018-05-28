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
	public ItemPickupController itempickup;
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		player = target.GetComponent<Player> ();
		itempickup = GameObject.Find ("ItemPickup").GetComponent<ItemPickupController> ();
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
				Destroy (transform.parent.gameObject);
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
			ID = Random.Range (36, 66);
		} else if (roll < 60) {
			ID = Random.Range (12, 66);
		} else {
			ID = Random.Range (0, 66);
		}
	}

	void generateAdvancedItem() {
		int roll = Random.Range (0, 100);
		if (roll < 20) {
			ID = Random.Range (66, 90);
		} else if (roll < 50) {
			ID = Random.Range (36, 90);
		} else if (roll < 80) {
			ID = Random.Range (12, 90);
		} else {
			ID = Random.Range (0, 90);
		}
	}

	void generateAdvancedItemv2() {
		int roll = Random.Range (0, 100);
		if (roll < 30) {
			ID = Random.Range (90, 108);
		} else if (roll < 50) {
			ID = Random.Range (66, 108);
		} else if (roll < 80) {
			ID = Random.Range (36, 108);
		} else {
			ID = Random.Range (12, 108);
		}
	}
		
	void generateGodItem() {
		if (rareItem) {
			int roll = Random.Range (0, 100);
			if (roll < 1) {
				ID = Random.Range (108, 132);
			} else if (roll < 10) {
				ID = Random.Range (132, 137);
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
			transform.parent.transform.position = target.position;
		}
		if (Time.time - spawnTime > 3f) {
			transform.parent.transform.position = target.position;
			spawnTime = Time.time;
		}
	}

	void pickUP() {
		if (type == "Potion") {
			if (player.pInv.checkEmpty ()) {
				player.addPotion (ID);
				itempickup.showItem ("Picked up: " + player.pInv.database.FetchItemName (ID));
				Destroy (transform.parent.gameObject);
			} else {
				itempickup.showItem ("Potion Inventory Full");
			}
		} else {
			if (player.inv.checkEmpty ()) {
				player.addItem (ID);
				itempickup.showItem ("Picked up: " + player.inv.database.FetchItemName (ID));
				Destroy (transform.parent.gameObject);
			} else {
				itempickup.showItem ("Item Inventory Full");
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
