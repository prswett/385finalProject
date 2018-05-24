using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CurrentTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	private GameObject tooltip;
	public Player player;
	string line;
	void Awake() {
		tooltip = GameObject.Find ("CurrentSpellTooltip");
		tooltip.SetActive (false);
		player = GameObject.Find ("Player").GetComponent<Player> ();
	}

	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		line = player.spells.descriptions [player.spells.selectedSpell];
		tooltip.transform.GetChild (0).GetComponent<Text> ().text = line;
		tooltip.SetActive (true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.SetActive (false);
	}
}
