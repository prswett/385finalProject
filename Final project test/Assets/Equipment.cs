using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class Equipment : MonoBehaviour {

	GameObject inventoryPanel;
	public GameObject slotPanel;
	public GameObject inventorySlot;
	public GameObject inventoryItem;
	ItemDatabase database;

	private int slotAmount;
	public List<Item> items = new List<Item>();
	public List<GameObject> slots = new List<GameObject>();

	public static List<Item> saveItems = new List<Item>();
	// Use this for initialization

	public void save() {
		saveItems = items;
	}

	void Awake() {
		database = GetComponent<ItemDatabase>();

		slotAmount = 6;
		inventoryPanel = GameObject.Find("Inventory Panel");
		// slotPanel = inventoryPanel.transform.Find("Slot Panel").gameObject;

		for (int i = 0; i < slotAmount; i++)
		{
			items.Add(new Item());
			slots.Add(Instantiate(inventorySlot));

			slots[i].GetComponent<Slot> ().id = i;
			slots[i].transform.SetParent(slotPanel.transform);

		}
	}

	//Edit for slot number
	public void AddItem(Item id, int slot) {
		if (id.ID < 0) {
			return;
		}
				items[slot] = id;
				GameObject itemObj = Instantiate(inventoryItem);

				itemObj.GetComponent<ItemData> ().item = id;
				itemObj.GetComponent<ItemData> ().slot = slot;
				itemObj.transform.SetParent(slots[slot].transform);
				itemObj.transform.position = slots [slot].transform.position;
				itemObj.GetComponent<Image>().sprite = id.Sprite;
				itemObj.name = id.Title;
				ItemData data = slots[slot].transform.GetChild(0).GetComponent<ItemData>();
				data.amount = 1;
	}
}
