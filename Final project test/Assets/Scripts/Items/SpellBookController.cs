using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBookController : MonoBehaviour {
	public int ID;

	public string type;
	public bool setItem = false;

	public Transform target;
	public Player player;

	public bool location = false;
	float spawnTime;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		player = target.GetComponent<Player> ();
		spawnTime = Time.time;
		setId ();
	}

	void setId() {
		if (!setItem) {
			int spellCount = player.spells.numberOfSpells;
			ID = Random.Range (0, spellCount);
		}
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
			setId ();
			player.addSpell (ID);
			Destroy (transform.parent.gameObject);
		}

		if (other.gameObject.CompareTag ("outofbounds")) {
			location = true;
		}
	}
}
