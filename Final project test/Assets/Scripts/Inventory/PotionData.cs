/**using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class PotionData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {
	public Potion potion;
	public int amount;
	public int slot;

	private PotionInventory inv;
	private PotionTooltip tooltip;
	private Vector2 offset;

	void Start () {
		inv = GameObject.Find("InventoryP").GetComponent<PotionInventory>();
		tooltip = inv.GetComponent<PotionTooltip>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerClick(PointerEventData eventData) {
		if (eventData.button == PointerEventData.InputButton.Right) {
			if (potion.type == "Health") {
				int healing = potion.healing;
				if (PlayerStatistics.health <= PlayerStatistics.maxHealth - healing) {
					PlayerStatistics.health += healing;
				} else {
					PlayerStatistics.health = PlayerStatistics.maxHealth;
				}
				inv.RemoveItem (potion.ID);
			}
			if (potion.type == "Mana") {
				int healing = potion.healing;
				if (PlayerStatistics.mana <= PlayerStatistics.maxMana - healing) {
					PlayerStatistics.mana += healing;
				} else {
					PlayerStatistics.mana = PlayerStatistics.maxMana;
				}
				inv.RemoveItem (potion.ID);
			}
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if(potion != null)
		{
			this.transform.SetParent(this.transform.parent.parent);
			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (potion != null)
		{
			this.transform.position = eventData.position - offset;

		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		this.transform.SetParent(inv.slots[slot].transform);
		this.transform.position = inv.slots[slot].transform.position;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
		this.transform.position = eventData.position - offset;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.Activate(potion);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.Deactivate();
	}
}
*/