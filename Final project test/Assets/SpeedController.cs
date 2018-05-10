using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour {
	public Player temp;

	// Use this for initialization
	void Start () {
		temp = GameObject.Find ("Player").GetComponent<Player> ();
		if (!temp.dupeSpeed) {
			temp.speed *= 1.5f;
			temp.jumpSpeed *= 1.1f;
			temp.dupeSpeed = true;
		}
		Invoke ("Destroy", 15f);
	}

	void Destroy() {
		if (!temp.dupeSpeed) {
			temp.speed /= 1.5f;
			temp.speed /= 1.1f;
		}
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = GameObject.FindGameObjectWithTag ("Player").transform.position;
	}
}
