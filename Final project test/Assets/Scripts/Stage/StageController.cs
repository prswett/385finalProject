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

	public Text portalSpawn;
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

		target.GetComponent<Player> ().getSpawnLocation (playerX, playerY);

	}
	// Use this for initialization
	void Start () {
		killCount = target.GetComponent<Player> ();
	}

	// Update is called once per frame
	void Update () {
		int mon = monstersNeeded - killCount.killCount;
		monsters.text = mon.ToString ();
		if (portalSpawned) {
			portalSpawn.text = "Portal has been spawned";
		}
		if (killCount.killCount >= monstersNeeded || killCount.killedBoss) {
			if (portalSpawned == false) {
				killCount.resetKills ();
				PortalController temp = portal.GetComponent<PortalController> ();
				temp.gameObject.SetActive (true);
				temp.setNextScene (nextScene);
				Instantiate (portal, location, Quaternion.identity);
				portalSpawned = true;
			}
		}
	}
}
