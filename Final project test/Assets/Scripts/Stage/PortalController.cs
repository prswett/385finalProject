using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour {
	public int nextScene;
	bool near = false;
	public Transform target;
	Player killCount;

	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
		killCount = target.GetComponent<Player> ();
	}

	void Start () {
		
	}
		
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.R) || Input.GetKey(KeyCode.W)) {
			if (near) {
				killCount.resetKills ();
				SceneManager.LoadScene (nextScene, LoadSceneMode.Single);
			}
		}
	}

	public void deactivate() {
		this.gameObject.SetActive (false);
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

	public void setNextScene(int input) {
		nextScene = input;
	}
}
