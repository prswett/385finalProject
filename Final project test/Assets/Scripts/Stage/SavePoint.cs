using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

public class SavePoint : MonoBehaviour
{

	public Boolean inside = false;
	public Player player;
	public Transform target;

	public TextMesh control;

	void Start ()
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		player = target.GetComponent<Player> ();
		control = GetComponentInChildren<TextMesh> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			inside = true;
			control.text = "Press S to save";
		}
	}

	private void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			inside = false;
			control.text = "";
		}
	}

	private void Update ()
	{
		if (inside) {
			if (Input.GetKeyDown (KeyCode.S)) {
				GameObject save = GameObject.Find ("Save");
				if (save == null) {
					player.playerCanvas.showSave ();
				}
			}
		} else {
			GameObject save = GameObject.Find ("Save");
			if (save != null) {
				player.playerCanvas.hideSave ();
			}
		}
	}

	public void prepareSave() {
		Debug.Log ("Save");
		player.playerCanvas.hideSave ();
		player.inv.save ();
		player.pInv.save ();
		player.eInv.save ();
		player.spells.save ();
		Save ();
	}

	// saving data into a file (.sb)
	public void Save ()
	{
		// binary formatter is helper to convert this data to the text
		BinaryFormatter bf = new BinaryFormatter ();
		// creating new file
		FileStream file = File.Create (Application.persistentDataPath + "/pss.sb");
		// serializable data here
		PlayerData data = new PlayerData ();

		data.unlocked = PlayerSpells.saveUnlocked;
		data.spellLevel = PlayerSpells.saveLevel;

		data.baseHp = PlayerStatistics.baseHealth;
		data.curHP = PlayerStatistics.health;
		data.maxHP = PlayerStatistics.maxHealth;
		data.baseMp = PlayerStatistics.baseMana;
		data.curMP = PlayerStatistics.mana;
		data.maxMP = PlayerStatistics.maxMana;

		data.wa = PlayerStatistics.wa;
		data.ma = PlayerStatistics.ma;
		data.def = PlayerStatistics.def;
		data.str = PlayerStatistics.str;
		data.dex = PlayerStatistics.dex;
		data.wis = PlayerStatistics.wis;
		data.luk = PlayerStatistics.luk;

		data.exp = PlayerStatistics.exp;
		data.coins = PlayerStatistics.coins;
		data.nextLevel = PlayerStatistics.nextLevel;
		data.level = PlayerStatistics.level;
		data.statPoints = PlayerStatistics.statPoints;

		int numberItems = Inventory.saveItems.Count;
		int count = 0;
		if (count < numberItems) {
			count++;
			data.item0Title = Inventory.saveItems [0].Title;
			data.item0Desc = Inventory.saveItems [0].Description;
			data.item0 = Inventory.saveItems [0].ID + " " + Inventory.saveItems [0].type + " " + Inventory.saveItems [0].Value + " " +
			Inventory.saveItems [0].str + " " + Inventory.saveItems [0].dex + " " + Inventory.saveItems [0].wis + " " + Inventory.saveItems [0].luk + " " +
			Inventory.saveItems [0].atk + " " + Inventory.saveItems [0].def + " " + Inventory.saveItems [0].Rarity + " " +
				Inventory.saveItems [0].Slug;
		}

		if (count < numberItems) {
			count++;
			data.item1Title = Inventory.saveItems [1].Title;
			data.item1Desc = Inventory.saveItems [1].Description;
			data.item1 = Inventory.saveItems [1].ID + " " + Inventory.saveItems [1].type + " " + Inventory.saveItems [1].Value + " " +
				Inventory.saveItems [1].str + " " + Inventory.saveItems [1].dex + " " + Inventory.saveItems [1].wis + " " + Inventory.saveItems [1].luk + " " +
				Inventory.saveItems [1].atk + " " + Inventory.saveItems [1].def + " " + Inventory.saveItems [1].Rarity + " " +
				Inventory.saveItems [1].Slug;
		}
		
		if (count < numberItems) {
			count++;
			data.item2Title = Inventory.saveItems [2].Title;
			data.item2Desc = Inventory.saveItems [2].Description;
			data.item2 = Inventory.saveItems [2].ID + " " + Inventory.saveItems [2].type + " " + Inventory.saveItems [2].Value + " " +
				Inventory.saveItems [2].str + " " + Inventory.saveItems [2].dex + " " + Inventory.saveItems [2].wis + " " + Inventory.saveItems [2].luk + " " +
				Inventory.saveItems [2].atk + " " + Inventory.saveItems [2].def + " " + Inventory.saveItems [2].Rarity + " " +
				Inventory.saveItems [2].Slug;
		}

		if (count < numberItems) {
			count++;
			data.item3Title = Inventory.saveItems [3].Title;
			data.item3Desc = Inventory.saveItems [3].Description;
			data.item3 = Inventory.saveItems [3].ID + " " + Inventory.saveItems [3].type + " " + Inventory.saveItems [3].Value + " " +
				Inventory.saveItems [3].str + " " + Inventory.saveItems [3].dex + " " + Inventory.saveItems [3].wis + " " + Inventory.saveItems [3].luk + " " +
				Inventory.saveItems [3].atk + " " + Inventory.saveItems [3].def + " " + Inventory.saveItems [3].Rarity + " " +
				Inventory.saveItems [3].Slug;
		}

		if (count < numberItems) {
			count++;
			data.item4Title = Inventory.saveItems [4].Title;
			data.item4Desc = Inventory.saveItems [4].Description;
			data.item4 = Inventory.saveItems [4].ID + " " + Inventory.saveItems [4].type + " " + Inventory.saveItems [4].Value + " " +
				Inventory.saveItems [4].str + " " + Inventory.saveItems [4].dex + " " + Inventory.saveItems [4].wis + " " + Inventory.saveItems [4].luk + " " +
				Inventory.saveItems [4].atk + " " + Inventory.saveItems [4].def + " " + Inventory.saveItems [4].Rarity + " " +
				Inventory.saveItems [4].Slug;
		}

		if (count < numberItems) {
			count++;
			data.item5Title = Inventory.saveItems [5].Title;
			data.item5Desc = Inventory.saveItems [5].Description;
			data.item5 = Inventory.saveItems [5].ID + " " + Inventory.saveItems [5].type + " " + Inventory.saveItems [5].Value + " " +
				Inventory.saveItems [5].str + " " + Inventory.saveItems [5].dex + " " + Inventory.saveItems [5].wis + " " + Inventory.saveItems [5].luk + " " +
				Inventory.saveItems [5].atk + " " + Inventory.saveItems [5].def + " " + Inventory.saveItems [5].Rarity + " " +
				Inventory.saveItems [5].Slug;
		}

		if (count < numberItems) {
			count++;
			data.item6Title = Inventory.saveItems [6].Title;
			data.item6Desc = Inventory.saveItems [6].Description;
			data.item6 = Inventory.saveItems [6].ID + " " + Inventory.saveItems [6].type + " " + Inventory.saveItems [6].Value + " " +
				Inventory.saveItems [6].str + " " + Inventory.saveItems [6].dex + " " + Inventory.saveItems [6].wis + " " + Inventory.saveItems [6].luk + " " +
				Inventory.saveItems [6].atk + " " + Inventory.saveItems [6].def + " " + Inventory.saveItems [6].Rarity + " " +
				Inventory.saveItems [6].Slug;
		}

		if (count < numberItems) {
			count++;
			data.item7Title = Inventory.saveItems [7].Title;
			data.item7Desc = Inventory.saveItems [7].Description;
			data.item7 = Inventory.saveItems [7].ID + " " + Inventory.saveItems [7].type + " " + Inventory.saveItems [7].Value + " " +
				Inventory.saveItems [7].str + " " + Inventory.saveItems [7].dex + " " + Inventory.saveItems [7].wis + " " + Inventory.saveItems [7].luk + " " +
				Inventory.saveItems [7].atk + " " + Inventory.saveItems [7].def + " " + Inventory.saveItems [7].Rarity + " " +
				Inventory.saveItems [7].Slug;
		}

		if (count < numberItems) {
			count++;
			data.item8Title = Inventory.saveItems [8].Title;
			data.item8Desc = Inventory.saveItems [8].Description;
			data.item8 = Inventory.saveItems [8].ID + " " + Inventory.saveItems [8].type + " " + Inventory.saveItems [8].Value + " " +
				Inventory.saveItems [8].str + " " + Inventory.saveItems [8].dex + " " + Inventory.saveItems [8].wis + " " + Inventory.saveItems [8].luk + " " +
				Inventory.saveItems [8].atk + " " + Inventory.saveItems [8].def + " " + Inventory.saveItems [8].Rarity + " " +
				Inventory.saveItems [8].Slug;
		}

		if (count < numberItems) {
			count++;
			data.item9Title = Inventory.saveItems [9].Title;
			data.item9Desc = Inventory.saveItems [9].Description;
			data.item9 = Inventory.saveItems [9].ID + " " + Inventory.saveItems [9].type + " " + Inventory.saveItems [9].Value + " " +
				Inventory.saveItems [9].str + " " + Inventory.saveItems [9].dex + " " + Inventory.saveItems [9].wis + " " + Inventory.saveItems [9].luk + " " +
				Inventory.saveItems [9].atk + " " + Inventory.saveItems [9].def + " " + Inventory.saveItems [9].Rarity + " " +
				Inventory.saveItems [9].Slug;
		}
		count = 0;
		numberItems = PotionInventory.savePotions.Count;

		if (count < numberItems) {
			count++;

			data.potion0Title = PotionInventory.savePotions [0].Title;
			data.potion0Desc = PotionInventory.savePotions [0].Description;
			data.potion0 = PotionInventory.savePotions [0].ID + " " + PotionInventory.savePotions [0].type + " " +
			PotionInventory.savePotions [0].Value + " " + PotionInventory.savePotions [0].healing + " " +
			PotionInventory.savePotions [0].Stackable + " " + PotionInventory.savePotions [0].Rarity + " " + PotionInventory.savePotions[0].Slug + " " +
			PotionInventory.savePotions [0].stack;
		}

		if (count < numberItems) {
			count++;

			data.potion1Title = PotionInventory.savePotions [1].Title;
			data.potion1Desc = PotionInventory.savePotions [1].Description;
			data.potion1 = PotionInventory.savePotions [1].ID + " " + PotionInventory.savePotions [1].type + " " +
				PotionInventory.savePotions [1].Value + " " + PotionInventory.savePotions [1].healing + " " +
				PotionInventory.savePotions [1].Stackable + " " + PotionInventory.savePotions [1].Rarity + " " + PotionInventory.savePotions[1].Slug + " " +
				PotionInventory.savePotions [1].stack;
		}

		if (count < numberItems) {
			count++;

			data.potion2Title = PotionInventory.savePotions [2].Title;
			data.potion2Desc = PotionInventory.savePotions [2].Description;
			data.potion2 = PotionInventory.savePotions [2].ID + " " + PotionInventory.savePotions [2].type + " " +
				PotionInventory.savePotions [2].Value + " " + PotionInventory.savePotions [2].healing + " " +
				PotionInventory.savePotions [2].Stackable + " " + PotionInventory.savePotions [2].Rarity + " " + PotionInventory.savePotions[2].Slug + " " +
				PotionInventory.savePotions [2].stack;
		}

		if (count < numberItems) {
			count++;

			data.potion3Title = PotionInventory.savePotions [3].Title;
			data.potion3Desc = PotionInventory.savePotions [3].Description;
			data.potion3 = PotionInventory.savePotions [3].ID + " " + PotionInventory.savePotions [3].type + " " +
				PotionInventory.savePotions [3].Value + " " + PotionInventory.savePotions [3].healing + " " +
				PotionInventory.savePotions [3].Stackable + " " + PotionInventory.savePotions [3].Rarity + " " + PotionInventory.savePotions[3].Slug + " " +
				PotionInventory.savePotions [3].stack;
		}

		if (count < numberItems) {
			count++;

			data.potion4Title = PotionInventory.savePotions [ 4].Title;
			data.potion4Desc = PotionInventory.savePotions [ 4].Description;
			data.potion4 = PotionInventory.savePotions [ 4].ID + " " + PotionInventory.savePotions [ 4].type + " " +
				PotionInventory.savePotions [ 4].Value + " " + PotionInventory.savePotions [ 4].healing + " " +
				PotionInventory.savePotions [ 4].Stackable + " " + PotionInventory.savePotions [ 4].Rarity + " " + PotionInventory.savePotions[ 4].Slug + " " +
				PotionInventory.savePotions [ 4].stack;
		}

		if (count < numberItems) {
			count++;

			data.potion5Title = PotionInventory.savePotions [ 5].Title;
			data.potion5Desc = PotionInventory.savePotions [ 5].Description;
			data.potion5 = PotionInventory.savePotions [ 5].ID + " " + PotionInventory.savePotions [ 5].type + " " +
				PotionInventory.savePotions [ 5].Value + " " + PotionInventory.savePotions [ 5].healing + " " +
				PotionInventory.savePotions [ 5].Stackable + " " + PotionInventory.savePotions [ 5].Rarity + " " + PotionInventory.savePotions[ 5].Slug + " " +
				PotionInventory.savePotions [ 5].stack;
		}

		if (count < numberItems) {
			count++;

			data.potion6Title = PotionInventory.savePotions [ 6].Title;
			data.potion6Desc = PotionInventory.savePotions [ 6].Description;
			data.potion6 = PotionInventory.savePotions [ 6].ID + " " + PotionInventory.savePotions [ 6].type + " " +
				PotionInventory.savePotions [ 6].Value + " " + PotionInventory.savePotions [ 6].healing + " " +
				PotionInventory.savePotions [ 6].Stackable + " " + PotionInventory.savePotions [ 6].Rarity + " " + PotionInventory.savePotions[ 6].Slug + " " +
				PotionInventory.savePotions [ 6].stack;
		}

		if (count < numberItems) {
			count++;

			data.potion7Title = PotionInventory.savePotions [ 7].Title;
			data.potion7Desc = PotionInventory.savePotions [ 7].Description;
			data.potion7 = PotionInventory.savePotions [ 7].ID + " " + PotionInventory.savePotions [ 7].type + " " +
				PotionInventory.savePotions [ 7].Value + " " + PotionInventory.savePotions [ 7].healing + " " +
				PotionInventory.savePotions [ 7].Stackable + " " + PotionInventory.savePotions [ 7].Rarity + " " + PotionInventory.savePotions[ 7].Slug + " " +
				PotionInventory.savePotions [ 7].stack;
		}

		if (Equipment.saveItems [0].ID != -1) {
			data.equip0Title = Equipment.saveItems [0].Title;
			data.equip0Desc = Equipment.saveItems [0].Description;
			data.equip0 = Equipment.saveItems [0].ID + " " + Equipment.saveItems [0].type + " " + Equipment.saveItems [0].Value + " " +
				Equipment.saveItems [0].str + " " + Equipment.saveItems [0].dex + " " + Equipment.saveItems [0].wis + " " + Equipment.saveItems [0].luk + " " +
				Equipment.saveItems [0].atk + " " + Equipment.saveItems [0].def + " " + Equipment.saveItems [0].Rarity + " " +
				Equipment.saveItems[0].Slug;
		}

		if (Equipment.saveItems [1].ID != -1) {

			data.equip1Title = Equipment.saveItems [1].Title;
			data.equip1Desc = Equipment.saveItems [1].Description;
			data.equip1 = Equipment.saveItems [1].ID + " " + Equipment.saveItems [1].type + " " + Equipment.saveItems [1].Value + " " +
				Equipment.saveItems [1].str + " " + Equipment.saveItems [1].dex + " " + Equipment.saveItems [1].wis + " " + Equipment.saveItems [1].luk + " " +
				Equipment.saveItems [1].atk + " " + Equipment.saveItems [1].def + " " + Equipment.saveItems [1].Rarity + " " +
				Equipment.saveItems[1].Slug;
		}

		if (Equipment.saveItems [2].ID != -1) {
			data.equip2Title = Equipment.saveItems [2].Title;
			data.equip2Desc = Equipment.saveItems [2].Description;
			data.equip2 = Equipment.saveItems [2].ID + " " + Equipment.saveItems [2].type + " " + Equipment.saveItems [2].Value + " " +
				Equipment.saveItems [2].str + " " + Equipment.saveItems [2].dex + " " + Equipment.saveItems [2].wis + " " + Equipment.saveItems [2].luk + " " +
				Equipment.saveItems [2].atk + " " + Equipment.saveItems [2].def + " " + Equipment.saveItems [2].Rarity + " " +
				Equipment.saveItems[2].Slug;
		}

		if (Equipment.saveItems [3].ID != -1) {
			data.equip3Title = Equipment.saveItems [3].Title;
			data.equip3Desc = Equipment.saveItems [3].Description;
			data.equip3 = Equipment.saveItems [3].ID + " " + Equipment.saveItems [3].type + " " + Equipment.saveItems [3].Value + " " +
				Equipment.saveItems [3].str + " " + Equipment.saveItems [3].dex + " " + Equipment.saveItems [3].wis + " " + Equipment.saveItems [3].luk + " " +
				Equipment.saveItems [3].atk + " " + Equipment.saveItems [3].def + " " + Equipment.saveItems [3].Rarity + " " +
				Equipment.saveItems[3].Slug;
		}

		if (Equipment.saveItems [4].ID != -1) {
			data.equip4Title = Equipment.saveItems [4].Title;
			data.equip4Desc = Equipment.saveItems [4].Description;
			data.equip4 = Equipment.saveItems [4].ID + " " + Equipment.saveItems [4].type + " " + Equipment.saveItems [4].Value + " " +
				Equipment.saveItems [4].str + " " + Equipment.saveItems [4].dex + " " + Equipment.saveItems [4].wis + " " + Equipment.saveItems [4].luk + " " +
				Equipment.saveItems [4].atk + " " + Equipment.saveItems [4].def + " " + Equipment.saveItems [4].Rarity + " " +
				Equipment.saveItems[4].Slug;
		}

		if (Equipment.saveItems [5].ID != -1) {
			data.equip5Title = Equipment.saveItems [5].Title;
			data.equip5Desc = Equipment.saveItems [5].Description;
			data.equip5 = Equipment.saveItems [5].ID + " " + Equipment.saveItems [5].type + " " + Equipment.saveItems [5].Value + " " +
				Equipment.saveItems [5].str + " " + Equipment.saveItems [5].dex + " " + Equipment.saveItems [5].wis + " " + Equipment.saveItems [5].luk + " " +
				Equipment.saveItems [5].atk + " " + Equipment.saveItems [5].def + " " + Equipment.saveItems [5].Rarity + " " +
				Equipment.saveItems[5].Slug;
		}

		// moves to file
		bf.Serialize (file, data);
		file.Close ();
		print (" Saved to: " + Application.persistentDataPath);
	}
}



