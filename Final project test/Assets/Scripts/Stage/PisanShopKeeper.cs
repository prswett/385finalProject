﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisanShopKeeper : MonoBehaviour {
	public TextMesh control;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			control.text = "Hello! Welcome to Pisan's goods! \nPress F to start shopping";
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			control.text  = "";
		}
	}
}
