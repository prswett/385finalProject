using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
    public int id;
    public Inventory inv;
	public GameObject item;
    void Awake()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
		if (item == null) {
			ItemObject droppedItem = eventData.pointerDrag.GetComponent<ItemObject> ();
			ItemStats droppedStats = eventData.pointerDrag.GetComponent<ItemStats> ();
			if (!droppedItem.equipped) {
				if (droppedItem.slot != id) {
					inv.RemoveItemSlot (droppedItem.slot);
					inv.AddItemSlot (id, droppedStats);
				}
			}
		} else {
			ItemObject droppedItem = eventData.pointerDrag.GetComponent<ItemObject> ();
			ItemStats droppedStats = eventData.pointerDrag.GetComponent<ItemStats> ();

			ItemObject replacedItem = item.GetComponent<ItemObject> ();
			ItemStats replacedStats = item.GetComponent<ItemStats> ();
			if (!droppedItem.equipped) {
				if (droppedItem.slot != id) {
					inv.RemoveItemSlot (droppedItem.slot);
					inv.RemoveItemSlot (id);

					inv.AddItemSlot (id, droppedStats);
					inv.AddItemSlot (droppedItem.slot, replacedStats);
				}
			}
		}
    }

}
