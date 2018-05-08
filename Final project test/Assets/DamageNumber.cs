using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumber : MonoBehaviour {

	public TextMesh control;
	// Use this for initialization
	void Start () {
		control = GetComponent<TextMesh> ();
		Invoke ("destroy", .03f);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position += Vector3.up * 1 * Time.deltaTime;
	}

	public void setNumber(int damage) {
		control = GetComponent<TextMesh> ();
		control.text = "" + damage;
	}

	public void destroy() {
		Destroy (gameObject);
	}
}
