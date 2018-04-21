using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {

	public Transform target;
	public Transform portalLocation;
	public bool portalSpawned = false;
	public GameObject portal;
	public Vector3 location;
	public bool spawned = false;
	public int monstersNeeded;
	int nextScene;

	public float playerX;
	public float playerY;

	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
		portalLocation = GameObject.FindWithTag ("Portal").transform;
		location = new Vector3 (portalLocation.position.x, portalLocation.position.y, 0);
		PortalController temp = portalLocation.GetComponent<PortalController> ();
		nextScene = temp.nextScene;
		temp.deactivate ();

		target.GetComponent<Player> ().getSpawnLocation (playerX, playerY);

	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
		Player killCount = target.GetComponent<Player> ();
		if (killCount.killCount >= monstersNeeded || killCount.killedBoss) {
			if (portalSpawned == false) {
				killCount.resetKills ();
				PortalController temp = portal.GetComponent<PortalController> ();
				temp.setNextScene (nextScene);
				Instantiate (portal, location, Quaternion.identity);
				portalSpawned = true;
			}
		}
	}
}
