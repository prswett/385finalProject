using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PotionSlot : MonoBehaviour, IDropHandler {
	public int id;
	public PotionInventory pInv;
	public GameObject potion;

	void Start () {
		pInv = GameObject.Find("InventoryP").GetComponent<PotionInventory>();
	}
	
	public void OnDrop(PointerEventData eventData)
	{
		if (potion == null) {
			PotionObject droppedPotion = eventData.pointerDrag.GetComponent<PotionObject> ();
			PotionStats droppedStats = eventData.pointerDrag.GetComponent<PotionStats> ();

			if (droppedPotion.slot != id) {
				pInv.RemoveItemSlot (droppedPotion.slot);
				pInv.AddItemSlot (id, droppedStats, droppedPotion.amount);
			}
		} else {
			PotionObject droppedPotion = eventData.pointerDrag.GetComponent<PotionObject> ();
			PotionStats droppedStats = eventData.pointerDrag.GetComponent<PotionStats> ();

			PotionObject replacedPotion = potion.GetComponent<PotionObject> ();
			PotionStats replacedStats = potion.GetComponent<PotionStats> ();

			if (droppedPotion.slot != id) {
				pInv.RemoveItemSlot (droppedPotion.slot);
				pInv.RemoveItemSlot (id);

				pInv.AddItemSlot (id, droppedStats, droppedPotion.amount);
				pInv.AddItemSlot (droppedPotion.slot, replacedStats, replacedPotion.amount);
			}
		}
	}
}
