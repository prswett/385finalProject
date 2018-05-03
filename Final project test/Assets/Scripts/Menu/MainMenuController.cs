using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {
	GameObject[] instructions;
	public bool show = false;

	// Use this for initialization
	void Start () {
		instructions = GameObject.FindGameObjectsWithTag ("Instructions");
		foreach (GameObject instructObject in instructions) {
			instructObject.SetActive (false);
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
}
