using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PotionSlot : MonoBehaviour, IDropHandler {
	public int id;
	private PotionInventory inv;

	void Start () {
		inv = GameObject.Find("InventoryP").GetComponent<PotionInventory>();
	}
	
	public void OnDrop(PointerEventData eventData)
	{
		PotionData droppedPotion = eventData.pointerDrag.GetComponent<PotionData>();
		if(inv.potions[id].ID == -1)
		{
			inv.potions[droppedPotion.slot] = new Potion();
			inv.potions[id] = droppedPotion.potion;
			droppedPotion.slot = id;
		}
		else
		{

			Transform potion = this.transform.GetChild(0);
			potion.GetComponent<PotionData> ().slot = droppedPotion.slot;
			potion.transform.SetParent (inv.slots [droppedPotion.slot].transform);
			potion.transform.position = inv.slots [droppedPotion.slot].transform.position;

			inv.potions [droppedPotion.slot] = potion.GetComponent<PotionData> ().potion;
			inv.potions [id] = droppedPotion.potion;
			droppedPotion.slot = id;
			/*
            Transform potion = this.transform.GetChild(0);
            potion.GetComponent<potionData>().slot = droppedPotion.slot;
            potion.transform.SetParent(inv.slots[droppedPotion.slot].transform);
            potion.transform.position = inv.slots[droppedPotion.slot].transform.position;

            droppedPotion.slot = id;
            droppedPotion.transform.SetParent(this.transform);
            droppedPotion.transform.position = this.transform.position;

            inv.potions[droppedPotion.slot] = potion.GetComponent<potionData>().potion;
            inv.potions[id] = droppedPotion.potion;
            */
		}
	}
}
