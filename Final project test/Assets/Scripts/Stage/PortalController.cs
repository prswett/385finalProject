using System.Collections;
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

	public bool finalBoss = false;
	public bool boss = false;

	public bool finishTutorial = false;
	public bool tutorial = false;

	public bool sent = false;

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
				if (player.dupeSpeed) {
					player.dupeSpeed = false;
					player.speed /= 1.5f;
					player.jumpSpeed /= 1.1f;
				}

				if (tutorial) {
					if (!finishTutorial) {
						player.delete ();
						SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1, LoadSceneMode.Single);
					} else {
						player.delete ();
						PlayerStatistics.reset ();
						SceneManager.LoadScene (1, LoadSceneMode.Single);
					}
				} else {

					if (!finalBoss) {
						
						if (player.stageCount == 4) {
							int temp = Random.Range (0, 4);
							if (temp == 0) {
								if (!sent) {
									sent = true;
									SceneManager.LoadScene (3, LoadSceneMode.Single);
								}
							} else if (temp == 1) {
								if (!sent) {
									sent = true;
									SceneManager.LoadScene (4, LoadSceneMode.Single);
								}
							} else if (temp == 2) {
								if (!sent) {
									sent = true;
									SceneManager.LoadScene (5, LoadSceneMode.Single);
								}
							} else if (temp == 3) {
								if (!sent) {
									sent = true;
									SceneManager.LoadScene (6, LoadSceneMode.Single);
								}
							}
						} else if (player.stageCount == 5) {
							if (!sent) {
								sent = true;
								SceneManager.LoadScene (1, LoadSceneMode.Single);
							}
						} else {
							if (!sent) {
								sent = true;
								int next = Random.Range (7, 24);
								SceneManager.LoadScene (next, LoadSceneMode.Single);
							}
						}
					} else {
						if (PlayerStatistics.level >= 20) {
							SceneManager.LoadScene (nextScene, LoadSceneMode.Single);
						}
					}
				}
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
			if (!boss) {
				control.text = "W";
			} else {
				control.text = "W \nFight the final boss\nRequires level 20 or above";
			}
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
