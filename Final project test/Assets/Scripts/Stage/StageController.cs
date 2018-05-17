using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageController : MonoBehaviour {

	public Transform target;
	public Transform portalLocation;
	public bool portalSpawned = false;
	public GameObject portal;
	public Vector3 location;
	public bool spawned = false;
	public int monstersNeeded;
	int nextScene;
	Player killCount;

	public Text monsters;

	public float playerX;
	public float playerY;

	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
		portalLocation = GameObject.FindWithTag ("Portal").transform;
		location = new Vector3 (portalLocation.position.x, portalLocation.position.y, 0);
		PortalController temp = portalLocation.GetComponent<PortalController> ();
		nextScene = temp.nextScene;
		temp.deactivate ();

	}
	// Use this for initialization
	void Start () {
		target.GetComponent<Player> ().getSpawnLocation (playerX, playerY);
		killCount = target.GetComponent<Player> ();
	}

	// Update is called once per frame
	void Update () {
		int mon = monstersNeeded - killCount.killCount;
		if (mon >= 0 && !portalSpawned) {
			monsters.text = mon.ToString () + " Monsters Remaining";
		}
		if (portalSpawned) {
			monsters.text = "Find the portal to move on";
		}
		if (killCount.killCount >= monstersNeeded || killCount.killedBoss) {
			if (portalSpawned == false) {
				killCount.stageCount++;
				PortalController temp = portal.GetComponent<PortalController> ();
				temp.gameObject.SetActive (true);
				temp.setNextScene (nextScene);
				Instantiate (portal, location, Quaternion.identity);
				portalSpawned = true;
			}
		}
	}
}
