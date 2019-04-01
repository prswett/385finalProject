using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PotionDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler  {

	public string line;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		ShopTooltip temp = transform.parent.GetComponent<ShopTooltip> ();
		temp.line = line;
		temp.reset ();
	}

	public void OnPointerExit(PointerEventData eventData)
	{

	}
}
