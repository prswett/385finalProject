using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownController : MonoBehaviour {
	public Transform target;
	public float playerX = 0;
	public float playerY = 0;

	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
		target.GetComponent<Player> ().getSpawnLocation (playerX, playerY);
	}

	void Update () {
		
	}
}
