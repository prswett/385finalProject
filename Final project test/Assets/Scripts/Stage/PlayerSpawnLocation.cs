using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnLocation : MonoBehaviour {
	public GameObject parent;
	public StageController parentController;
	// Use this for initialization
	void Awake() {
		parent = transform.parent.gameObject;
		parentController = parent.GetComponent<StageController> ();
		parentController.playerX = transform.position.x;
		parentController.playerY = transform.position.y;
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
