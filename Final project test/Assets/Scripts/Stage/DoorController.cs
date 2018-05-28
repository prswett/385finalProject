using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour {
	public int stageNumber;
	bool near = false;
	public bool shop;
	public TextMesh control;

	// Use this for initialization
	void Start () {
		control = GetComponentInChildren<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)) {
			if (shop) {
				ShopController temp = GameObject.Find ("PisanShopKeeper").GetComponent<ShopController> ();
				temp.stopShop ();
			}
			if (near) {
				SceneManager.LoadScene (stageNumber, LoadSceneMode.Single);
				Transform target = GameObject.FindWithTag ("Player").transform;
				target.GetComponent<Player> ().door = true;
				PlayerMusic temp = GameObject.Find ("Audio").GetComponent<PlayerMusic> ();
				if (stageNumber == 2) {
					temp.SM ();
				} else {
					temp.TM ();
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			near = true;
			control.text = "W";
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			near = false;
			control.text = "";
		}
	}
}
