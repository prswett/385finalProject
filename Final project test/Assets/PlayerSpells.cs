using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour {

	//All spell objects
	public GameObject fireball;
	public GameObject lightning;

	public bool[] unlocked;
	public int selectedSpell;
	public int numberOfSpells = 2;



	void Start () {
		unlocked = new bool[numberOfSpells];
		unlocked [0] = true;
		unlocked [1] = true;
	}
	
	public void useSpell() {
		if (unlocked [selectedSpell] == true) {
			if (selectedSpell == 0) {
				fireballSpell ();
			}
			if (selectedSpell == 1) {
				lightningSpell ();
			}
		}
	}

	public void fireballSpell() {
		if (PlayerStatistics.mana >= 1) {
			PlayerStatistics.mana -= 1;
		
			Vector2 cursorL = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			float divider = Mathf.Sqrt (Mathf.Pow (cursorL.x - transform.position.x, 2) + Mathf.Pow (cursorL.y - transform.position.y, 2));
			FireBallController shot = fireball.GetComponent<FireBallController> ();
			shot.setVelocity ((cursorL.x - transform.position.x) / divider, (cursorL.y - transform.position.y) / divider);
			float angle = Mathf.Atan2 (transform.position.x - cursorL.x, cursorL.y - transform.position.y) * Mathf.Rad2Deg;
			Instantiate (fireball, transform.position, Quaternion.Euler (new Vector3 (0, 0, angle)));
		}
	}

	public void lightningSpell() {
		if (PlayerStatistics.mana >= 1) {
			PlayerStatistics.mana -= 1;

			Vector2 cursorL = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			LightningController shot = lightning.GetComponent<LightningController> ();
			shot.setVelocity (0, -1f);
			Instantiate (lightning, cursorL, Quaternion.identity);
		}
	}

	public void increase() {
		if (selectedSpell == numberOfSpells - 1) {
			selectedSpell = 0;
			while (unlocked [selectedSpell] == false) {
				selectedSpell++;
			}
		} else {
			selectedSpell++;
			while (unlocked [selectedSpell] == false) {
				selectedSpell++;
			}
		}
	}

	public void decrease() {
		if (selectedSpell == 0) {
			selectedSpell = numberOfSpells - 1;
			while (unlocked [selectedSpell] == false) {
				selectedSpell--;
			}
		} else {
			selectedSpell--;
			while (unlocked [selectedSpell] == false) {
				selectedSpell--;
			}
		}
	}


	void Update () {
		
	}
}
