using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour {
	public int stageNumber;
	bool near = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.W)) {
			if (near) {
				SceneManager.LoadScene (stageNumber, LoadSceneMode.Single);
				Transform target = GameObject.FindWithTag ("Player").transform;
				target.GetComponent<Player> ().door = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			near = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			near = false;
		}
	}
}
