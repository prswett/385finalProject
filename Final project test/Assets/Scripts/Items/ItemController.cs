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

	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		player = target.GetComponent<Player> ();
		spawnTime = Time.time;
		typeSet ();
	}

	void typeSet() {
		if (!setItem) {
			int randType = Random.Range (0, 10);
			if (randType < 4) {
				type = "Item";
			} else {
				type = "Potion";
			}

			if (type == "Item") {
				generateItem ();
			} else {
				generatePotion ();
			}
		}
	}

	void generateItem() {
		int roll = Random.Range (0, 10);
		if (roll < 3) {
			roll = Random.Range (0, 100);
			if (roll < 10 && rareItem) {
				ID = Random.Range (36, 60);
			} else if (roll < 15) {
				ID = Random.Range (60, 66);
			} else if (roll < 35) {
				ID = Random.Range (30, 36);
			} else {
				ID = Random.Range (6, 30);
			}
		} else {
			ID = Random.Range (0, 5);
		}
	}

	void generatePotion() {
		ID = Random.Range (0, 2);
	}
	
	// Update is called once per frame
	void Update () {
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
