using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	Rigidbody2D rb2d;

	// Anim is declared 
	void Start () {
		rb2d = this.GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {
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
		
}
