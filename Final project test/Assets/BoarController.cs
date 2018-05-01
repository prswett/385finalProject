using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarController : MonoBehaviour {

	//Awake variables
	public Transform target;
	public Animator anim;
	//private Transform myself;

	public float right;
	public float left;
	public int speed = 3;
	public bool running = false;
	int count = 1;
	public bool charged = false;

	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
		anim = GetComponent<Animator> ();
		//myself = GameObject.FindWithTag("Boss").transform;
	}
		
	// Use this for initialization
	void Start () {
		flip ();
	}
	
	// Update is called once per frame
	void Update () {

		if (running == false) {
			anim.SetBool ("Charging", true);
			if (!charged) {
				Invoke ("startRunning", 3f);
				charged = true;
			}
		}
		if (transform.position.x > left && count == 1 && running == true) {
			transform.position += Vector3.left * speed * Time.deltaTime;
			if (transform.position.x < left) {
				anim.SetBool ("Running", false);
				flip ();
				count++;
				running = false;
				charged = false;
			}
		} else if (transform.position.x < right && count == 2 && running == true) {
			transform.position += Vector3.right * speed * Time.deltaTime;
			if (transform.position.x > right) {
				anim.SetBool ("Running", false);
				flip ();
				count--;
				running = false;
				charged = false;
			}
		} else {

		}

	}

	void startRunning() {
		anim.SetBool ("Charging", false);
		anim.SetBool ("Running", true);
		running = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerStatistics.takeDamage(5);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerStatistics.takeDamage(5);
		}
	}

	void flip() {
		Vector3 charscale = transform.localScale;
		charscale.x *= -1;
		transform.localScale = charscale;
	}
}
