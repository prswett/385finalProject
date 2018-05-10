using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour {

	public static GameObject[] enemyList;
	public static int numberEnemies;

	public GameObject blackslime;
	public GameObject blueportal;
	public GameObject blueknight;
	public GameObject bluemushroom;
	public GameObject fireballenemy;
	public GameObject whitebunny;
	// Use this for initialization


	void Start () {
		numberEnemies = 6;
		enemyList = new GameObject[numberEnemies];
		enemyList [0] = blackslime;
		enemyList [1] = blueportal;
		enemyList [2] = blueknight;
		enemyList [3] = bluemushroom;
		enemyList [4] = fireballenemy;
		enemyList [5] = whitebunny;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
