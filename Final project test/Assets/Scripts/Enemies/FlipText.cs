using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipText : MonoBehaviour {
	public Transform target;
	public bool flipped = false;
	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
		if (target.position.x < transform.position.x) {
			flip ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x > target.position.x && !flipped) {
			flip ();
		}
		if (transform.position.x < target.position.x && flipped) {
			flip ();
		}
	}

	void flip() {
		flipped = !flipped;
		Vector3 charscale = transform.localScale;
		charscale.x *= -1;
		transform.localScale = charscale;
	}
}
