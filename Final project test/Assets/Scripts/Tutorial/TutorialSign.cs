using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSign : MonoBehaviour {

	public Transform target;
	PlayerTutorial player;
	public TextMesh control;
	public int tutorialNumber;

	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
		player = target.GetComponent<PlayerTutorial> ();
	}
		
	void Start () {
		control = GetComponentInChildren<TextMesh> ();
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			if (tutorialNumber == 0) {
				player.tutorialWalking = true;
			} else if (tutorialNumber == 1) {
				player.tutorialJumping = true;
			} else if (tutorialNumber == 2) {
				player.tutorialAttacking = true;
				player.tutorialSword = true;
			} else if (tutorialNumber == 3) {
				player.tutorialSpear = true;
			} else if (tutorialNumber == 4) {
				player.tutorialAxe = true;
			} else if (tutorialNumber == 5) {
				player.tutorialDagger = true;
			} else if (tutorialNumber == 6) {
				player.tutorialWeaponSwitch = true;
			} else if (tutorialNumber == 7) {
				player.tutorialFireball = true;
			} else if (tutorialNumber == 8) {
				player.tutorialInventory = true;
				if (!player.tookDamage) {
					player.Health -= 10;
					player.tookDamage = true;
				}
			}
		}
	}


}
