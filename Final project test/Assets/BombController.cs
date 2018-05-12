using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {
	public float velocityX;
	public float velocityY;
	Rigidbody2D rb2d;

	public bool hit = false;
	public Animator anim;

	public int baseDamage = 150;
	public int modifiedDamage = 0;
	public float start;
	// Use this for initialization
	void Start () {
		rb2d = this.GetComponent<Rigidbody2D> ();
		start = Time.time;
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (!hit) {
			rb2d.velocity = new Vector2 (velocityX, velocityY);
		}

	}

	public void setVelocity(float x, float y) {
		velocityX = x;
		velocityY = y;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Ground") || other.gameObject.CompareTag ("EnemyHealth") || other.gameObject.CompareTag ("Boss")) {
			rb2d.velocity = new Vector2 (0, 0);
			hit = true;
			anim.SetBool ("Exploding", true);
			Invoke("Destroy", .3f);
		}

		if (other.gameObject.CompareTag ("EnemyHealth")) {
			EnemyHealth health = other.GetComponent<EnemyHealth> ();
			health.takeDamage (modifiedDamage + (int)PlayerStatistics.calcMD());
		}
		if (other.gameObject.CompareTag ("Boss")) {
			BossHealth health = other.GetComponent<BossHealth> ();
			health.takeDamage (modifiedDamage + (int)PlayerStatistics.calcMD());
		} 
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag ("EnemyHealth")) {
			EnemyHealth health = other.GetComponent<EnemyHealth> ();
			health.takeDamage (modifiedDamage + (int)PlayerStatistics.calcMD());
		}
		if (other.gameObject.CompareTag ("Boss")) {
			BossHealth health = other.GetComponent<BossHealth> ();
			health.takeDamage (modifiedDamage + (int)PlayerStatistics.calcMD());
		} 
	}

	public void Destroy() {
		Destroy (gameObject);
	}
}
