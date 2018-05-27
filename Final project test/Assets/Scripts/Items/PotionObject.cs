using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PotionObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	public int slot;
	public int amount = 1;
	public Vector2 offset;
	public PotionInventory pInv;

	public PotionTooltip tooltip;

	public bool noDelete = false;
	public bool showQuestion = false;
	CanvasController question;
	public Player target;

	public bool tutorial = false;
	public bool multiDelete = false;
	// Use this for initialization
	void Start () {
		pInv = GameObject.Find ("InventoryP").GetComponent<PotionInventory> ();
		tooltip = pInv.GetComponent<PotionTooltip> ();

		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
			question = target.playerCanvas;
	}

	public void OnPointerClick(PointerEventData eventData) {
		if (eventData.button == PointerEventData.InputButton.Right) {
			if (PlayerStatistics.health > 0) {
				PotionStats temp = pInv.slots [slot].GetComponent<PotionSlot> ().potion.GetComponent<PotionStats> ();
				if (temp.type == "Health") {
					int healing = (int)((PlayerStatistics.maxHealth / 100) * temp.healing);
					if (PlayerStatistics.health <= PlayerStatistics.maxHealth - healing) {
						PlayerStatistics.health += healing;
					} else {
						PlayerStatistics.health = PlayerStatistics.maxHealth;
					}
					amount--;
					transform.GetChild (0).GetComponent<Text> ().text = amount.ToString ();
					if (amount == 0) {
						tooltip.Deactivate ();
						pInv.RemoveItemSlot (slot);
					}
				}

				if (temp.type == "Mana") {
					int healing = (int)((PlayerStatistics.maxMana / 100) * temp.healing);
					if (PlayerStatistics.mana <= PlayerStatistics.maxMana - healing) {
						PlayerStatistics.mana += healing;
					} else {
						PlayerStatistics.mana = PlayerStatistics.maxMana;
					}
					amount--;
					transform.GetChild (0).GetComponent<Text> ().text = amount.ToString ();

					if (amount == 0) {
						tooltip.Deactivate ();
						pInv.RemoveItemSlot (slot);
					}
				}

				if (temp.type == "Gold") {
					target.goldBoost = true;
					target.goldTime = Time.time;
					amount--;
					transform.GetChild (0).GetComponent<Text> ().text = amount.ToString ();
					if (amount == 0) {
						tooltip.Deactivate ();
						pInv.RemoveItemSlot (slot);
					}
				}

				if (temp.type == "Exp") {
					target.expBoost = true;
					target.expTime = Time.time;
					amount--;
					transform.GetChild (0).GetComponent<Text> ().text = amount.ToString ();
					if (amount == 0) {
						tooltip.Deactivate ();
						pInv.RemoveItemSlot (slot);
					}
				}
			}
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
		this.transform.position = eventData.position - offset;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		noDelete = false;
		this.transform.SetParent (this.transform.parent.parent);
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		this.transform.position = eventData.position - offset;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		float x = this.transform.position.x;
		float y = this.transform.position.y;

		this.transform.SetParent (pInv.slots [slot].transform);
		this.transform.position = pInv.slots [slot].transform.position;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if ((x < this.transform.position.x - 30 || x > this.transform.position.x + 30) || (y < this.transform.position.y - 30 || y > this.transform.position.y + 30)) {
			if (noDelete == false) {
				showQuestion = true;
				question.showQuestion ();
			} else {
				showQuestion = false;
			}
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.Activate (pInv.slots [slot].GetComponent<PotionSlot> ().potion.GetComponent<PotionStats> ());
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.Deactivate ();
	}

	void Update () {
		GameObject delete = GameObject.Find ("Delete");
		if (delete != null) {
			if (showQuestion) {
				if (target != null) {
					target.tryingToDelete = true;
					if (question.clicked) {
						if (question.answer == true) {
							PlayerStatistics.coins += pInv.slots [slot].GetComponent<PotionSlot> ().potion.GetComponent<PotionStats> ().Value;
							pInv.RemoveItemSlot (slot);
							question.hideQuestion ();
							question.clicked = false;
							target.tryingToDelete = false;
						} else {
							noDelete = false;
							showQuestion = false;
							question.hideQuestion ();
							question.clicked = false;
							target.tryingToDelete = false;
						}
					} else if (Input.GetKeyDown (KeyCode.Return)) {
						PlayerStatistics.coins += pInv.slots [slot].GetComponent<PotionSlot> ().potion.GetComponent<PotionStats> ().Value;
						pInv.RemoveItemSlot (slot);
						question.hideQuestion ();
						question.clicked = false;
						target.tryingToDelete = false;

					}
				}


			}
		}

	}
}
