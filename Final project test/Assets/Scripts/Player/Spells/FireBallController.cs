using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour {
	public float velocityX;
	public float velocityY;
	Rigidbody2D rb2d;
	public string description = "Shoot a fireball that does damage and pierces enemies. /nDisappears on collision with wall/nShoots where the mouse is";

	public int baseDamage = 200;
	public int modifiedDamage = 0;

	void Start () {
		rb2d = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2(velocityX, velocityY) * 3;
		
	}

	public void setVelocity(float x, float y) {
		velocityX = x;
		velocityY = y;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("EnemyHealth")) {
			EnemyHealth health = other.GetComponent<EnemyHealth> ();
			health.takeDamage (modifiedDamage + (int)PlayerStatistics.calcMD());
		}
		if (other.gameObject.CompareTag ("Boss")) {
			BossHealth health = other.GetComponent<BossHealth> ();
			health.takeDamage (modifiedDamage + (int)PlayerStatistics.calcMD());
		}
		if (other.gameObject.CompareTag ("Ground")) {
			Destroy (gameObject);
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

	public void rotate(Vector3 input) {
		transform.rotation = Quaternion.LookRotation (Vector3.forward, input);
	}
}
