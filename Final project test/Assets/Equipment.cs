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
	public List<GameObject> slots = new List<GameObject>();

	public static List<ItemStats> saveItems = new List<ItemStats>();
	// Use this for initialization

	public void save() {
		saveItems = new List<ItemStats> ();
		for (int i = 0; i < slotAmount; i++) {
			if (slots [i].GetComponent<EquipmentSlot> ().item != null) {
				saveItems.Add (slots [i].GetComponent<EquipmentSlot> ().item.GetComponent<ItemStats> ());
			} else {
				ItemStats temp = new ItemStats ();
				temp.loadStats ();
				saveItems.Add (temp);
			}
		}
	}

	void Awake() {
		database = GetComponent<ItemDatabase>();

		slotAmount = 6;
		inventoryPanel = GameObject.Find("Inventory Panel");
		// slotPanel = inventoryPanel.transform.Find("Slot Panel").gameObject;

		for (int i = 0; i < slotAmount; i++)
		{
			slots.Add(Instantiate(inventorySlot));

			slots[i].GetComponent<EquipmentSlot> ().id = i;
			slots[i].transform.SetParent(slotPanel.transform);

		}
	}
		
	public void AddItem(Item id, int slot) {
		if (id.ID < 0) {
			return;
		}
		EquipmentSlot temp = slots[slot].GetComponent<EquipmentSlot>();
		temp.item = Instantiate (inventoryItem);
		temp.item.transform.SetParent (slots [slot].transform);
		temp.item.transform.position = slots [slot].transform.position;
		temp.item.GetComponent<Image>().sprite = database.FetchItemByID (id.ID).Sprite;
		temp.item.transform.localScale = new Vector3 (.5f, .5f, 0);
		temp.item.GetComponent<ItemObject> ().slot = slot;
		temp.item.GetComponent<ItemStats> ().loadStats(id);
	}

	public void AddItem(Item id, int slot, bool equipped) {
		if (id.ID < 0) {
			return;
		}
		EquipmentSlot temp = slots[slot].GetComponent<EquipmentSlot>();
		temp.item = Instantiate (inventoryItem);
		temp.item.transform.SetParent (slots [slot].transform);
		temp.item.transform.position = slots [slot].transform.position;
		temp.item.GetComponent<Image>().sprite = database.FetchItemByID (id.ID).Sprite;
		temp.item.transform.localScale = new Vector3 (.5f, .5f, 0);
		temp.item.GetComponent<ItemObject> ().slot = slot;
		temp.item.GetComponent<ItemObject> ().equipped = equipped;
		temp.item.GetComponent<ItemStats> ().loadStats(id);
	}

	public void AddItem(ItemStats id, int slot, bool equipped) {
		if (id.ID < 0) {
			return;
		}
		EquipmentSlot temp = slots[slot].GetComponent<EquipmentSlot>();
		temp.item = Instantiate (inventoryItem);
		temp.item.transform.SetParent (slots [slot].transform);
		temp.item.transform.position = slots [slot].transform.position;
		temp.item.GetComponent<Image>().sprite = database.FetchItemByID (id.ID).Sprite;
		temp.item.transform.localScale = new Vector3 (.5f, .5f, 0);
		temp.item.GetComponent<ItemObject> ().slot = slot;
		temp.item.GetComponent<ItemObject> ().equipped = equipped;
		temp.item.GetComponent<ItemStats> ().loadStats(id);
	}

	public void RemoveItemSlot(int slot) {
		EquipmentSlot temp = slots[slot].GetComponent<EquipmentSlot>();
		Destroy (temp.item);
		temp.item = null;
	}
}
