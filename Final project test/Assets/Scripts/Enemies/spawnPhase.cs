using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPhase : MonoBehaviour {

	public GameObject phase;
	public float x;
	public float y;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void spawn() {
		Instantiate(phase, new Vector3(x, y, 0), Quaternion.identity);
	}
}
