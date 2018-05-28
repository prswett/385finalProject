using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> database = new List<Item>();
    public JsonData itemData;
	bool isDone = false;
	string url = "http://students.washington.edu/mattphan/StreamingAssets/Items.json";
	void Awake() {
		Start ();

	}
			
	IEnumerator Start() {
		WWW link = new WWW (url);
		yield return link;
		isDone = true;
		if (isDone) {
			Debug.Log ("finished");
			itemData = JsonMapper.ToObject (new LitJson.JsonReader (link.text));
			ConstructItemDatabase ();
		}
	}

    public Item FetchItemByID(int id)
    {
		for (int i = 0; i < database.Count; i++)
			if (database [i].ID == id) {
				Item temp = database [id];
				temp = rerollStats (temp);
				return temp;
			}
        return null;
    }

	public string FetchItemName(int id) {
		for (int i = 0; i < database.Count; i++)
			if (database [i].ID == id) {
				Item temp = database [id];
				return temp.Title;
			}
		return null;
	}

    void ConstructItemDatabase()
    {
		database = new List<Item> ();
        for (int i = 0; i < itemData.Count; i++)
        {
			Item temp = new Item ((int)itemData [i] ["id"], itemData [i] ["title"].ToString (), itemData [i] ["type"].ToString (), (int)itemData [i] ["value"],
				            (int)itemData [i] ["stats"] ["str"], (int)itemData [i] ["stats"] ["dex"], (int)itemData [i] ["stats"] ["wis"], (int)itemData [i] ["stats"] ["luk"],
				            (int)itemData [i] ["stats"] ["atk"], (int)itemData [i] ["stats"] ["def"], itemData [i] ["description"].ToString (),
				            (int)itemData [i] ["rarity"], itemData [i] ["slug"].ToString ());
			database.Add(temp);
        }
    }

	Item rerollStats(Item input) {
		if (PlayerStatistics.level <= 5) {
			int random = Random.Range (-5, 6);
			input.str += random;
			random = Random.Range (-5, 6);
			input.dex += random;
			random = Random.Range (-5, 6);
			input.wis += random;
			random = Random.Range (-5, 6);
			input.luk += random;
			random = Random.Range (-5, 6);
			input.atk += random;
			random = Random.Range (-5, 6);
			input.def += random;
		} else {
			int random = Random.Range (-5, (int)PlayerStatistics.level + 1);
			input.str += random;
			random = Random.Range (-5, (int)PlayerStatistics.level + 1);
			input.dex += random;
			random = Random.Range (-5, (int)PlayerStatistics.level + 1);
			input.wis += random;
			random = Random.Range (-5, (int)PlayerStatistics.level + 1);
			input.luk += random;
			random = Random.Range (-5, (int)PlayerStatistics.level + 1);
			input.atk += random;
			random = Random.Range (-5, (int)PlayerStatistics.level + 1);
			input.def += random;
		}

		return input;
	}

}

public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
	public string type { get; set; }
    public int Value { get; set; }
	public int str { get; set; }
	public int dex { get; set; }
	public int wis { get; set; }
	public int luk { get; set; }
	public int atk { get; set; }
	public int def { get; set; }
    public string Description { get; set; }
    public int Rarity { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

	public Item(int id, string title, string type, int value, int str, int dex, int wis, int luk, int atk, int def, string description, int rarity, string slug)
    {
        this.ID = id;
        this.Title = title;
		this.type = type;
        this.Value = value;
		this.str = str;
		this.dex = dex;
		this.wis = wis;
		this.luk = luk;
		this.atk = atk;
		this.def = def;
        this.Description = description;
        this.Rarity = rarity;
        this.Slug = slug;
		this.Sprite = Resources.Load<Sprite> ("DrawingsV2/Items/Equipment/" + slug);
    }

	public Item(Item input) {
		this.ID = input.ID;
		this.Title = input.Title;
		this.type = input.type;
		this.Value = input.Value;
		this.str = input.str;
		this.dex = input.dex;
		this.wis = input.wis;
		this.luk = input.luk;
		this.atk = input.atk;
		this.def = input.def;
		this.Description = input.Description;
		this.Rarity = input.Rarity;
		this.Slug = input.Slug;
		this.Sprite = input.Sprite;
	}

    public Item()
    {
        this.ID = -1;
    }
}
	