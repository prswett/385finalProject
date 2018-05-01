using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

	public int ID;
	//Potion or Item
	public string type;

	public Transform target;
	public Player player;
	// Use this for initialization
	void Awake() {
		
	}

	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		player = target.GetComponent<Player> ();

		int randType = Random.Range (0, 10);
		if (randType <= 3) {
			type = "Item";
		} else {
			type = "Potion";
		}

		if (type == "Item") {
			ID = Random.Range (0, 5);
		} else {
			ID = Random.Range (0, 1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			if (type == "Potion") {
				player.addPotion (ID);
			} else {
				player.addItem (ID);
			}
			Destroy (gameObject);
		}
	}
}
