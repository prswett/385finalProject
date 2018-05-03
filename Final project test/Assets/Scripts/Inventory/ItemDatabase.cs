using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour
{
    private List<Item> database = new List<Item>();
    private JsonData itemData;


	void Awake() {
		itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
		ConstructItemDatabase();
	}
    void Start()
    {
       
    }

    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
            if (database[i].ID == id)
                return database[i];
        return null;
    }

    void ConstructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
			database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), itemData[i]["type"].ToString(), (int)itemData[i]["value"],
				(int)itemData[i]["stats"]["str"], (int)itemData[i]["stats"]["dex"], (int)itemData[i]["stats"]["wis"], (int)itemData[i]["stats"]["luk"],
				(int)itemData[i]["stats"]["atk"], (int)itemData[i]["stats"]["def"], itemData[i]["description"].ToString(),
                (int)itemData[i]["rarity"], itemData[i]["slug"].ToString()));
        }
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
		int random = Random.Range (0, 2);

		if (random == 0) {
			this.str = str;
		} else if (random == 1) {
			this.str = str + 1;
		} else {
			this.str = str - 1;
		}

		random = Random.Range (0, 2);

		if (random == 0) {
			this.dex = dex;
		} else if (random == 1) {
			this.dex = dex + 1;
		} else {
			this.dex = dex - 1;
		}

		random = Random.Range (0, 2);

		if (random == 0) {
			this.wis = wis;
		} else if (random == 1) {
			this.wis = wis + 1;
		} else {
			this.wis = wis - 1;
		}

		random = Random.Range (0, 2);

		if (random == 0) {
			this.luk = luk;
		} else if (random == 1) {
			this.luk = luk + 1;
		} else {
			this.luk = luk - 1;
		}

		random = Random.Range (0, 2);

		if (random == 0) {
			this.atk = atk;
		} else if (random == 1) {
			this.atk = atk + 1;
		} else {
			this.atk = atk - 1;
		}

		random = Random.Range (0, 2);

		if (random == 0) {
			this.def = def;
		} else if (random == 1) {
			this.def = def + 1;
		} else {
			this.def = def - 1;
		}

        this.Description = description;
        this.Rarity = rarity;
        this.Slug = slug;
		this.Sprite = Resources.Load<Sprite> ("DrawingsV2/Items/Equipment/" + slug);
    }

    public Item()
    {
        this.ID = -1;
    }
}
	