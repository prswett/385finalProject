using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
	private Transform target;
	private Vector3 offset;	
	// Use this for initialization
	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
	}

	void Start () {
		offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate () 
	{
		transform.position = target.position + offset;
	}
}
