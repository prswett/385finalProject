﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentTooltip : MonoBehaviour {

	private ItemStats item;
	private string data;
	private GameObject tooltip;

	void Start()
	{
		tooltip = GameObject.Find("EquipTooltip");
		tooltip.SetActive(false);
	}

	void Update()
	{
		if (tooltip.activeSelf)
		{
			tooltip.transform.position = Input.mousePosition;
		}
	}

	public void Activate(ItemStats item)
	{
		this.item = item;
		ConstructDataString();
		tooltip.SetActive(true);
	}

	public void Deactivate()
	{
		tooltip.SetActive(false);
	}

	public void ConstructDataString()
	{
		data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + "\nStr: " + item.str + "\nDex: " + item.dex
			+ "\nWis: " + item.wis + "\nLuk: " + item.luk + "\nAtk: " + item.atk + "\nDef: " + item.def + "\nValue: " + item.Value;
		tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
	}
}
