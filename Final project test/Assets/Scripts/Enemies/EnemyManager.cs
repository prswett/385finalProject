using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public float spawnTime = 3;
	public int maxNumber = 3;

	public GameObject enemy;
	public bool bossStage = false;
	public float horiPos = .5f;
	public float horiNeg = -.5f;
	public float vertiPos = .5f;
	public float vertiNeg = -.5f;
	float x;
	float y;

	public bool playerSpawn = true;
	public Transform target;

	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
		if (playerSpawn) {
			x = target.transform.position.x;
			y = target.transform.position.y;
		} else {
			x = transform.position.x;
			y = transform.position.y;
		}
	}

	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);

	}

	void Update () {
		x = target.transform.position.x;
		y = target.transform.position.y;
	}

	void Spawn() {
		if (GameObject.FindGameObjectsWithTag("Enemy").Length >= maxNumber) {
			return;
		}
		if (!bossStage) {
			Vector3 position = new Vector3 (Random.Range (horiNeg + x, horiPos + x), Random.Range (vertiNeg + y, vertiPos + y), 0);
			Instantiate (enemy,position, Quaternion.identity);
		}
	}
}
