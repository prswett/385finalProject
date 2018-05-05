/**using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;


public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	public Item item;
	public int amount;
	public int slot;
	public Player target;

	public int random;

	private Inventory inv;
	private Equipment eInv;
	public Tooltip tooltip;
	public EquipmentTooltip eTooltip;
	private Vector2 offset;

	public PlayerResources player;
	public bool noDelete = false;
	public bool showQuestion = false;
	CanvasController question;

	public bool equipped = false;

	void Awake() {
		inv = GameObject.Find("Inventory").GetComponent<Inventory>();
		eInv = GameObject.Find ("Equipment").GetComponent<Equipment> ();
		tooltip = inv.GetComponent<Tooltip>();
		player = GameObject.Find ("Player").GetComponent<PlayerResources> ();
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		question = target.playerCanvas;

		random = UnityEngine.Random.Range (0, 20000);
	}

	void Start()
	{
		
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
		if (equipped == false) {
			if (eventData.button == PointerEventData.InputButton.Right) {
			
				Item temp = null;
				if (item.type == "Helmet") {
					if (eInv.items [0].ID != -1) {
						eInv.items [0] = null;
						inv.AddItem(item);
						eInv.RemoveItemSlot(0);
					}
					

						inv.RemoveItemSlot (slot);

						
						eInv.AddItem (item, 0, true);
						tooltip.Deactivate ();
						player.changeHelmet ("DrawingsV2/Items/Equipment/" + item.Slug);
						PlayerStatistics.str += item.str;
						PlayerStatistics.dex += item.dex;
						PlayerStatistics.wis += item.wis;
						PlayerStatistics.luk += item.luk;
						PlayerStatistics.atk += item.atk;
						PlayerStatistics.def += item.atk;
					Debug.Log (PlayerStatistics.str);
				}
				if (item.type == "Armor") {
					if (eInv.items [0] != null) {
						temp = eInv.items [1];
					}
					eInv.AddItem (item, 1, true);
					inv.RemoveItemSlot (slot);
					if (eInv.items [0] != null) {
						inv.AddItem (temp);
					}
					tooltip.Deactivate();
					player.changeArmor ("DrawingsV2/Items/Equipment/" + item.Slug);
					PlayerStatistics.str += item.str;
					PlayerStatistics.dex += item.dex;
					PlayerStatistics.wis += item.wis;
					PlayerStatistics.luk += item.luk;
					PlayerStatistics.atk += item.atk;
					PlayerStatistics.def += item.atk;
				}
				if (item.type == "Sword") {
					if (eInv.items [0] != null) {
						temp = eInv.items [2];
					}
					eInv.AddItem (item, 2, true);
					inv.RemoveItemSlot (slot);
					if (eInv.items [0] != null) {
						inv.AddItem (temp);
					}
					tooltip.Deactivate();
					player.changeSword ("DrawingsV2/Items/Equipment/" + item.Slug);
					PlayerStatistics.str += item.str;
					PlayerStatistics.dex += item.dex;
					PlayerStatistics.wis += item.wis;
					PlayerStatistics.luk += item.luk;
					PlayerStatistics.atk += item.atk;
					PlayerStatistics.def += item.atk;
				}
				if (item.type == "Spear") {
					if (eInv.items [0] != null) {
						temp = eInv.items [3];
					}
					eInv.AddItem (item, 3, true);
					inv.RemoveItemSlot (slot);
					if (eInv.items [0] != null) {
						inv.AddItem (temp);
					}
					tooltip.Deactivate();
					player.changeSpear ("DrawingsV2/Items/Equipment/" + item.Slug);
					PlayerStatistics.str += item.str;
					PlayerStatistics.dex += item.dex;
					PlayerStatistics.wis += item.wis;
					PlayerStatistics.luk += item.luk;
					PlayerStatistics.atk += item.atk;
					PlayerStatistics.def += item.atk;
				}
				if (item.type == "Axe") {
					if (eInv.items [0] != null) {
						temp = eInv.items [4];
					}
					eInv.AddItem (item, 4, true);
					inv.RemoveItemSlot (slot);
					if (eInv.items [0] != null) {
						inv.AddItem (temp);
					}
					tooltip.Deactivate();
					player.changeAxe ("DrawingsV2/Items/Equipment/" + item.Slug);
					PlayerStatistics.str += item.str;
					PlayerStatistics.dex += item.dex;
					PlayerStatistics.wis += item.wis;
					PlayerStatistics.luk += item.luk;
					PlayerStatistics.atk += item.atk;
					PlayerStatistics.def += item.atk;
				}
				if (item.type == "Dagger") {
					if (eInv.items [0] != null) {
						temp = eInv.items [5];
					}
					eInv.AddItem (item, 5, true);
					inv.RemoveItemSlot (slot);
					if (eInv.items [0] != null) {
						inv.AddItem (temp);
					}
					tooltip.Deactivate();
					player.changeDagger ("DrawingsV2/Items/Equipment/" + item.Slug);
					PlayerStatistics.str += item.str;
					PlayerStatistics.dex += item.dex;
					PlayerStatistics.wis += item.wis;
					PlayerStatistics.luk += item.luk;
					PlayerStatistics.atk += item.atk;
					PlayerStatistics.def += item.def;
				}
			}
		} else {
			if (eventData.button == PointerEventData.InputButton.Right) {
				PlayerStatistics.str -= item.str;
				PlayerStatistics.dex -= item.dex;
				PlayerStatistics.wis -= item.wis;
				PlayerStatistics.luk -= item.luk;
				PlayerStatistics.atk -= item.atk;
				PlayerStatistics.def -= item.def;
				Debug.Log (PlayerStatistics.str);
				inv.AddItem(item);
				eInv.RemoveItemSlot(slot);
				eTooltip.Deactivate();
			}
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (!equipped) {
			if (item != null) {
				noDelete = false;
				this.transform.SetParent (this.transform.parent.parent);
				GetComponent<CanvasGroup> ().blocksRaycasts = false;
			}
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (!equipped) {
			if (item != null) {
				this.transform.position = eventData.position - offset;
			}
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (!equipped) {
			this.transform.SetParent (inv.slots [slot].transform);
			this.transform.position = inv.slots [slot].transform.position;
			GetComponent<CanvasGroup> ().blocksRaycasts = true;
			if (noDelete == false) {
				showQuestion = true;
				question.showQuestion ();
			} else {
				showQuestion = false;
			}
		}

	}

	public void OnPointerDown(PointerEventData eventData)
	{
		offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
		this.transform.position = eventData.position - offset;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (equipped) {
			eTooltip.Activate (item);
		} else {
			//tooltip.Activate (item);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (equipped) {
			eTooltip.Deactivate();
		} else {
			tooltip.Deactivate ();
		}
	}
}
*/