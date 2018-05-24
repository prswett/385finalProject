using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {
	GameObject[] pause;
	public bool paused = false;
	GameObject[] inventory;
	public bool inventoryOpen = false;
	GameObject[] question;
	public bool questionOpen = false;
	public bool clicked = false;
	public bool answer = false;
	GameObject[] control;
	public bool controls = false;

	public Player player;
	public bool tutorial = false;
	public bool tutorialReady = false;

	void Start () {
		
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		pause = GameObject.FindGameObjectsWithTag ("Pause");
		foreach (GameObject pauseObject in pause) {
			pauseObject.SetActive (false);
		}
		inventory = GameObject.FindGameObjectsWithTag ("Inventory");
		foreach (GameObject inventoryObject in inventory) {
			inventoryObject.SetActive (false);
		}
		question = GameObject.FindGameObjectsWithTag ("QuestionBox");
		foreach (GameObject questionObject in question) {
			questionObject.SetActive (false);
		}

		control = GameObject.FindGameObjectsWithTag ("Controls");
		foreach (GameObject controlObject in control) {
			controlObject.SetActive (false);
		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (paused) {
				UnPause ();
			} else {
				Pause ();
			}
		}

		if (!tutorial) {
			if (Input.GetKeyDown (KeyCode.C)) {
				if (!inventoryOpen) {
					showInventory ();
				} else {
					if (player != null) {
						if (!player.tryingToDelete) {
							hideInventory ();
						}
					} else {
						hideInventory ();
					}
				}
			}
		}
	}

	public void Pause() {
		paused = true;
			player.menu = true;
		Time.timeScale = 0;
		foreach (GameObject pauseObject in pause) {
			pauseObject.SetActive (true);
		}
	}

	public void UnPause() {
		paused = false;
			player.menu = false;
			if (!player.menu && !player.inventory && !player.shop) {
				Time.timeScale = 1;
			}

		foreach (GameObject pauseObject in pause) {
			pauseObject.SetActive (false);
		}
	}

	public void showInventory() {
		inventoryOpen = true;
			player.inventory = true;
		Time.timeScale = 0;
		foreach (GameObject inventoryObject in inventory) {
			inventoryObject.SetActive (true);
		}
	}

	public void hideInventory() {
		inventoryOpen = false;
			player.inventory = false;
			if (!player.menu && !player.inventory && !player.shop) {
				Time.timeScale = 1;
			}

		foreach (GameObject inventoryObject in inventory) {
			inventoryObject.SetActive (false);
		}
	}

	public void showQuestion() {
		foreach (GameObject questionObject in question) {
			questionObject.SetActive (true);
		}
	}

	public void hideQuestion() {
		foreach (GameObject questionObject in question) {
			questionObject.SetActive (false);
		}
	}

	public void showControls() {
		controls = true;
		foreach (GameObject controlObject in control) {
			controlObject.SetActive (true);
		}
	}

	public void hideControls() {
		controls = false;
		foreach (GameObject controlObject in control) {
			controlObject.SetActive (false);
		}
	}

	public void yes() {
		clicked = true;
		answer = true;
	}

	public void no() {
		clicked = true;
		answer = false;
	}

	public void mainMenu() {
		Time.timeScale = 1;
		SceneManager.LoadScene (0, LoadSceneMode.Single);
		if (!tutorial) {
			player.delete ();
		}
	}

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
