using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionTooltip : MonoBehaviour {
	
	private Potion potion;
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

	public void Activate(Potion potion)
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
		data = "<color=#0473f0><b>" + potion.Title + "</b></color>\n" + potion.Description + "\nHealing: " + potion.healing;
		tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
	}
}
