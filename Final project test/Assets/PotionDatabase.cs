using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class PotionDatabase : MonoBehaviour {
	private List<Potion> database = new List<Potion> ();
	private JsonData potionData;
	// Use this for initialization
	void Start () {
		potionData = JsonMapper.ToObject (File.ReadAllText (Application.dataPath + "/StreamingAssets/Potions.json"));
		ConstructPotionDatabase ();
	}

	public Potion FetchItemByID(int id)
	{
		for (int i = 0; i < database.Count; i++)
			if (database[i].ID == id)
				return database[i];
		return null;
	}

	void ConstructPotionDatabase()
	{
		for (int i = 0; i < potionData.Count; i++) {
			database.Add (new Potion ((int)potionData [i] ["id"], potionData [i] ["title"].ToString (), (int)potionData [i] ["value"], 
				(int)potionData [i] ["healing"], potionData [i] ["description"].ToString (), (bool)potionData [i] ["stackable"],
				(int)potionData [i] ["rarity"], potionData [i] ["slug"].ToString ()));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class Potion
{
	public int ID { get; set; }
	public string Title { get; set; }
	public int Value { get; set; }
	public int healing { get; set; }
	public string Description { get; set; }
	public bool Stackable { get; set; }
	public int Rarity { get; set; }
	public string Slug { get; set; }
	public Sprite Sprite { get; set; }

	public Potion(int id, string title, int value, int healing, string description, bool stackable, int rarity, string slug) {
		this.ID = id;
		this.Title = title;
		this.Value = value;
		this.healing = healing;
		this.Description = description;
		this.Stackable = stackable;
		this.Rarity = rarity;
		this.Slug = slug;
		this.Sprite = Resources.Load<Sprite> ("DrawingsV2/Items/" + slug);
	}

	public Potion() {
		this.ID = -1;
	}
}
