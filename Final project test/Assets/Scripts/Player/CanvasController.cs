using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {
	GameObject[] pause;
	public bool paused = false;
	GameObject[] inventory;
	public bool inventoryOpen = false;
	GameObject[] question;
	public bool questionOpen = false;
	public bool clicked = false;
	public bool answer = false;

	public Player player;
	public PlayerTutorial playerTutorial;
	public bool tutorial = false;
	public bool tutorialReady = false;

	void Start () {
		
		if (tutorial) {
			playerTutorial = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerTutorial> ();
		} else {
			player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		}
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
			if (Input.GetKeyDown (KeyCode.I)) {
				if (!inventoryOpen) {
					showInventory ();
				} else {
					hideInventory ();
				}
			}
		}
	}

	public void Pause() {
		paused = true;
		if (tutorial) {
			playerTutorial.menu = true;
		} else {
			player.menu = true;
		}
		Time.timeScale = 0;
		foreach (GameObject pauseObject in pause) {
			pauseObject.SetActive (true);
		}
	}

	public void UnPause() {
		paused = false;
		if (tutorial) {
			playerTutorial.menu = false;
			if (!playerTutorial.menu && !playerTutorial.inventory && !playerTutorial.shop) {
				Time.timeScale = 1;
			}
		} else {
			player.menu = false;
			if (!player.menu && !player.inventory && !player.shop) {
				Time.timeScale = 1;
			}
		}

		foreach (GameObject pauseObject in pause) {
			pauseObject.SetActive (false);
		}
	}

	public void showInventory() {
		inventoryOpen = true;
		if (tutorialReady) {
			playerTutorial.inventory = true;
		} else {
			player.inventory = true;
		}
		Time.timeScale = 0;
		foreach (GameObject inventoryObject in inventory) {
			inventoryObject.SetActive (true);
		}
	}

	public void hideInventory() {
		inventoryOpen = false;
		if (tutorialReady) {
			playerTutorial.inventory = false;
			if (!playerTutorial.menu && !playerTutorial.inventory && !playerTutorial.shop) {
				Time.timeScale = 1;
			}
		} else {
			player.inventory = false;
			if (!player.menu && !player.inventory && !player.shop) {
				Time.timeScale = 1;
			}
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

	public void yes() {
		clicked = true;
		answer = true;
	}

	public void no() {
		clicked = true;
		answer = false;
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
