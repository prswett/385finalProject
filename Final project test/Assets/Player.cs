using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	//Resources
	private PlayerResources resources;
	int count;

	//Awake() variables
	public PlayerStatistics localPlayer = new PlayerStatistics();
	Image healthbar;
	Image manabar;

	//Start() variables
	Rigidbody2D rb2d;
	public Animator anim;

	//Update() variables
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	public bool onGround;
	public bool facing = false;
	public float speed;
	public float jumpSpeed;
	public bool attacking = false;
	int wepState = 1;
	int wepEquipped = 1;
	bool created = true;
	public float health;

	//Taking damage variables
	public float lastHit;

	//KillCount
	public int killCount;

	//
	void Awake() {
		loadPlayer ();
		healthbar = GameObject.Find ("Health").GetComponent<Image> ();
		manabar = GameObject.Find ("Mana").GetComponent<Image> ();
		//localPlayer.maxHealth = localPlayer.health;
		//localPlayer.maxMana = localPlayer.mana;
		resources = GetComponent<PlayerResources> ();
		count = resources.count;
	}

	//
	void Start () {
		rb2d = this.GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		killCount = 0;
	}

	//
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)) {
			Application.Quit();
		}
		health = localPlayer.health;
		if (created == true) {
			for (int i = 1; i < count; i++) {
				resources.setActiveFalse (i);
			}

			created = false;
		}
		healthbar.fillAmount = localPlayer.health / localPlayer.maxHealth;
		manabar.fillAmount = localPlayer.mana / localPlayer.maxMana;
		if (localPlayer.health <= 0) {
			if (facing) {
				flip ();
			}
			anim.SetBool ("walking", false);
			anim.SetBool ("attacking", false);
			anim.SetBool ("dead", true);

			if (Input.GetKeyDown(KeyCode.R)) {
				localPlayer = new PlayerStatistics();
				savePlayer ();
				int scene = SceneManager.GetActiveScene ().buildIndex;
				SceneManager.LoadScene (scene, LoadSceneMode.Single);
			}
		} else {
			anim.SetInteger ("weapon state", wepState);
			anim.SetInteger ("weapon equipped", wepEquipped);
			onGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
			//For moving left
			if (Input.GetKey (KeyCode.A)) {
				if (attacking) {
					anim.SetBool ("walking", true);
				} else {
					anim.SetBool ("walking", true);
				}
				if (!facing) {
					flip ();
				}
				transform.position += Vector3.left * speed * Time.deltaTime;
			}
			if (Input.GetKeyUp (KeyCode.A)) {
				anim.SetBool ("walking", false);
			}

			if (Input.GetKey (KeyCode.D)) {
				if (attacking) {
					anim.SetBool ("walking", true);
				} else {
					anim.SetBool ("walking", true);
				}
				if (facing) {
					flip ();
				}
				transform.position += Vector3.right * speed * Time.deltaTime;
			}

			if (Input.GetKeyUp (KeyCode.D)) {
				anim.SetBool ("walking", false);
			}

			if (Input.GetKey (KeyCode.J)) {
				anim.SetBool ("attacking", true);
				attacking = true;
			}
			if (Input.GetKeyUp(KeyCode.J)) {
				anim.SetBool("attacking", false);
				attacking = false;
			}

			if (Input.GetKey (KeyCode.Space) && onGround) {
				rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpSpeed);
			}

			if (Input.GetKeyDown (KeyCode.Z)) {
				changeWeapon();
			}
		}
	}

	void changeWeapon() {
		if (wepEquipped < 4) {
			resources.setActiveFalse (wepEquipped - 1);
			wepEquipped++;
			anim.SetInteger ("weapon equipped", wepEquipped);
			resources.setActiveTrue (wepEquipped - 1);
		} else {
			resources.setActiveFalse (wepEquipped - 1);
			wepEquipped = 1;
			anim.SetInteger ("weapon equipped", wepEquipped);
			resources.setActiveTrue (wepEquipped - 1);
		}
		if (wepEquipped == 1 || wepEquipped == 3 || wepEquipped == 4) {
			wepState = 1;
			anim.SetInteger ("weapon state", wepState);
		} else {
			wepState = 2;
			anim.SetInteger ("weapon state", wepState);
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

	//Save data
	public void savePlayer() {
		GlobalControl.Instance.savedData = localPlayer;
	}

	//Load data
	public void loadPlayer() {
		localPlayer = GlobalControl.Instance.savedData;
	}
}
