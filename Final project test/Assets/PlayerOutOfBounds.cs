using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutOfBounds : MonoBehaviour {

	public GameObject outofbounds;
	public BoxCollider2D collider2d;
	public BoxCollider2D myCollider2d;
	public Vector2 size;

	void Awake() {
		outofbounds = GameObject.FindGameObjectWithTag ("outofbounds");
		collider2d = outofbounds.GetComponent<BoxCollider2D> ();
		size = collider2d.size;
	}

	// Use this for initialization
	void Start () {
		transform.position = outofbounds.transform.position;
		myCollider2d = GetComponent<BoxCollider2D> ();
		myCollider2d.size = new Vector2 (size.x + 1, size.y + 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
