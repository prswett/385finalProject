using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {

	public Transform target;
	public Transform portalLocation;
	public bool portalSpawned = false;
	public GameObject portal;

	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
		portalLocation = GameObject.FindWithTag ("Portal").transform;
		PortalController temp = portalLocation.GetComponent<PortalController> ();
		temp.deactivate ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Player killCount = target.GetComponent<Player> ();
		if (killCount.killCount > 0) {
			if (portalSpawned == false) {
				Instantiate (portal, portalLocation, false);
				portalSpawned = true;
			}
		}
	}
}
