using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {
	GameObject[] pause;
	public bool paused = false;
	GameObject[] inventory;
	public bool inventoryOpen = false;
	GameObject[] question;
	public bool questionOpen = false;
	public bool clicked = false;
	public bool answer = false;
	GameObject[] control;
	public bool controls = false;

	public bool upgrading = false;

	public Player player;
	public Image upgradeImage;

	void Start () {
		
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
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

		control = GameObject.FindGameObjectsWithTag ("Controls");
		foreach (GameObject controlObject in control) {
			controlObject.SetActive (false);
		}

	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (paused) {
				UnPause ();
			} else {
				player.anim.SetBool ("attacking", false);
				Pause ();
			}
		}
			
		if (Input.GetKeyDown (KeyCode.C)) {
			if (!inventoryOpen) {
				showInventory ();
				player.anim.SetBool ("attacking", false);
			} else {
				if (player != null) {
					if (!player.tryingToDelete) {
						hideInventory ();
						upgrading = false;
						upgradeImage.sprite = Resources.Load<Sprite> ("DrawingsV2/UI/UpgradeUnActive");
					}
				} else {
					hideInventory ();
					upgrading = false;
					upgradeImage.sprite = Resources.Load<Sprite> ("DrawingsV2/UI/UpgradeUnActive");
				}
			}
		}

		if (Input.GetKeyDown(KeyCode.U) && SceneManager.GetActiveScene ().buildIndex == 1) {
			if (!upgrading && inventoryOpen) {
				upgrading = true;
				upgradeImage.sprite = Resources.Load<Sprite> ("DrawingsV2/UI/UpgradeActive");
			} else if (upgrading && inventoryOpen) {
				upgrading = false;
				upgradeImage.sprite = Resources.Load<Sprite> ("DrawingsV2/UI/UpgradeUnActive");
			}
		}
	}

	public void Pause() {
		paused = true;
			player.menu = true;
		Time.timeScale = 0;
		foreach (GameObject pauseObject in pause) {
			pauseObject.SetActive (true);
		}
	}

	public void UnPause() {
		paused = false;
			player.menu = false;
			if (!player.menu && !player.inventory && !player.shop) {
				Time.timeScale = 1;
			}

		foreach (GameObject pauseObject in pause) {
			pauseObject.SetActive (false);
		}
	}

	public void showInventory() {
		inventoryOpen = true;
			player.inventory = true;
		Time.timeScale = 0;
		foreach (GameObject inventoryObject in inventory) {
			inventoryObject.SetActive (true);
		}
	}

	public void hideInventory() {
		inventoryOpen = false;
			player.inventory = false;
			if (!player.menu && !player.inventory && !player.shop) {
				Time.timeScale = 1;
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

	public void yes() {
		clicked = true;
		answer = true;
	}

	public void no() {
		clicked = true;
		answer = false;
	}

	public void mainMenu() {
		Time.timeScale = 1;
		SceneManager.LoadScene (0, LoadSceneMode.Single);
		player.delete ();
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
