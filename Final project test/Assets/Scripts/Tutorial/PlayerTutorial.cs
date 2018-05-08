using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerTutorial : MonoBehaviour {
	//Resources
	public PlayerResources resources;
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
	public Equipment eInv;

	//Time stops
	public bool menu = false;
	public bool inventory = false;
	public bool shop = false;
	public bool timeStop;

	public GameObject fire;

	//Tutorial 
	public bool tutorialWalking = true;
	public bool tutorialJumping = false;
	public bool tutorialAttacking = false;
	public bool tutorialSword = false;
	public bool tutorialSpear = false;
	public bool tutorialAxe = false;
	public bool tutorialDagger = false;
	public bool tutorialWeaponSwitch = false;
	public bool tutorialFireball = false;
	public bool tutorialInventory = false;

	public bool killedFirst = false;
	public bool killedSecond = false;
	public bool killedThird = false;
	public bool killedFourth = false;
	public bool killedFifth = false;

	public bool tookDamage = false;

	public float Health = 100;
	public float MaxHealth = 100;
	public float Mana = 5;
	public float MaxMana = 5;
	public float manaRegen;

	//
	void Awake() {

		healthbar = GameObject.Find ("Health").GetComponent<Image> ();
		manabar = GameObject.Find ("Mana").GetComponent<Image> ();
		expbar = GameObject.Find ("Exp").GetComponent<Image> ();
		resources = GetComponent<PlayerResources> ();
		count = resources.weaponCount;
		playerCanvas = GameObject.Find ("Base Player UI").GetComponent<CanvasController> ();

		inv = GameObject.Find ("Inventory").GetComponent<Inventory> ();
		pInv = GameObject.Find ("InventoryP").GetComponent<PotionInventory> ();
		eInv = GameObject.Find ("Equipment").GetComponent<Equipment> ();
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
		inv.AddItem (input, true);
	}

	public void addItem(ItemStats inputStats) {
		inv.AddItem (inputStats);
	}

	public void addPotion(int input) {
		pInv.AddItem (input, true);
	}

	public void addEquipment(Item input, int slot, bool equipped) {
		eInv.AddItem (input, slot, equipped);
	}

	public void addEquipment(Item input, int slot) {
		eInv.AddItem (input, slot);
	}

	//
	void Start () {
		rb2d = this.GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		killCount = 0;
		gravityStore = rb2d.gravityScale;

		//GetComponent<SpriteRenderer> ().color = Color.blue;
	}

	//
	void Update () {
		if (tutorialInventory) {
			playerCanvas.tutorial = false;
		}
		timeStop = (menu && inventory && shop);
		if (created == true) {
			for (int i = 1; i < count; i++) {
				resources.setActiveFalse (i);
			}

			created = false;
		}
		healthbar.fillAmount = Health / MaxHealth;
		if (Time.time - manaRegen >= 1f) {
			if (Mana < MaxMana) {
				Mana++;
			}
		}
		manabar.fillAmount = Mana / MaxMana;

		expbar.fillAmount = 0 / 100f;
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

				if (tutorialAttacking) {
					if (Input.GetKey (KeyCode.J) || Input.GetMouseButton (0)) {
						anim.SetBool ("attacking", true);
						attacking = true;
					}
					if (Input.GetKeyUp (KeyCode.J) || Input.GetMouseButtonUp (0)) {
						anim.SetBool ("attacking", false);
						attacking = false;
					}
				}

				if (tutorialJumping) {
					if (Input.GetKeyDown (KeyCode.Space) && onGround && !jumpDown) {
						rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpSpeed);
					}
				}

				if (Input.GetKeyDown (KeyCode.S)) {
					anim.SetBool ("crouching", true);
				}
				if (Input.GetKeyUp (KeyCode.S)) {
					anim.SetBool ("crouching", false);
				}

				if (tutorialFireball) {
					if (Input.GetMouseButtonDown (1) && playerCanvas.inventoryOpen != true) {
						if (PlayerStatistics.mana >= 1) {
							PlayerStatistics.mana -= 1;
							FireBall ();
							manaRegen = Time.time;
						}
					}
				}

				if (tutorialWeaponSwitch) {
					float wheel = Input.GetAxis ("Mouse ScrollWheel");
					if (wheel > 0f) {
						changeWeapon (true);
					} else if (wheel < 0f) {
						changeWeapon (false);
					}
				}  else if (tutorialDagger) {
					float wheel = Input.GetAxis ("Mouse ScrollWheel");
					if (wheel > 0f) {
						resources.setActiveTrue (3);
						resources.setActiveFalse (2);
					} else {
						resources.setActiveTrue (3);
						resources.setActiveFalse (2);
					}
					resources.wepEQPD = 4;
					anim.SetInteger ("weapon equipped", resources.wepEQPD);
				}  else if (tutorialAxe) {
					float wheel = Input.GetAxis ("Mouse ScrollWheel");
					if (wheel > 0f) {
						resources.setActiveTrue (2);
						resources.setActiveFalse (1);
					} else {
						resources.setActiveTrue (2);
						resources.setActiveFalse (1);
					}
					resources.wepEQPD = 3;
					anim.SetInteger ("weapon equipped", resources.wepEQPD);
				}  else if (tutorialSpear) {
					float wheel = Input.GetAxis ("Mouse ScrollWheel");
					if (wheel > 0f) {
						resources.setActiveTrue (1);
						resources.setActiveFalse (0);
					} else {
						resources.setActiveTrue (1);
						resources.setActiveFalse (0);
					}
					resources.wepEQPD = 2;
					anim.SetInteger ("weapon equipped", resources.wepEQPD);
				} else if (tutorialSword) {
					float wheel = Input.GetAxis ("Mouse ScrollWheel");
					if (wheel > 0f) {
						resources.setActiveTrue (0);
					} else {
						resources.setActiveTrue (0);
					}
					resources.wepEQPD = 1;
					anim.SetInteger ("weapon equipped", resources.wepEQPD);
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
		TutorialFireballController shot = fire.GetComponent<TutorialFireballController> ();
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

		}
		if (resources.wepEQPD == 1 || resources.wepEQPD == 3 || resources.wepEQPD == 4) {
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

	public void resetKills() {
		killCount = 0;
		killedBoss = false;
	}
}
