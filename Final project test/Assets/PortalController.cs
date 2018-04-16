using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour {
	public Transform target;
	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			if (transform.position.x - target.position.x < 0.2 && transform.position.y 
				- target.position.y < 0.2){
				Player player = target.GetComponent<Player> ();
				player.savePlayer ();
				int scene = SceneManager.GetActiveScene ().buildIndex;
				SceneManager.LoadScene (scene + 1, LoadSceneMode.Single);
			}
		}
	}
}
	
