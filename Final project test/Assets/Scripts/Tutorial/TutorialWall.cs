using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWall : MonoBehaviour {

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
				if (player.tutorialWalking == true) {
					Destroy (gameObject);
				}
			} else if (tutorialNumber == 1) {
				if (player.tutorialJumping == true) {
					Destroy (gameObject);
				}
			} else if (tutorialNumber == 2) {
				if (player.killedFirst == true) {
					Destroy (gameObject);
				}
			} else if (tutorialNumber == 3) {
				if (player.killedSecond == true) {
					Destroy (gameObject);
				}
			} else if (tutorialNumber == 4) {
				if (player.killedThird == true) {
					Destroy (gameObject);
				}
			} else if (tutorialNumber == 5) {
				if (player.killedFourth == true) {
					Destroy (gameObject);
				}
			} else if (tutorialNumber == 6) {
				if (player.killedFifth == true) {
					Destroy (gameObject);
				}
			} else if (tutorialNumber == 7) {
				if (player.Health == 100) {
					Destroy (gameObject);
				}
			}
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			if (tutorialNumber == 0) {
				if (player.tutorialWalking == true) {
					Destroy (gameObject);
				}
			} else if (tutorialNumber == 1) {
				if (player.tutorialJumping == true) {
					Destroy (gameObject);
				}
			} else if (tutorialNumber == 2) {
				if (player.killedFirst == true) {
					Destroy (gameObject);
				}
			} else if (tutorialNumber == 3) {
				if (player.killedSecond == true) {
					Destroy (gameObject);
				}
			} else if (tutorialNumber == 4) {
				if (player.killedThird == true) {
					Destroy (gameObject);
				}
			} else if (tutorialNumber == 5) {
				if (player.killedFourth == true) {
					Destroy (gameObject);
				}
			} else if (tutorialNumber == 6) {
				if (player.killedFifth == true) {
					Destroy (gameObject);
				}
			} else if (tutorialNumber == 7) {
				if (player.Health == 100) {
					Destroy (gameObject);
				}
			}
		}
	}
}
