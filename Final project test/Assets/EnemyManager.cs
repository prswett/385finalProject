using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	int numberOfMonsters = 0;
	public float spawnTime = 3;
	public GameObject enemy;
	public bool bossStage = false;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn() {
		if (numberOfMonsters > -1) {
			return;
		}
		if (!bossStage) {
			Instantiate (enemy, new Vector3 (2.3f, 1.3f, 0f), Quaternion.identity);
			numberOfMonsters++;
		}
	}
}
