using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour {
	public GameObject sword;
	public GameObject spear;
	public GameObject axe;
	public GameObject dagger;

	//List of weapons
	private GameObject[] weapons;
	public int count = 4;

	// Use this for initialization
	void Start () {
		weapons = new GameObject[count];
		weapons [0] = sword;
		weapons [1] = spear;
		weapons [2] = axe;
		weapons [3] = dagger;
		//Sprite mySword = Resources.Load<Sprite> ("DrawingsV2/Weapons/1HSwordRed");
		//sword.GetComponent<SpriteRenderer> ().sprite = mySword;
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
