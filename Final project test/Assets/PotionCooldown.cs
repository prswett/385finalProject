using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionCooldown : MonoBehaviour {

	public Image cooldown;
	public PotionStats temp;
	// Use this for initialization
	void Start () {
		cooldown = GetComponent<Image> ();
		temp = GetComponentInParent<PotionStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (temp.type == "Health") {
			cooldown.fillAmount = 1 - (Time.time - PlayerStatistics.healthPotTimer) / 5;
		} else if (temp.type == "Mana") {
			cooldown.fillAmount = 1 - (Time.time - PlayerStatistics.manaPotTimer) / 5;
		}
	}
}
