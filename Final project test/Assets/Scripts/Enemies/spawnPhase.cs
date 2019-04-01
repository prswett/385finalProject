using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPhase : MonoBehaviour {

	public GameObject phase;
	public float x;
	public float y;

	public bool boss = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void spawn() {
		if (boss) {
			Instantiate (phase, new Vector3 (transform.position.x, y, 0), Quaternion.identity);
		} else {
			Instantiate (phase, new Vector3 (x, y, 0), Quaternion.identity);
		}
	}
}
