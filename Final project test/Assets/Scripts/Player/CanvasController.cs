using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {
	GameObject[] pause;
	public bool paused = false;

	void Start () {
		pause = GameObject.FindGameObjectsWithTag ("Pause");
		foreach (GameObject pauseObject in pause) {
			pauseObject.SetActive (false);
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

	public void Quit() {
		Application.Quit();
	}
}