[Serializable]
class PlayerData
{
	// reference PlayerStats
	public float baseHp;
	public float curHP;
	public float maxHP;
	public float baseMp;
	public float curMP;
	public float maxMP;

	public float wa;
	public float ma;
	public float def;
	public float str;
	public float dex;
	public float wis;
	public float luk;

	public float exp;
	public float nextLevel;
	public float level;
	public float coins;
	public float statPoints;

	public bool[] unlocked;
	public int[] spellLevel;

	//Items
	public string item0;
	public string item0Title;
	public string item0Desc;

	public string item1;
	public string item1Title;
	public string item1Desc;

	public string item2;
	public string item2Title;
	public string item2Desc;

	public string item3;
	public string item3Title;
	public string item3Desc;

	public string item4;
	public string item4Title;
	public string item4Desc;

	public string item5;
	public string item5Title;
	public string item5Desc;

	public string item6;
	public string item6Title;
	public string item6Desc;

	public string item7;
	public string item7Title;
	public string item7Desc;

	public string item8;
	public string item8Title;
	public string item8Desc;

	public string item9;
	public string item9Title;
	public string item9Desc;

	//Potions
	public string potion0;
	public string potion0Title;
	public string potion0Desc;

	public string potion1;
	public string potion1Title;
	public string potion1Desc;

	public string potion2;
	public string potion2Title;
	public string potion2Desc;

	public string potion3;
	public string potion3Title;
	public string potion3Desc;

	public string potion4;
	public string potion4Title;
	public string potion4Desc;

	public string potion5;
	public string potion5Title;
	public string potion5Desc;

	public string potion6;
	public string potion6Title;
	public string potion6Desc;

	public string potion7;
	public string potion7Title;
	public string potion7Desc;
	//Equipment
	public string equip0;
	public string equip0Title;
	public string equip0Desc;

	public string equip1;
	public string equip1Title;
	public string equip1Desc;

	public string equip2;
	public string equip2Title;
	public string equip2Desc;

	public string equip3;
	public string equip3Title;
	public string equip3Desc;

	public string equip4;
	public string equip4Title;
	public string equip4Desc;

	public string equip5;
	public string equip5Title;
	public string equip5Desc;
}
