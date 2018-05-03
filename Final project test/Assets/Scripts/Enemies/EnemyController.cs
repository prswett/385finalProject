using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public float startTime;
	public float countdownTime;
	public float spawnTime;
	public bool active = false;

	public bool set = false;
	void Start () {
		Color tempColor = GetComponent<SpriteRenderer> ().color;
		tempColor.a = 0;
		GetComponent<SpriteRenderer> ().color = tempColor;
		spawnTime = Time.time;
	}

	void Update () {
		if (!set) {
			startTime = 10f;
			countdownTime = 10f;
			set = true;
		}
	}

	void FixedUpdate() {
		if (Time.time - spawnTime < 3f) {
			float alpha = 1 - (1 / countdownTime * startTime);
			Color tempColor = GetComponent<SpriteRenderer> ().color;
			tempColor.a = alpha;
			GetComponent<SpriteRenderer> ().color = tempColor;
			countdownTime += Time.deltaTime * 2;
		} else {
			Color tempColor = GetComponent<SpriteRenderer> ().color;
			tempColor.a = 1;
			GetComponent<SpriteRenderer> ().color = tempColor;
			active = true;
		}
	}

	public void moveLeft() {
		transform.position += Vector3.left * 0.01f;
	}

	public void moveRight() {
		transform.position += Vector3.right * 0.01f;
	}

	public void destroy() {
		Destroy (gameObject);
	}

}