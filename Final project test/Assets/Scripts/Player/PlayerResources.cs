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
	private Sprite[] swordSprites;

	// Use this for initialization
	void Start () {
        wepEQPD = 1;
		weapons = new GameObject[weaponCount];
		weapons [0] = sword;
		weapons [1] = spear;
		weapons [2] = axe;
		weapons [3] = dagger;
		swordSprites = new Sprite[4];
		swordSprites[0] = Resources.Load<Sprite>("DrawingsV2/Weapons/1HSword");
		swordSprites[1] = Resources.Load<Sprite>("DrawingsV2/Weapons/1HSwordRed");
		swordSprites[2] = Resources.Load<Sprite>("DrawingsV2/Weapons/1HSwordGreen");
		swordSprites [3] = Resources.Load<Sprite> ("DrawingsV2/Weapons/1HSwordBlue");

		armors = new GameObject[armorCount];
		armors [0] = helmet;
		armors [1] = armor;

		spells = new GameObject[spellCount];
		spells [0] = fireball;
	}

	public void swordChange(int input) {
		sword.GetComponent<SpriteRenderer> ().sprite = swordSprites [input];
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
