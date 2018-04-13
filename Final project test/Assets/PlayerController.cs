using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//Public variables that hold certain player values
	public float speed;
	public float jumpSpeed;
	public Animator anim;
	public bool facing = false;
	public bool attacking = false;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	public bool onGround;

	public float health;
	public float maxHealth;
	public float mana;
	public float maxMana;
	Image healthbar;
	Image manabar;

	public float lastHit;

	Rigidbody2D rb2d;

	// Anim is declared for changing animations
	void Start () {
		healthbar = GameObject.Find ("Health").GetComponent<Image> ();
		manabar = GameObject.Find ("Mana").GetComponent<Image> ();
		maxHealth = health;
		maxMana = mana;

		rb2d = this.GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			this.gameObject.SetActive (false);
		}
		healthbar.fillAmount = health / maxHealth;
		manabar.fillAmount = mana / maxMana;

		onGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
		if (Input.GetKey (KeyCode.A)) {
			if (attacking) {
				anim.SetInteger("State", 2);
			} else {
				anim.SetInteger ("State", 1);
			}
			if (!facing) {
				flip ();
			}
			transform.position += Vector3.left * speed * Time.deltaTime;

		}
		if (Input.GetKeyUp (KeyCode.A)) {
			anim.SetInteger ("State", 0);
		}
		if (Input.GetKey (KeyCode.D)) {
			anim.SetInteger ("State", 1);
			if (attacking) {
				anim.SetInteger("State", 2);
			} else {
				anim.SetInteger ("State", 1);
			}
			if (facing) {
				flip ();
			}
			transform.position += Vector3.right * speed * Time.deltaTime;

		}
		if (Input.GetKeyUp (KeyCode.D)) {
			anim.SetInteger ("State", 0);
		}
		if (Input.GetKey (KeyCode.J)) {
			anim.SetInteger ("State", 2);
			anim.SetInteger("Attacked", 1);
			attacking = true;
		}
		if (Input.GetKeyUp (KeyCode.J)) {
			anim.SetInteger ("State", 0);
			anim.SetInteger("Attacked", 0);
			attacking = false;
		}

		if (Input.GetKey (KeyCode.Space) && onGround) {
			rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpSpeed);
		}

		if (Input.GetKey(KeyCode.R)) {
			SceneManager.LoadScene("FinalProject");
		}

	}

	void flip() {
		facing = !facing;
		Vector3 charscale = transform.localScale;
		charscale.x *= -1;
		transform.localScale = charscale;
	}
		
	public void takeDamage(float damage) {
		if (Time.time - lastHit >= 0.5) {
			health -= damage;
			lastHit = Time.time;
		}
	}
}
