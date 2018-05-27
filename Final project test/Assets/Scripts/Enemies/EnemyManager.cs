using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public float spawnTime = 3;
	public int maxNumber = 3;

	public bool bossStage = false;
	public float horiPos = .5f;
	public float horiNeg = -.5f;
	public float vertiPos = .5f;
	public float vertiNeg = -.5f;
	float x;
	float y;

	CameraController temp;
	float spawnx;
	float spawny;

	public bool playerSpawn = true;
	public Transform target;

	void Awake() {
		temp = GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ();
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
		InvokeRepeating ("Spawn", spawnTime, 1f);
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
			spawnx = Random.Range (horiNeg + x, horiPos + x);
			spawny = Random.Range (vertiNeg + y, vertiPos + y);
			while (spawnx < temp.negX - 1.9f || spawnx > temp.posX + 1.9f) {
				spawnx = Random.Range (horiNeg + x, horiPos + x);
			}
			while (spawny < temp.negY - .8f  || spawny > temp.posY + .9f) {
				spawny = Random.Range (vertiNeg + y, vertiPos + y);
			}
			Vector3 position = new Vector3 (spawnx, spawny, 0);
			int selectEnemy = Random.Range (0, EnemyList.numberEnemies);
			Instantiate (EnemyList.enemyList[selectEnemy],position, Quaternion.identity);
		}
	}
}
