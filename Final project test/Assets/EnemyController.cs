using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float distance;
	public Vector2 pointA;
	public Vector2 pointB;
	public float A;
	public float B;

	// Use this for initialization
	void Start () {
		pointA = new Vector2 (A, B);
		pointB = new Vector2 (A + distance, B);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong (Time.time / 2, 1));
	}
		
}
