using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipText : MonoBehaviour {
	public Transform target;
	public bool flipped = false;
	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x > target.position.x && !flipped) {
			transform.position = new Vector3 (transform.position.x - .3f, transform.position.y, 0);
			flip ();
		}
		if (transform.position.x < target.position.x && flipped) {
			transform.position = new Vector3 (transform.position.x + .3f, transform.position.y, 0);
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
