using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialItemController : MonoBehaviour {

	public int ID;
	//Potion or Item
	public string type;
	public bool setItem = false;

	public Transform target;
	public PlayerTutorial player;

	public bool location = false;
	float spawnTime;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		player = target.GetComponent<PlayerTutorial> ();
		spawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (!location) {
			transform.position = target.position;
		}
		if (Time.time - spawnTime > 10) {
			transform.position = target.position;
		}
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

		if (other.gameObject.CompareTag ("outofbounds")) {
			location = true;
		}
	}
}
