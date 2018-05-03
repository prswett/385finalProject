using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;


public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	public Item item;
	public int amount;
	public int slot;
	public Player target;

	private Inventory inv;
	private Tooltip tooltip;
	private Vector2 offset;

	public PlayerResources player;
	public bool noDelete = false;
	public bool showQuestion = false;
	CanvasController question;

	void Start()
	{
		inv = GameObject.Find("Inventory").GetComponent<Inventory>();
		tooltip = inv.GetComponent<Tooltip>();
		player = GameObject.Find ("Player").GetComponent<PlayerResources> ();
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		question = target.playerCanvas;
	}

	void Update() {
		if (showQuestion) {
			if (question.clicked) {
				if (question.answer == true) {
					inv.RemoveItemSlot (slot);
					question.hideQuestion ();
					question.clicked = false;
				} else {
					noDelete = false;
					showQuestion = false;
					question.hideQuestion ();
					question.clicked = false;
				}
			}
		}
	}
		
	public void OnPointerClick(PointerEventData eventData) {
		if (eventData.button == PointerEventData.InputButton.Right) {
			
			if (item.type == "Helmet") {
				player.changeHelmet ("DrawingsV2/Items/Equipment/" + item.Slug);
				PlayerStatistics.str += item.str;
				PlayerStatistics.dex += item.dex;
				PlayerStatistics.wis += item.wis;
				PlayerStatistics.luk += item.luk;
				PlayerStatistics.atk += item.atk;
				PlayerStatistics.def += item.atk;
			}
			if (item.type == "Armor") {
				player.changeArmor ("DrawingsV2/Items/Equipment/" + item.Slug);
				PlayerStatistics.str += item.str;
				PlayerStatistics.dex += item.dex;
				PlayerStatistics.wis += item.wis;
				PlayerStatistics.luk += item.luk;
				PlayerStatistics.atk += item.atk;
				PlayerStatistics.def += item.atk;
			}
			if (item.type == "Sword") {
				player.changeSword ("DrawingsV2/Items/Equipment/" + item.Slug);
				PlayerStatistics.str += item.str;
				PlayerStatistics.dex += item.dex;
				PlayerStatistics.wis += item.wis;
				PlayerStatistics.luk += item.luk;
				PlayerStatistics.atk += item.atk;
				PlayerStatistics.def += item.atk;
			}
			if (item.type == "Spear") {
				player.changeSpear ("DrawingsV2/Items/Equipment/" + item.Slug);
				PlayerStatistics.str += item.str;
				PlayerStatistics.dex += item.dex;
				PlayerStatistics.wis += item.wis;
				PlayerStatistics.luk += item.luk;
				PlayerStatistics.atk += item.atk;
				PlayerStatistics.def += item.atk;
			}
			if (item.type == "Axe") {
				player.changeAxe ("DrawingsV2/Items/Equipment/" + item.Slug);
				PlayerStatistics.str += item.str;
				PlayerStatistics.dex += item.dex;
				PlayerStatistics.wis += item.wis;
				PlayerStatistics.luk += item.luk;
				PlayerStatistics.atk += item.atk;
				PlayerStatistics.def += item.atk;
			}
			if (item.type == "Dagger") {
				player.changeDagger ("DrawingsV2/Items/Equipment/" + item.Slug);
				PlayerStatistics.str += item.str;
				PlayerStatistics.dex += item.dex;
				PlayerStatistics.wis += item.wis;
				PlayerStatistics.luk += item.luk;
				PlayerStatistics.atk += item.atk;
				PlayerStatistics.def += item.atk;
			}
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if(item != null)
		{
			noDelete = false;
			this.transform.SetParent(this.transform.parent.parent);
			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (item != null)
		{
			this.transform.position = eventData.position - offset;

		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		this.transform.SetParent(inv.slots[slot].transform);
		this.transform.position = inv.slots[slot].transform.position;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		if (noDelete == false) {
			showQuestion = true;
			question.showQuestion ();
			Debug.Log ("hello");
		} else {
			showQuestion = false;
		}

	}

	public void OnPointerDown(PointerEventData eventData)
	{
		offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
		this.transform.position = eventData.position - offset;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.Activate(item);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.Deactivate();
	}
}
