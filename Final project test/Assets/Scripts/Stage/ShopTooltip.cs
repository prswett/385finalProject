using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	private GameObject tooltip;
	public Player player;
	public string line;
	void Awake() {
		tooltip = GameObject.Find ("ShopTooltip");
		if (tooltip != null) {
			tooltip.SetActive (false);
		}
		player = GameObject.Find ("Player").GetComponent<Player> ();
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (tooltip.activeSelf)
		{
			tooltip.transform.position = Input.mousePosition;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.transform.GetChild (0).GetComponent<Text> ().text = line;
		tooltip.SetActive (true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.SetActive (false);
	}

	public void reset() {
		tooltip.transform.GetChild (0).GetComponent<Text> ().text = line;
	}
}
