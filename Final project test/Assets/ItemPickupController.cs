using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemPickupController : MonoBehaviour {

	public Text item0;
	public Text item1;
	public Text item2;
	public Text item3;
	public Text item4;
	public Text item5;

	public float time0;
	public float time1;
	public float time2;
	public float time3;
	public float time4;
	public float time5;

	// Use this for initialization
	void Start () {
		time0 = Time.time;
		time1 = Time.time;
		time2 = Time.time;
		time3 = Time.time;
		time4 = Time.time;
		time5 = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - time0 > 3f) {
			item0.text = "";
		}
		if (Time.time - time1 > 3f) {
			item1.text = "";
		}
		if (Time.time - time2 > 3f) {
			item2.text = "";
		}
		if (Time.time - time3 > 3f) {
			item3.text = "";
		}
		if (Time.time - time4 > 3f) {
			item4.text = "";
		}
		if (Time.time - time5 > 3f) {
			item5.text = "";
		}
	}

	public void showItem(string text) {
		item5.text = item4.text;
		item4.text = item3.text;
		item3.text = item2.text;
		item2.text = item1.text;
		item1.text = item0.text;
		item0.text = text;

		time5 = time4;
		time4 = time3;
		time3 = time2;
		time2 = time1;
		time1 = time0;
		time0 = Time.time;
	}
}
