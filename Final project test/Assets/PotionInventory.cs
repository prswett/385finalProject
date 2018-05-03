using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class PotionInventory : MonoBehaviour {

	GameObject inventoryPanel;
	public GameObject slotPanel;
	public GameObject inventorySlot;
	public GameObject inventoryPotion;
	PotionDatabase database;

	private int slotAmount;
	public List<Potion> potions = new List<Potion> ();
	public List<GameObject> slots = new List<GameObject>();

	public static List<Potion> savePotions = new List<Potion> ();

	public void save() {
		savePotions = potions;
	}

	void Awake() {
		database = GetComponent<PotionDatabase>();
		slotAmount = 4;
		inventoryPanel = GameObject.Find("Inventory Panel");
		//slotPanel = inventoryPanel.transform.Find("Slot Panel").gameObject;

		for (int i = 0; i < slotAmount; i++)
		{
			potions.Add(new Potion());
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

	public void AddItem(int id)
	{
		if (id < 0) {
			return;
		}
		Potion itemToAdd = database.FetchItemByID(id);

		if (itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd))
		{
			for(int i = 0; i < potions.Count; i++)
			{
				if(potions[i].ID == id)
				{
					PotionData data = slots[i].transform.GetChild(0).GetComponent<PotionData>();
					data.amount++;
					data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
					break;
				}
			}

		}
		else
		{
			for (int i = 0; i < potions.Count; i++)
			{
				if (potions[i].ID == -1)
				{
					potions[i] = itemToAdd;
					GameObject itemObj = Instantiate(inventoryPotion);

					itemObj.GetComponent<PotionData> ().potion = itemToAdd;
					itemObj.GetComponent<PotionData> ().slot = i;
					itemObj.transform.SetParent(slots[i].transform);
					itemObj.transform.position = slots [i].transform.position;
					itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
					itemObj.name = itemToAdd.Title;
					PotionData data = slots[i].transform.GetChild(0).GetComponent<PotionData>();
					data.amount = 1;
					break;

				}
			}
		}

	}

	public void RemoveItem(int id) {
		Potion itemToRemove = database.FetchItemByID (id);
		if (itemToRemove.Stackable && CheckIfItemIsInInventory (itemToRemove)) {
			for (int j = 0; j < potions.Count; j++) {
				if (potions [j].ID == id) {
					PotionData data = slots [j].transform.GetChild (0).GetComponent<PotionData> ();
					data.amount--;
					data.transform.GetChild (0).GetComponent<Text> ().text = data.amount.ToString ();
					if (data.amount == 0) {
						Destroy (slots [j].transform.GetChild (0).gameObject);
						potions [j] = new Potion ();
						break;
					}
					if (data.amount == 1) {
						slots [j].transform.GetChild (0).transform.GetChild (0).GetComponent<Text> ().text = "";
						break;
					}
					break;
				}
			}
		} else {
			for (int i = 0; i < potions.Count; i++) {
				if (potions [i].ID != -1 && potions [i].ID == id) {
					Destroy (slots [i].transform.GetChild (0).gameObject);
					potions [i] = new Potion ();
					break;
				}
			}
		}
	}

	bool CheckIfItemIsInInventory(Potion potion)
	{
		for (int i = 0; i < potions.Count; i++)
		{
			if (potions[i].ID == potion.ID)
			{
				return true;
			}
		}
		return false;
	}
}
