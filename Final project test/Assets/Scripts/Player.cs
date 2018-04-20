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

	//Awake() variables
	public PlayerStatistics localPlayer = new PlayerStatistics();
	Image healthbar;
	Image manabar;
	Transform spawn;

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
	bool created = true;
	public float health;

	//Taking damage variables
	public float lastHit;

	//KillCount
	public int killCount;
	public bool killedBoss = false;

	//
	void Awake() {
		//loadPlayer ();
		DontDestroyOnLoad(this);
		healthbar = GameObject.Find ("Health").GetComponent<Image> ();
		manabar = GameObject.Find ("Mana").GetComponent<Image> ();
		resources = GetComponent<PlayerResources> ();
		count = resources.count;

		getSpawnLocation ();
	}

	public void getSpawnLocation() {
		spawn = GameObject.FindWithTag ("Ground").transform;
		StageController temp = spawn.GetComponent<StageController> ();
		float x = temp.playerX;
		float y = temp.playerY;
		transform.position = new Vector2 (x, y);
	}

	public void getSpawnLocation(float x, float y) {
		transform.position = new Vector2(x, y);

		healthbar = GameObject.Find ("Health").GetComponent<Image> ();
		manabar = GameObject.Find ("Mana").GetComponent<Image> ();
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
				getSpawnLocation ();
				//savePlayer ();
				int scene = SceneManager.GetActiveScene ().buildIndex;
				SceneManager.LoadScene (scene, LoadSceneMode.Single);
				Destroy (gameObject);
			}
		} else {
			anim.SetInteger ("weapon state", wepState);
			anim.SetInteger ("weapon equipped", resources.wepEQPD);
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

			if (Input.GetKey (KeyCode.J) || Input.GetMouseButton(0)) {
				anim.SetBool ("attacking", true);
				attacking = true;
			}
			if (Input.GetKeyUp(KeyCode.J) || Input.GetMouseButtonUp(0)) {
				anim.SetBool("attacking", false);
				attacking = false;
			}

			if (Input.GetKeyDown (KeyCode.Space) && onGround) {
				rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpSpeed);
			}

			if (Input.GetKeyDown (KeyCode.Z)) {
				changeWeapon();
			}

			if (Input.GetKeyDown (KeyCode.S)) {
				anim.SetBool ("crouching", true);
			}
			if (Input.GetKeyUp (KeyCode.S)) {
				anim.SetBool ("crouching", false);
			}
		}
	}

	void changeWeapon() {
		if (resources.wepEQPD < 4) {
			resources.setActiveFalse (resources.wepEQPD - 1);
			resources.wepEQPD++;
			anim.SetInteger ("weapon equipped", resources.wepEQPD);
			resources.setActiveTrue (resources.wepEQPD- 1);
		} else {
			resources.setActiveFalse (resources.wepEQPD - 1);
			resources.wepEQPD = 1;
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

	public void resetKills() {
		killCount = 0;
		killedBoss = false;
	}

	// saving data into a file (.sb)
	public void Save()
	{
		// binary formatter is helper to convert this data to the text
		BinaryFormatter bf = new BinaryFormatter();
		// creating new file
		FileStream file = File.Create(Application.persistentDataPath + "/pss.sb");
		// serializable data here
		PlayerData data = new PlayerData();
		data.curHP = localPlayer.health;
		data.maxHP = localPlayer.maxHealth;
		data.curMP = localPlayer.mana;
		data.maxMP = localPlayer.maxMana;
		//moves to file
		bf.Serialize(file, data);
		file.Close();
	}

	// loading data if exists
	public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/pss.sb"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/pss.sb", FileMode.Open);
			PlayerData data = (PlayerData) bf.Deserialize(file);
			file.Close();
			localPlayer.health = data.curHP;
			localPlayer.maxHealth = data.maxHP;
			localPlayer.mana = data.curMP;
			localPlayer.maxMana = data.maxMP;
		}
	}
}

// need this class for serializable to convert to file
[Serializable]
class PlayerData
{
	public float curHP;
	public float maxHP;
	public float curMP;
	public float maxMP;
}

