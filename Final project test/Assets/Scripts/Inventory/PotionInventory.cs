using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class PotionInventory : MonoBehaviour {

	public GameObject slotPanel;
	public GameObject inventorySlot;
	public GameObject inventoryPotion;
	PotionDatabase database;

	private int slotAmount;

	public List<GameObject> slots = new List<GameObject>();

	public static List<PotionStats> savePotions = new List<PotionStats> ();

	public void save() {
		savePotions = new List<PotionStats> ();
		for (int i = 0; i < slotAmount; i++) {
			if (slots [i].GetComponent<PotionSlot> ().potion != null) {
				slots [i].GetComponent<PotionSlot> ().potion.GetComponent<PotionStats> ().stack = slots [i].GetComponent<PotionSlot> ().potion.GetComponent<PotionObject> ().amount;
				savePotions.Add (slots [i].GetComponent<PotionSlot> ().potion.GetComponent<PotionStats> ());
			}
		}
	}

	void Awake() {
		database = GetComponent<PotionDatabase>();
		slotAmount = 8;

		for (int i = 0; i < slotAmount; i++)
		{
			slots.Add(Instantiate(inventorySlot));

			slots[i].GetComponent<PotionSlot> ().id = i;
			slots[i].transform.SetParent(slotPanel.transform);

		}
	}

	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool checkEmpty() {
		for (int i = 0; i < slotAmount; i++) {
			if (slots [i].GetComponent<PotionSlot> ().potion == null) {
				return true;
			}
		}
		return false;
	}

	public void AddItem(int id)
	{
		if (id < 0) {
			return;
		}
		Potion itemToAdd = database.FetchItemByID(id);

		if (itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd.ID))
		{
			for (int i = 0; i < slotAmount; i++) {
				if (slots [i].GetComponent<PotionSlot> ().potion != null)
				if (slots [i].GetComponent<PotionSlot> ().potion.GetComponent<PotionStats> ().ID == itemToAdd.ID) {
					PotionObject data = slots [i].GetComponent<PotionSlot> ().potion.GetComponent<PotionObject> ();
					data.amount++;
					data.transform.GetChild (0).GetComponent<Text> ().text = data.amount.ToString ();
					break;
				}
			}
				

		}
		else
		{
			for (int i = 0; i < slotAmount; i++) {
				if (slots [i].GetComponent<PotionSlot> ().potion == null) {
					PotionSlot temp = slots [i].GetComponent<PotionSlot> ();
					temp.potion = Instantiate (inventoryPotion);
					temp.potion.transform.SetParent (slots [i].transform);
					temp.potion.transform.position = slots [i].transform.position;
					temp.potion.GetComponent<Image> ().sprite = database.FetchItemByID (id).Sprite;
					temp.potion.transform.localScale = new Vector3 (.5f, .5f, 0);
					temp.potion.GetComponent<PotionObject> ().slot = i;
					temp.potion.GetComponent<PotionStats> ().loadStats(database.FetchItemByID(id));
					slots [i].GetComponent<PotionSlot> ().potion.GetComponent<PotionObject> ().amount = 1;
					break;
				}
			}
		}
	}

	public void AddItem(int id, bool tutorial)
	{
		if (id < 0) {
			return;
		}
		Potion itemToAdd = database.FetchItemByID(id);

		if (itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd.ID))
		{
			for(int i = 0; i < slotAmount; i++)
			{
				if(slots[i].GetComponent<PotionSlot>().potion.GetComponent<PotionStats>().ID == itemToAdd.ID)
				{
					PotionObject data = slots [i].GetComponent<PotionSlot> ().potion.GetComponent<PotionObject> ();
					data.amount++;
					data.tutorial = tutorial;
					data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
					break;
				}

			}

		}
		else
		{
			for (int i = 0; i < slotAmount; i++) {
				if (slots [i].GetComponent<PotionSlot> ().potion == null) {
					PotionSlot temp = slots [i].GetComponent<PotionSlot> ();
					temp.potion = Instantiate (inventoryPotion);
					temp.potion.transform.SetParent (slots [i].transform);
					temp.potion.transform.position = slots [i].transform.position;
					temp.potion.GetComponent<Image> ().sprite = database.FetchItemByID (id).Sprite;
					temp.potion.transform.localScale = new Vector3 (.5f, .5f, 0);
					temp.potion.GetComponent<PotionObject> ().slot = i;
					temp.potion.GetComponent<PotionObject> ().tutorial = tutorial;
					temp.potion.GetComponent<PotionStats> ().loadStats(database.FetchItemByID(id));
					slots [i].GetComponent<PotionSlot> ().potion.GetComponent<PotionObject> ().amount = 1;
					break;
				}
			}
		}
	}

	public void AddItemSlot(int slot, PotionStats id, int amount) {
		PotionSlot temp = slots[slot].GetComponent<PotionSlot>();
		temp.potion = Instantiate (inventoryPotion);
		temp.potion.transform.SetParent (slots [slot].transform);
		temp.potion.transform.position = slots [slot].transform.position;
		temp.potion.GetComponent<Image>().sprite = database.FetchItemByID (id.ID).Sprite;
		temp.potion.transform.localScale = new Vector3 (.5f, .5f, 0);
		temp.potion.GetComponent<PotionObject> ().slot = slot;
		temp.potion.GetComponent<PotionObject> ().amount = amount;
		temp.potion.GetComponent<PotionStats> ().loadStats(id);
	}

	public void RemoveItemSlot(int slot) {
		PotionSlot temp = slots[slot].GetComponent<PotionSlot>();
		Destroy (temp.potion);
		temp.potion = null;
	}

	bool CheckIfItemIsInInventory(int id)
	{
		for (int i = 0; i < slotAmount; i++) {
			if (slots [i].GetComponent<PotionSlot> ().potion != null) {
				if (slots [i].GetComponent<PotionSlot> ().potion.GetComponent<PotionStats> ().ID == id) {
					return true;
				}
			}
		}
		return false;
	}
}
