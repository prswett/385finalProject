using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class PotionDatabase : MonoBehaviour {
	public List<Potion> database = new List<Potion> ();
	public JsonData potionData;

	bool isDone = false;
	string url = "http://students.washington.edu/mattphan/StreamingAssets/Potions.json";
	void Awake() {
		Start ();
	}

	IEnumerator Start() {
		WWW link = new WWW (url);
		yield return link;
		isDone = true;
		if (isDone) {
			Debug.Log ("finished");
			potionData = JsonMapper.ToObject (new LitJson.JsonReader (link.text));
			ConstructPotionDatabase ();
		}
	}

	public Potion FetchItemByID(int id)
	{
		for (int i = 0; i < database.Count; i++)
			if (database[i].ID == id)
				return database[i];
		return null;
	}

	public string FetchItemName(int id) {
		for (int i = 0; i < database.Count; i++)
			if (database [i].ID == id) {
				Potion temp = database [id];
				return temp.Title;
			}
		return null;
	}

	void ConstructPotionDatabase()
	{
		database = new List<Potion> ();
		for (int i = 0; i < potionData.Count; i++) {
			database.Add (new Potion ((int)potionData [i] ["id"], potionData [i] ["title"].ToString (), potionData [i] ["type"].ToString (), (int)potionData [i] ["value"], 
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
	public string type { get; set; }
	public int Value { get; set; }
	public int healing { get; set; }
	public string Description { get; set; }
	public bool Stackable { get; set; }
	public int Rarity { get; set; }
	public string Slug { get; set; }
	public Sprite Sprite { get; set; }
	public int stack { get; set; }

	public Potion(int id, string title, string type, int value, int healing, string description, bool stackable, int rarity, string slug) {
		this.ID = id;
		this.Title = title;
		this.type = type;
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
