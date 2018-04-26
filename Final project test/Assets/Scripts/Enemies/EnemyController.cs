using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	void Start () {
	
	}

	void Update () {

	}

	public void moveLeft() {
		transform.position += Vector3.left * 0.05f;
	}

	public void moveRight() {
		transform.position += Vector3.right * 0.05f;
	}

	public void destroy() {
		Destroy (gameObject);
	}

}