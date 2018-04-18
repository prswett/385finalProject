using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public float spawnTime = 3;
	public int maxNumber = 3;

	public GameObject enemy;
	public bool bossStage = false;
	public float horiPos = 1f;
	public float horiNeg = -1f;
	public float vertiPos = 1f;
	public float vertiNeg = -1f;
	float x;
	float y;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		x = transform.position.x;
		y = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn() {
		if (GameObject.FindGameObjectsWithTag("Enemy").Length > maxNumber) {
			return;
		}
		if (!bossStage) {
			Vector3 position = new Vector3 (Random.Range (horiNeg + x, horiPos + x), Random.Range (vertiNeg + y, vertiPos + y), 0);
			Instantiate (enemy,position, Quaternion.identity);
		}
	}
}
