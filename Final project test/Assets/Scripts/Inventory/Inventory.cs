using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class Inventory : MonoBehaviour
{

    GameObject inventoryPanel;
    public GameObject slotPanel;
    public GameObject inventorySlot;
    public GameObject inventoryItem;
    ItemDatabase database;

    private int slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

	public static List<Item> saveItems = new List<Item>();

	public void save() {
		saveItems = items;
	}

	void Awake() {
		database = GetComponent<ItemDatabase>();

		slotAmount = 10;
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

    void Start()
    {
        
    }
		
    public void AddItem(int id)
    {
		if (id < 0) {
			return;
		}
        Item itemToAdd = database.FetchItemByID(id);

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == -1)
            {
                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(inventoryItem);

				itemObj.GetComponent<ItemData> ().item = itemToAdd;
				itemObj.GetComponent<ItemData> ().slot = i;
                itemObj.transform.SetParent(slots[i].transform);
				itemObj.transform.position = slots [i].transform.position;
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.name = itemToAdd.Title;
                ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                data.amount = 1;
                break;

        	}
    	}

    }

	public void AddItem(Item id) {
		if (id.ID < 0) {
			return;
		}
		for (int i = 0; i < items.Count; i++)
		{
			if (items[i].ID == -1)
			{
				items[i] = id;
				GameObject itemObj = Instantiate(inventoryItem);

				itemObj.GetComponent<ItemData> ().item = id;
				itemObj.GetComponent<ItemData> ().slot = i;
				itemObj.transform.SetParent(slots[i].transform);
				itemObj.transform.position = slots [i].transform.position;
				itemObj.GetComponent<Image>().sprite = id.Sprite;
				itemObj.name = id.Title;
				ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
				data.amount = 1;
				break;
			}
		}
	}

	public void RemoveItem(int id) {
		for (int i = 0; i < items.Count; i++) {
			if (items [i].ID != -1 && items [i].ID == id) {
				Destroy (slots [i].transform.GetChild (0).gameObject);
				items [i] = new Item ();
				break;
			}
		}
	}

	public void RemoveItemSlot(int slot) {
		Destroy (slots [slot].transform.GetChild (0).gameObject);
		items [slot] = new Item ();
	}

	public Item getItem(int slot) {
		return items [slot];
	}

    bool CheckIfItemIsInInventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == item.ID)
            {
                return true;
            }
        }
        return false;
    }

}