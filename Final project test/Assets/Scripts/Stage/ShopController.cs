using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour {
	GameObject[] shop;
	public bool shopping = false;
	public Transform target;
	public Player player;

	void Awake() {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		player = target.GetComponent<Player> ();
	}
	// Use this for initialization
	void Start () {
		shop = GameObject.FindGameObjectsWithTag ("Shop");
		foreach (GameObject shopObject in shop) {
			shopObject.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			if (shopping) {
				stopShop ();
			} else {
				startShop ();
			}
		}
	}

	public void stopShop() {
		shopping = false;
		player.shop = false;
		if (!player.menu && !player.inventory && !player.shop) {
			Time.timeScale = 1;
		}
		foreach (GameObject shopObject in shop) {
			shopObject.SetActive (false);
		} 
	}

	public void startShop() {
		shopping = true;
		player.shop = true;
		Time.timeScale = 0;
		foreach (GameObject shopObject in shop) {
			shopObject.SetActive (true);
		}
	}

	public void buyHealth() {
		Player temp = target.GetComponent<Player> ();
		if (PlayerStatistics.coins >= 10) {
			temp.addPotion (0);
			PlayerStatistics.coins -= 10;
		}
	}

	public void buyMana() {
		Player temp = target.GetComponent<Player> ();
		if (PlayerStatistics.coins >= 10) {
			temp.addPotion (1);
			PlayerStatistics.coins -= 10;
		}
	}
		
}
