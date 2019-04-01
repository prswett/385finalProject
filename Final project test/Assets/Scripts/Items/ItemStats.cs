using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStats : MonoBehaviour {

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

	public void loadStats(Item input)
	{
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
		this.Sprite = Resources.Load<Sprite> ("DrawingsV2/Items/Equipment/" + Slug);
	}

	public void loadStats(ItemStats input) {
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
		this.Sprite = Resources.Load<Sprite> ("DrawingsV2/Items/Equipment/" + Slug);
	}

	public void loadStats()
	{
		this.ID = -1;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
