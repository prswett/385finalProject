using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopStage : MonoBehaviour {
	public Transform target;
	public float playerX;
	public float playerY;

	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
		target.GetComponent<Player> ().getSpawnLocation (playerX, playerY);
	}
		
	void Update () {

	}
}
