﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalController : MonoBehaviour {
	public int nextScene;
	bool near = false;
	public Transform target;
	Player player;
	public TextMesh control;

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
				player.resetKills ();
				player.stageCount++;
				if (player.dupeSpeed) {
					player.dupeSpeed = false;
					player.speed /= 1.5f;
					player.jumpSpeed /= 1.1f;
				}
				if (player.stageCount == 10) {
					//Load boss
				} else if (player.stageCount == 11) {
					SceneManager.LoadScene (1, LoadSceneMode.Single);
				}
				SceneManager.LoadScene (nextScene, LoadSceneMode.Single);
				player.anim.SetBool ("attacking", false);
				player.anim.SetBool ("walking", false);
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
