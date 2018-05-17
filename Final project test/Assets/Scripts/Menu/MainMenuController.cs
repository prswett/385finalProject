using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {
	GameObject[] instructions;
	GameObject[] control;
	public bool show = false;
	public bool controls = false;

	// Use this for initialization
	void Start () {
		instructions = GameObject.FindGameObjectsWithTag ("Instructions");
		foreach (GameObject instructObject in instructions) {
			instructObject.SetActive (false);
		}

		control = GameObject.FindGameObjectsWithTag ("Controls");
		foreach (GameObject controlObject in control) {
			controlObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void showInstructions() {
		show = true;
		foreach (GameObject instructObject in instructions) {
			instructObject.SetActive (true);
		}
	}

	public void hideInstructions() {
		show = false;
		foreach (GameObject instructObject in instructions) {
			instructObject.SetActive (false);
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
}
