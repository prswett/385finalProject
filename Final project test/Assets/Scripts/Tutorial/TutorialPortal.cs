using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialPortal : MonoBehaviour {
	public int nextScene;
	bool near = false;
	public Transform target;
	PlayerTutorial player;
	public TextMesh control;

	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
		player = target.GetComponent<PlayerTutorial> ();
	}

	void Start () {
		control = GetComponentInChildren<TextMesh> ();
	}

	void Update () {

		if (Input.GetKey(KeyCode.W)) {
			if (near) {
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
			control.text = "W";
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			near = false;
			control.text  = "";
		}
	}

	public void setNextScene(int input) {
		nextScene = input;
	}
}
