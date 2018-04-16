using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {

	public Transform target;
	public Transform portal;
	public bool portalSpawned = false;
	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Player killCount = target.GetComponent<Player> ();
		if (killCount.killCount > 0) {
			if (portalSpawned == false) {
				Instantiate (portal, new Vector3 (2.4f, 1.3f, 0), Quaternion.identity);
				portalSpawned = true;
			}
		}
	}
}
