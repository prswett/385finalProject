using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour {

	public static GameObject[] enemyList;
	public static int numberEnemies;

	public GameObject blackslime;
	public GameObject redslime;
	public GameObject orangeslime;
	public GameObject yellowslime;
	public GameObject greenslime;
	public GameObject blueslime;
	public GameObject blueportal;
	public GameObject blueknight;
	public GameObject bluemushroom;
	public GameObject fireballenemy;
	public GameObject whitebunny;
	// Use this for initialization


	void Start () {
		numberEnemies = 11;
		enemyList = new GameObject[numberEnemies];
		enemyList [0] = blackslime;
		enemyList [1] = blueportal;
		enemyList [2] = blueknight;
		enemyList [3] = bluemushroom;
		enemyList [4] = fireballenemy;
		enemyList [5] = whitebunny;
		enemyList [6] = redslime;
		enemyList [7] = orangeslime;
		enemyList [8] = yellowslime;
		enemyList [9] = greenslime;
		enemyList [10] = blueslime;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
