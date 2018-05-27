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

	public BossHealth myHealth;
	int damage = 10;
	public float selfHeal;
	public bool selfHealing = false;

	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
		anim = GetComponent<Animator> ();
		myHealth = GetComponent<BossHealth> ();
	}
		
	// Use this for initialization
	void Start () {
		flip ();
	}
	
	// Update is called once per frame
	void Update () {
		if (myHealth.currentHealth / myHealth.maxHealth <= .5f) {
			speed = 6;
			damage = 20;
			selfHealing = true;
		}
		if (selfHealing) {
			if (Time.time - selfHeal > 2f) {
				myHealth.currentHealth += 25 + PlayerStatistics.level;
				selfHeal = Time.time;
			}
		}
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
			PlayerStatistics.takeDamage(damage + (PlayerStatistics.level / 3));
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerStatistics.takeDamage(damage + (PlayerStatistics.level / 3));
		}
	}

	void flip() {
		Vector3 charscale = transform.localScale;
		charscale.x *= -1;
		transform.localScale = charscale;
	}
}
