using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpThrough : MonoBehaviour {
	public Transform target;
	public Player player;

	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
		player = target.GetComponent<Player> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay2D (Collision2D other) {
		if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space)){
			Jumper();
			playerJumpDown ();
			Invoke("Jumper", 0.5f);
			Invoke ("playerJumpDown", 0.2f);
		}
	}

	public void Jumper()
	{
		gameObject.GetComponent<Collider2D>().enabled = !gameObject.GetComponent<Collider2D>().enabled;
	}

	public void playerJumpDown() {
		player.jumpingDown ();
	}
}
