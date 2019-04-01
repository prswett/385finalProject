﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionTooltip : MonoBehaviour {
	
	private PotionStats potion;
	private string data;
	private GameObject tooltip;

	void Start()
	{
		tooltip = GameObject.Find("PotionTooltip");
		tooltip.SetActive(false);
	}

	void Update()
	{
		if (tooltip.activeSelf)
		{
			tooltip.transform.position = Input.mousePosition;
		}
	}

	public void Activate(PotionStats potion)
	{
		this.potion = potion;
		ConstructDataString();
		tooltip.SetActive(true);
	}

	public void Deactivate()
	{
		tooltip.SetActive(false);
	}

	public void ConstructDataString()
	{
		data = "<color=#0473f0><b>" + potion.Title + "</b></color>\n" + potion.Description + "\nPercent Heal: " + potion.healing;
		tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
	}
}
