using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialPortal : MonoBehaviour {
	public int nextScene;
	bool near = false;
	public Transform target;
	Player player;
	public TextMesh control;

	public bool finishTutorial = false;
	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
		player = target.GetComponent<Player> ();
	}

	void Start () {
		control = GetComponentInChildren<TextMesh> ();
	}

	void Update () {

		if (Input.GetKey(KeyCode.W)) {
			if (near) {
				if (!finishTutorial) {
					DestroyObject (player);
					SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1, LoadSceneMode.Single);
				} else {
					DestroyObject (player);
					SceneManager.LoadScene (1, LoadSceneMode.Single);
				}
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
