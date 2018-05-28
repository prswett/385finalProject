using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMusic : MonoBehaviour {
	public AudioSource townMusic;
	public AudioSource shopMusic;
	public AudioSource dungeonMusic;
	public AudioSource bossMusic;

	int sceneNumber;

	void Start () {
		TM ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void SM() {
		townMusic.Stop ();
		shopMusic.Play ();
		dungeonMusic.Stop ();
		bossMusic.Stop ();
	}

	public void TM() {
		townMusic.Play ();
		shopMusic.Stop ();
		dungeonMusic.Stop ();
		bossMusic.Stop ();
	}

	public void DM() {
		townMusic.Stop ();
		shopMusic.Stop ();
		dungeonMusic.Play ();
		bossMusic.Stop ();
	}

	public void BM() {
		townMusic.Stop ();
		shopMusic.Stop ();
		dungeonMusic.Stop ();
		bossMusic.Play ();
	}


}
