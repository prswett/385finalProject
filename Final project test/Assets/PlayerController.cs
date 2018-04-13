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

	public PlayerStatistics localPlayer = new PlayerStatistics();
	Image healthbar;
	Image manabar;

	public int killCount;
	public float lastHit;

	Rigidbody2D rb2d;

	// Anim is declared for changing animations
	void Start () {
		DontDestroyOnLoad (gameObject);
		healthbar = GameObject.Find ("Health").GetComponent<Image> ();
		manabar = GameObject.Find ("Mana").GetComponent<Image> ();
		localPlayer.maxHealth = localPlayer.health;
		localPlayer.maxMana = localPlayer.mana;

		rb2d = this.GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		killCount = 0;
	}

	// Update is called once per frame
	void Update () {
		if (localPlayer.health <= 0) {
			this.gameObject.SetActive (false);
		}
		healthbar.fillAmount = localPlayer.health / localPlayer.maxHealth;
		manabar.fillAmount = localPlayer.mana / localPlayer.maxMana;

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
			SceneManager.LoadScene("Stage1");
			this.gameObject.SetActive (false);
		}
		if (Input.GetKey (KeyCode.Q)) {
			if (killCount > 0) {
				savePlayer ();
				SceneManager.LoadScene ("Boss Stage");
			}
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
			localPlayer.health -= damage;
			lastHit = Time.time;
		}
	}

	public void savePlayer() {
		GlobalControl.Instance.savedData = localPlayer;
	}

	public void loadPlayer() {
		localPlayer = GlobalControl.Instance.savedData;
	}
}
