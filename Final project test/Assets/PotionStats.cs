using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionStats : MonoBehaviour {

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

	public PotionStats(int id, string title, string type, int value, int healing, string description, bool stackable, int rarity, string slug) {
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

	public void loadStats(Potion input) {
		this.ID = input.ID;
		this.Title = input.Title;
		this.type = input.type;
		this.Value = input.Value;
		this.healing = input.healing;
		this.Description = input.Description;
		this.Stackable = input.Stackable;
		this.Rarity = input.Rarity;
		this.Slug = input.Slug;
		this.Sprite = Resources.Load<Sprite> ("DrawingsV2/Items/" + input.Slug);
	}

	public void loadStats(PotionStats input) {
		this.ID = input.ID;
		this.Title = input.Title;
		this.type = input.type;
		this.Value = input.Value;
		this.healing = input.healing;
		this.Description = input.Description;
		this.Stackable = input.Stackable;
		this.Rarity = input.Rarity;
		this.Slug = input.Slug;
		this.Sprite = Resources.Load<Sprite> ("DrawingsV2/Items/" + input.Slug);
	}



	public PotionStats() {
		this.ID = -1;
	}
}
