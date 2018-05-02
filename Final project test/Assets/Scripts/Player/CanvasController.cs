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

	void Start () {
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

		if (Input.GetKeyDown (KeyCode.I)) {
			if (!inventoryOpen) {
				showInventory ();
			} else {
				hideInventory();
			}
		}
	}

	public void Pause() {
		paused = true;
		Time.timeScale = 0;
		foreach (GameObject pauseObject in pause) {
			pauseObject.SetActive (true);
		}
	}

	public void UnPause() {
		paused = false;
		Time.timeScale = 1;
		foreach (GameObject pauseObject in pause) {
			pauseObject.SetActive (false);
		}
	}

	public void showInventory() {
		inventoryOpen = true;
		Time.timeScale = 0;
		foreach (GameObject inventoryObject in inventory) {
			inventoryObject.SetActive (true);
		}
	}

	public void hideInventory() {
		inventoryOpen = false;
		Time.timeScale = 1;
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
