using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text level = GetComponent<Text> ();
		level.text = "Level: " + PlayerStatistics.level;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateLevel() {
		Text level = GetComponent<Text> ();
		level.text = "Level: " + PlayerStatistics.level;
	}
}
