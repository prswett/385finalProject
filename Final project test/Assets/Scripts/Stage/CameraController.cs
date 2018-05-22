using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	private Transform target;
	private Vector3 offset;	
	// Use this for initialization
	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
	}

	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
		transform.position = new Vector3 (target.position.x, target.position.y, -10);
		offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate () 
	{
		if (target != null) {
			transform.position = target.position + offset;
		}
	}
}
