using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChestController : MonoBehaviour {
	bool near = false;
	public Transform target;
	Player player;
	public TextMesh control;
	public Animator anim;

	public bool opened = false;

	public GameObject item;
	public int numberHeld = 1;

	public float countdownTime = 3f;
	public float startTime;

	void Awake() {
		target = GameObject.FindWithTag ("Player").transform;
		player = target.GetComponent<Player> ();
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		startTime = 3f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.F)) {
			if (near && !opened) {
				anim.SetBool ("Open", true);
				float length = 1f;
				float spawnLocation = length / numberHeld;
				for (int i = 0; i < numberHeld; i++) {
					Instantiate (item, new Vector3 ((transform.position.x - (length / 2f)) + (i * spawnLocation), transform.position.y, 0), 
						Quaternion.identity);
				}
				opened = true;
			}
		}
	}

	void FixedUpdate() {
		if (opened) {
			float alpha = 1 / startTime * countdownTime;
			Color tempColor = GetComponent<SpriteRenderer> ().color;
			tempColor.a = alpha;
			GetComponent<SpriteRenderer> ().color = tempColor;
			countdownTime -= Time.deltaTime;
			Invoke ("destroy", 5f);
		}
	}

	void destroy() {
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			near = true;
			control.text = "F";
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			near = false;
			control.text  = "";
		}
	}
}
