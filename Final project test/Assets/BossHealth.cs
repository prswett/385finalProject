using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {
	public float maxHealth;
	public float currentHealth = 100;
	public float lastHit;
	public Transform target;

	public Animator anim;
	private float hitAnimationDuration = .6f;
	Image healthbar;

	void Awake() {
		anim = GetComponent<Animator> ();
		healthbar = GameObject.Find ("BossHealth").GetComponent<Image> ();
		maxHealth = currentHealth;
		target = GameObject.FindWithTag ("Boss").transform;
	}
	// Use this for initialization
	void Start () {
		lastHit = 0;
	}

	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			Destroy (gameObject);
		}

		healthbar.fillAmount = currentHealth / maxHealth;


		if (Time.time - lastHit >= hitAnimationDuration) {
			anim.SetBool ("TookDamage", false);
		}
	}

	public void takeDamage(int damage) {

		if (Time.time - lastHit >= 0.5 || lastHit == 0) {
			currentHealth -= damage;
			anim.SetBool ("TookDamage", true);
			lastHit = Time.time;
		}


	}
}
