using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	//Resources
	private PlayerResources resources;
	int count;
	public Text coinText;
	public bool door = false;

	//Awake() variables
	public static Player Instance;
	Image healthbar;
	Image manabar;
	Image expbar;
	Transform spawn;

	//Start() variables
	Rigidbody2D rb2d;
	public Animator anim;

	//Update() variables
	public static bool loadedChar = false;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	public bool onGround;
	public bool facing = false;
	public float speed;
	public float jumpSpeed;
	public bool attacking = false;
	int wepState = 1;
	bool created = true;
	bool jumpDown = false;
	public CanvasController playerCanvas;

	//Taking damage variables
	public float lastHit;

	//KillCount
	public int killCount;
	public bool killedBoss = false;

	//Exp
	public int exp = 0;

	// For Climbing
	public bool onLadder = false;
	public float climbSpeed;
	private float climbVelocity;
	private float gravityStore;

	//Inventory
	public Inventory inv;
	public PotionInventory pInv;

	//Time stops
	public bool menu = false;
	public bool inventory = false;
	public bool shop = false;
	public bool timeStop;

	//
	void Awake() {

		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		} else if (Instance != this) {
			Destroy (gameObject);
		}

		healthbar = GameObject.Find ("Health").GetComponent<Image> ();
		manabar = GameObject.Find ("Mana").GetComponent<Image> ();
		expbar = GameObject.Find ("Exp").GetComponent<Image> ();
		resources = GetComponent<PlayerResources> ();
		count = resources.weaponCount;
		playerCanvas = GameObject.Find ("Base Player UI").GetComponent<CanvasController> ();
		inv = GameObject.Find ("Inventory").GetComponent<Inventory> ();
		pInv = GameObject.Find ("InventoryP").GetComponent<PotionInventory> ();
	}

	public void getSpawnLocation(float x, float y) {
		transform.position = new Vector3(x, y, 0);
		healthbar = GameObject.Find ("Health").GetComponent<Image> ();
		manabar = GameObject.Find ("Mana").GetComponent<Image> ();
		expbar = GameObject.Find ("Exp").GetComponent<Image> ();
		resources = GetComponent<PlayerResources> ();
		count = resources.weaponCount;

		coinText.text = PlayerStatistics.coins.ToString ();

	}

	public void addItem(int input) {
		inv.AddItem (input);
	}

	public void addItem(Item input) {
		inv.AddItem (input);
	}

	public void addPotion(int input) {
		pInv.AddItem (input);
	}

	//
	void Start () {
		rb2d = this.GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		killCount = 0;
		gravityStore = rb2d.gravityScale;
	}

	//
	void Update () {
		timeStop = (menu && inventory && shop);
		if (loadedChar) {
			LoadPlayer load = new LoadPlayer ();
			load.Load (this);
			loadedChar = false;
		}
		coinText.text = PlayerStatistics.coins.ToString ();
		if (created == true) {
			for (int i = 1; i < count; i++) {
				resources.setActiveFalse (i);
			}

			created = false;
		}
		healthbar.fillAmount = PlayerStatistics.health / PlayerStatistics.maxHealth;
		manabar.fillAmount = PlayerStatistics.mana / PlayerStatistics.maxMana;
		expbar.fillAmount = PlayerStatistics.exp / PlayerStatistics.nextLevel;
		if (PlayerStatistics.health <= 0) {
			if (facing) {
				flip ();
			}
			resources.setArmorOff ();
			anim.SetBool ("walking", false);
			anim.SetBool ("attacking", false);
			anim.SetBool ("dead", true);

			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene (1);
				resources.setArmorOn ();
				PlayerStatistics.coins /= 2;
				PlayerStatistics.exp = 0;
				playerReset ();
			}
		} else {
			anim.SetInteger ("weapon state", wepState);
			anim.SetInteger ("weapon equipped", resources.wepEQPD);
			onGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
			//For moving left

			if (!timeStop) {
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

				if (Input.GetKey (KeyCode.J) || Input.GetMouseButton (0)) {
					anim.SetBool ("attacking", true);
					attacking = true;
				}
				if (Input.GetKeyUp (KeyCode.J) || Input.GetMouseButtonUp (0)) {
					anim.SetBool ("attacking", false);
					attacking = false;
				}

				if (Input.GetKeyDown (KeyCode.Space) && onGround && !jumpDown) {
					rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpSpeed);
				}

				if (Input.GetKeyDown (KeyCode.S)) {
					anim.SetBool ("crouching", true);
				}
				if (Input.GetKeyUp (KeyCode.S)) {
					anim.SetBool ("crouching", false);
				}
				
				if (Input.GetMouseButtonDown (1) && playerCanvas.inventoryOpen != true) {
					if (PlayerStatistics.mana >= 1) {
						PlayerStatistics.mana -= 1;
						FireBall ();
					}
				}

				float wheel = Input.GetAxis ("Mouse ScrollWheel");
				if (wheel > 0f) {
					changeWeapon (true);
				} else if (wheel < 0f) {
					changeWeapon (false);
				}
			}

			if (onLadder) {
				rb2d.gravityScale = 0f;

				climbVelocity = climbSpeed * Input.GetAxisRaw ("Vertical");

				rb2d.velocity = new Vector2 (rb2d.velocity.x, climbVelocity);
			}

			if (!onLadder) {
				rb2d.gravityScale = gravityStore;
			}
		}
		}

	public void playerReset() {
		PlayerStatistics.health = PlayerStatistics.maxHealth;
		PlayerStatistics.mana = PlayerStatistics.maxMana;
	}

		public void FireBall() {
			Vector2 cursorL = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			float divider = Mathf.Sqrt (Mathf.Pow (cursorL.x - transform.position.x, 2) + Mathf.Pow (cursorL.y - transform.position.y, 2));
			GameObject fire = resources.getSpell(0);
			FireBallController shot = fire.GetComponent<FireBallController> ();
			shot.setVelocity((cursorL.x - transform.position.x) / divider, (cursorL.y - transform.position.y) / divider);
			float angle = Mathf.Atan2 (transform.position.x - cursorL.x, cursorL.y -  transform.position.y) * Mathf.Rad2Deg;
			Instantiate (fire, transform.position, Quaternion.Euler (new Vector3(0, 0, angle)));
		}

		public void jumpingDown() {
			jumpDown = !jumpDown;
		}

	void changeWeapon(bool up) {
		if (up) {
			if (resources.wepEQPD < 4) {
				resources.setActiveFalse (resources.wepEQPD - 1);
				resources.wepEQPD++;
				anim.SetInteger ("weapon equipped", resources.wepEQPD);
				resources.setActiveTrue (resources.wepEQPD - 1);
			} else {
				resources.setActiveFalse (resources.wepEQPD - 1);
				resources.wepEQPD = 1;
				anim.SetInteger ("weapon equipped", resources.wepEQPD);
				resources.setActiveTrue (resources.wepEQPD - 1);
			}
		} else {
			if (resources.wepEQPD > 1) {
				resources.setActiveFalse (resources.wepEQPD - 1);
				resources.wepEQPD--;
				anim.SetInteger ("weapon equipped", resources.wepEQPD);
				resources.setActiveTrue (resources.wepEQPD - 1);
			} else {
				resources.setActiveFalse (resources.wepEQPD - 1);
				resources.wepEQPD = 4;
				anim.SetInteger ("weapon equipped", resources.wepEQPD);
				resources.setActiveTrue (resources.wepEQPD - 1);
			
			}
			if (resources.wepEQPD == 1 || resources.wepEQPD == 3 || resources.wepEQPD == 4) {
				wepState = 1;
				anim.SetInteger ("weapon state", wepState);
			} else {
				wepState = 2;
				anim.SetInteger ("weapon state", wepState);
			}
		}
	}

		void flip() {
			facing = !facing;
			Vector3 charscale = transform.localScale;
			charscale.x *= -1;
			transform.localScale = charscale;
		}

		public void resetKills() {
				killCount = 0;
				killedBoss = false;
		}
	}
