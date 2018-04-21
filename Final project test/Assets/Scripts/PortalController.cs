using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour {
	public int nextScene;
	bool near = false;

	void Start () {
	}
		
	void Update () {
		if (Input.GetKeyDown(KeyCode.R) || Input.GetKey(KeyCode.W)) {
			if (near) {
				SceneManager.LoadScene (nextScene, LoadSceneMode.Single);
			}
		}
	}

	public void deactivate() {
		Destroy (gameObject);
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
