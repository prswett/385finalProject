using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour {
	//Weapons
	public GameObject swordHand;
	public GameObject sword;
	public GameObject spearHand;
	public GameObject spear;
	public GameObject axe;
	public GameObject axeHand;
	public GameObject dagger;
	public GameObject daggerHand;

	//Armor
	public GameObject helmet;
	public GameObject armor;

    public int wepEQPD;

	//List of weapons
	private GameObject[] weapons;
	private GameObject[] hands;
	private GameObject[] armors;
	public int weaponCount = 4;
	public int armorCount = 2;

	public Image currentWep;
	public Text currentWepType;

	// Use this for initialization
	void Start () {
        wepEQPD = 1;
		weapons = new GameObject[weaponCount];
		hands = new GameObject[weaponCount];
		weapons [0] = sword;
		hands [0] = swordHand;
		weapons [1] = spear;
		hands [1] = spearHand;
		weapons [2] = axe;
		hands [2] = axeHand;
		weapons [3] = dagger;
		hands [3] = daggerHand;

		armors = new GameObject[armorCount];
		armors [0] = helmet;
		armors [1] = armor;

		currentWep = GameObject.Find ("WeaponImage").GetComponent<Image> ();
		currentWepType = GameObject.Find ("CurrentWep").GetComponent<Text> ();
		currentWep.sprite = sword.GetComponent<SpriteRenderer> ().sprite;
		currentWepType.text = "Sword";
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

	//Reset item looks
	public void resetHelmet() {
		helmet.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("DrawingsV2/Weapons/Helmet");
	}

	public void resetArmor() {
		armor.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("DrawingsV2/Weapons/Armor");
	}

	public void resetSword() {
		sword.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("DrawingsV2/Weapons/1HSword");
	}

	public void resetSpear() {
		spear.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("DrawingsV2/Weapons/Spear");
	}

	public void resetAxe() {
		axe.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("DrawingsV2/Weapons/Axe");
	}

	public void resetDagger() {
		dagger.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("DrawingsV2/Weapons/Dagger");
	}

	void Update () {
		
	}

	public void UIChange() {
		if (wepEQPD == 1) {
			currentWep.sprite = sword.GetComponent<SpriteRenderer> ().sprite;
			currentWepType.text = "Sword";
		} else if (wepEQPD == 2) {
			currentWep.sprite = spear.GetComponent<SpriteRenderer> ().sprite;
			currentWepType.text = "Spear";
		} else if (wepEQPD == 3) {
			currentWep.sprite = axe.GetComponent<SpriteRenderer> ().sprite;
			currentWepType.text = "Axe";
		} else {
			currentWep.sprite = dagger.GetComponent<SpriteRenderer> ().sprite;
			currentWepType.text = "Dagger";
		}
	}

	public void setActiveTrue(int item) {
		weapons [item].SetActive (true);
		hands [item].SetActive (true);
	}

	public void setActiveFalse(int item) {
		weapons [item].SetActive (false);
		hands [item].SetActive (false);
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
