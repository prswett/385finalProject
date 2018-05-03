using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour {
	//Weapons
	public GameObject sword;
	public GameObject spear;
	public GameObject axe;
	public GameObject dagger;

	//Armor
	public GameObject helmet;
	public GameObject armor;

	//Spells
	public GameObject fireball;

    public int wepEQPD;

	//List of weapons
	private GameObject[] weapons;
	private GameObject[] armors;
	private GameObject[] spells;
	public int weaponCount = 4;
	public int armorCount = 2;
	public int spellCount = 1;

	// Use this for initialization
	void Start () {
        wepEQPD = 1;
		weapons = new GameObject[weaponCount];
		weapons [0] = sword;
		weapons [1] = spear;
		weapons [2] = axe;
		weapons [3] = dagger;

		armors = new GameObject[armorCount];
		armors [0] = helmet;
		armors [1] = armor;

		spells = new GameObject[spellCount];
		spells [0] = fireball;
	}

	public void changeHelmet(string path) {
		helmet.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (path);
	}

	public void changeArmor(string path) {
		armor.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (path);
	}

	public void changeSword(string path) {
		sword.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (path);
	}

	public void changeSpear(string path) {
		spear.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (path);
	}

	public void changeAxe(string path) {
		axe.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (path);
	}

	public void changeDagger(string path) {
		dagger.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (path);
	}
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject getSpell(int i) {
		return spells [i];
	}

	public void setActiveTrue(int item) {
		weapons [item].SetActive (true);
	}

	public void setActiveFalse(int item) {
		weapons [item].SetActive (false);
	}

	public void setArmorOff() {
		for (int i = 0; i < armorCount; i++) {
			armors [i].SetActive (false);
		}
	}

	public void setArmorOn() {
		for (int i = 0; i < armorCount; i++) {
			armors [i].SetActive (true);
		}
	}
}
