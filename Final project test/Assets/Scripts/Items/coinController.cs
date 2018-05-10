using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour {
	public bool location = false;

	public Transform target;
	public Player player;

	float spawnTime;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		player = target.GetComponent<Player> ();
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
		if (player != null) {
			if (other.gameObject.CompareTag ("Player")) {
				if (player.goldBoost) {
					PlayerStatistics.coins += 3;
				} else {
					PlayerStatistics.coins++;
				}
				Destroy (gameObject);
			}
		} else {
			Destroy (gameObject);
		}

		if (other.gameObject.CompareTag ("outofbounds")) {
			location = true;
		}
	}
}
