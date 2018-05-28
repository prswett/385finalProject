using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public GameObject outofbounds;
	public BoxCollider2D collider2d;
	public Vector2 size;
	public Vector2 boxPosition;

	float spawnx;
	float spawny;

	void Awake() {
		outofbounds = GameObject.FindGameObjectWithTag ("outofbounds");
		collider2d = outofbounds.GetComponent<BoxCollider2D> ();
		size = collider2d.size;
		boxPosition = collider2d.transform.position;
	}

	void Start () {
		InvokeRepeating ("Spawn", 0f, Random.Range(1f, 3f));
	}

	void Update () {

	}

	void Spawn() {
		if (GameObject.FindGameObjectsWithTag("Enemy").Length >= 10) {
			return;
		}
		spawnx = Random.Range (boxPosition.x - (size.x / 2), boxPosition.y + (size.x / 2));
		spawny = Random.Range (boxPosition.y - (size.y / 2), boxPosition.y + (size.y / 2));
		Vector3 position = new Vector3 (spawnx, spawny, 0);
		int selectEnemy = Random.Range (0, EnemyList.numberEnemies);
		Instantiate (EnemyList.enemyList[selectEnemy],position, Quaternion.identity);
	}
}
