using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour
{
    private List<Item> database = new List<Item>();
    private JsonData itemData;


    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();
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
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), (int)itemData[i]["value"],
				(int)itemData[i]["stats"]["str"], (int)itemData[i]["stats"]["dex"], (int)itemData[i]["stats"]["wis"], (int)itemData[i]["stats"]["luk"],
				(int)itemData[i]["stats"]["atk"], (int)itemData[i]["stats"]["def"], itemData[i]["description"].ToString(),
                (bool)itemData[i]["stackable"], (int)itemData[i]["rarity"], itemData[i]["slug"].ToString()));
        }
    }

}

public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
	public int str { get; set; }
	public int dex { get; set; }
	public int wis { get; set; }
	public int luk { get; set; }
	public int atk { get; set; }
	public int def { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public int Rarity { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

	public Item(int id, string title, int value, int str, int dex, int wis, int luk, int atk, int def, string description, bool stackable, int rarity, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Value = value;
		this.str = str;
		this.dex = dex;
		this.wis = wis;
		this.luk = luk;
		this.atk = atk;
		this.def = def;
        this.Description = description;
        this.Stackable = stackable;
        this.Rarity = rarity;
        this.Slug = slug;
		this.Sprite = Resources.Load<Sprite> ("DrawingsV2/Items/Equipment/" + slug);
    }

    public Item()
    {
        this.ID = -1;
    }
}
	