using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownController : MonoBehaviour {
	public Transform target;
	public float playerX = 0;
	public float playerY = 0;

	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
		if (target.GetComponent<Player> ().door == true) {
			Transform door = GameObject.FindWithTag ("Door").transform;
			target.GetComponent<Player> ().door = false;
			target.GetComponent<Player> ().getSpawnLocation (door.position.x, door.position.y + .1f);
			target.GetComponent<Player> ().stageCount = 0;
		} else {
			target.GetComponent<Player> ().getSpawnLocation (playerX, playerY);
			target.GetComponent<Player> ().door = false;
			target.GetComponent<Player> ().stageCount = 0;
		}
	}

	void Update () {
		
	}
}
