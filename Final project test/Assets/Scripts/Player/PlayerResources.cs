using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour {
	public GameObject sword;
	public GameObject spear;
	public GameObject axe;
	public GameObject dagger;

    public int wepEQPD;


	//List of weapons
	private GameObject[] weapons;
	public int count = 4;
	private Sprite[] swordSprites;

	// Use this for initialization
	void Start () {
        wepEQPD = 1;
		weapons = new GameObject[count];
		weapons [0] = sword;
		weapons [1] = spear;
		weapons [2] = axe;
		weapons [3] = dagger;
		swordSprites = new Sprite[4];
		swordSprites[0] = Resources.Load<Sprite>("DrawingsV2/Weapons/1HSword");
		swordSprites[1] = Resources.Load<Sprite>("DrawingsV2/Weapons/1HSwordRed");
		swordSprites[2] = Resources.Load<Sprite>("DrawingsV2/Weapons/1HSwordGreen");
		swordSprites[3] = Resources.Load<Sprite>("DrawingsV2/Weapons/1HSwordBlue");
	}

	public void swordChange(int input) {
		sword.GetComponent<SpriteRenderer> ().sprite = swordSprites [input];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setActiveTrue(int item) {
		weapons [item].SetActive (true);
	}

	public void setActiveFalse(int item) {
		weapons [item].SetActive (false);
	}
}
