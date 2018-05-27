using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	private Transform target;
	private Vector3 offset;

	public float posX;
	public float negX;
	public float negY;
	public float posY;
	// Use this for initialization
	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
	}

	void Start () {
		transform.position = target.position;
		if (transform.position.x < negX) {
			transform.position = new Vector3 (negX, transform.position.y, -10);
		} else if (transform.position.x > posX) {
			transform.position = new Vector3 (posX, transform.position.y, -10);
		}

		if (transform.position.y < negY) {
			transform.position = new Vector3 (transform.position.x, negY, -10);
		} else if (transform.position.y > posY) {
			transform.position = new Vector3 (transform.position.x, posY, -10);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void LateUpdate () 
	{
		if (target != null) {
			if ((target.position.x >= transform.position.x || target.position.x <= transform.position.x) && target.position.x >= negX && target.position.x <= posX) {
				transform.position = new Vector3 (target.position.x, transform.position.y, -10);
			}
			if ((target.position.y >= transform.position.y || target.position.y <= transform.position.y) && target.position.y >= negY && target.position.y <= posY) {
				transform.position = new Vector3 (transform.position.x, target.position.y, -10);
			}
		}
	}
}
