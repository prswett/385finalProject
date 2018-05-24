using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBullet : MonoBehaviour {
	public GameObject bullet;

	// Use this for initialization
	void Start () {
		Invoke ("spawnBullet", 3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnBullet() {
		Instantiate (bullet, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
