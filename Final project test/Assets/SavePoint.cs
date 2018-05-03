using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

public class SavePoint : MonoBehaviour {

	public Boolean inside = false;
	public Player player;
	public Transform target;

	void Start() {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		player = target.GetComponent<Player> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			inside = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			inside = false;
		}
	}

	private void Update()
	{
		if (inside)
		{
			if (Input.GetKeyDown(KeyCode.S))
			{
				player.inv.save ();
				player.pInv.save ();
				Save();

			}
		}
	}

	// saving data into a file (.sb)
	public void Save()
	{
		// binary formatter is helper to convert this data to the text
		BinaryFormatter bf = new BinaryFormatter();
		// creating new file
		FileStream file = File.Create(Application.persistentDataPath + "/pss.sb");
		// serializable data here
		PlayerData data = new PlayerData();

		data.curHP = PlayerStatistics.health;
		data.maxHP = PlayerStatistics.maxHealth;
		data.curMP = PlayerStatistics.mana;
		data.maxMP = PlayerStatistics.maxMana;

		data.wa = PlayerStatistics.wa;
		data.ma = PlayerStatistics.wa;
		data.str = PlayerStatistics.str;
		data.dex = PlayerStatistics.dex;
		data.wis = PlayerStatistics.wis;
		data.luk = PlayerStatistics.luk;

		data.exp = PlayerStatistics.exp;
		data.coins = PlayerStatistics.coins;
		data.nextLevel = PlayerStatistics.nextLevel;

		// saving data in item 0
		data.id0 = Inventory.saveItems[0].ID;
		data.title0 = Inventory.saveItems[0].Title;
		data.type0 = Inventory.saveItems[0].type;
		data.value0 = Inventory.saveItems[0].Value;
		data.str0 = Inventory.saveItems[0].str;
		data.dex0 = Inventory.saveItems[0].dex;
		data.wis0 = Inventory.saveItems[0].wis;
		data.luk0 = Inventory.saveItems[0].luk;
		data.atk0 = Inventory.saveItems[0].atk;
		data.def0 = Inventory.saveItems[0].def;
		data.desc0 = Inventory.saveItems[0].Description;
		data.stack0 = Inventory.saveItems[0].Stackable;
		data.rar0 = Inventory.saveItems[0].Rarity;
		data.slug0 = Inventory.saveItems[0].Slug;

		// saving data in item 1
		data.id1 = Inventory.saveItems[1].ID;
		data.title1 = Inventory.saveItems[1].Title;
		data.type1 = Inventory.saveItems[1].type;
		data.value1 = Inventory.saveItems[1].Value;
		data.str1 = Inventory.saveItems[1].str;
		data.dex1 = Inventory.saveItems[1].dex;
		data.wis1 = Inventory.saveItems[1].wis;
		data.luk1 = Inventory.saveItems[1].luk;
		data.atk1 = Inventory.saveItems[1].atk;
		data.def1 = Inventory.saveItems[1].def;
		data.desc1 = Inventory.saveItems[1].Description;
		data.stack1 = Inventory.saveItems[1].Stackable;
		data.rar1 = Inventory.saveItems[1].Rarity;
		data.slug1 = Inventory.saveItems[1].Slug;

		// saving data in item 2
		data.id2 = Inventory.saveItems[2].ID;
		data.title2 = Inventory.saveItems[2].Title;
		data.type2 = Inventory.saveItems[2].type;
		data.value2 = Inventory.saveItems[2].Value;
		data.str2 = Inventory.saveItems[2].str;
		data.dex2 = Inventory.saveItems[2].dex;
		data.wis2 = Inventory.saveItems[2].wis;
		data.luk2 = Inventory.saveItems[2].luk;
		data.atk2 = Inventory.saveItems[2].atk;
		data.def2 = Inventory.saveItems[2].def;
		data.desc2 = Inventory.saveItems[2].Description;
		data.stack2 = Inventory.saveItems[2].Stackable;
		data.rar2 = Inventory.saveItems[2].Rarity;
		data.slug2 = Inventory.saveItems[2].Slug;

		// saving data in item 3
		data.id3 = Inventory.saveItems[3].ID;
		data.title3 = Inventory.saveItems[3].Title;
		data.type3 = Inventory.saveItems[3].type;
		data.value3 = Inventory.saveItems[3].Value;
		data.str3 = Inventory.saveItems[3].str;
		data.dex3 = Inventory.saveItems[3].dex;
		data.wis3 = Inventory.saveItems[3].wis;
		data.luk3 = Inventory.saveItems[3].luk;
		data.atk3 = Inventory.saveItems[3].atk;
		data.def3 = Inventory.saveItems[3].def;
		data.desc3 = Inventory.saveItems[3].Description;
		data.stack3 = Inventory.saveItems[3].Stackable;
		data.rar3 = Inventory.saveItems[3].Rarity;
		data.slug3 = Inventory.saveItems[3].Slug;

		// saving data in item 4
		data.id4 = Inventory.saveItems[4].ID;
		data.title4 = Inventory.saveItems[4].Title;
		data.type4 = Inventory.saveItems[4].type;
		data.value4 = Inventory.saveItems[4].Value;
		data.str4 = Inventory.saveItems[4].str;
		data.dex4 = Inventory.saveItems[4].dex;
		data.wis4 = Inventory.saveItems[4].wis;
		data.luk4 = Inventory.saveItems[4].luk;
		data.atk4 = Inventory.saveItems[4].atk;
		data.def4 = Inventory.saveItems[4].def;
		data.desc4 = Inventory.saveItems[4].Description;
		data.stack4 = Inventory.saveItems[4].Stackable;
		data.rar4 = Inventory.saveItems[4].Rarity;
		data.slug4 = Inventory.saveItems[4].Slug;

		// saving data in item 5
		data.id5 = Inventory.saveItems[5].ID;
		data.title5 = Inventory.saveItems[5].Title;
		data.type5 = Inventory.saveItems[5].type;
		data.value5 = Inventory.saveItems[5].Value;
		data.str5 = Inventory.saveItems[5].str;
		data.dex5 = Inventory.saveItems[5].dex;
		data.wis5 = Inventory.saveItems[5].wis;
		data.luk5 = Inventory.saveItems[5].luk;
		data.atk5 = Inventory.saveItems[5].atk;
		data.def5 = Inventory.saveItems[5].def;
		data.desc5 = Inventory.saveItems[5].Description;
		data.stack5 = Inventory.saveItems[5].Stackable;
		data.rar5 = Inventory.saveItems[5].Rarity;
		data.slug5 = Inventory.saveItems[5].Slug;

		// saving data in item 6
		data.id6 = Inventory.saveItems[6].ID;
		data.title6 = Inventory.saveItems[6].Title;
		data.type6 = Inventory.saveItems[6].type;
		data.value6 = Inventory.saveItems[6].Value;
		data.str6 = Inventory.saveItems[6].str;
		data.dex6 = Inventory.saveItems[6].dex;
		data.wis6 = Inventory.saveItems[6].wis;
		data.luk6 = Inventory.saveItems[6].luk;
		data.atk6 = Inventory.saveItems[6].atk;
		data.def6 = Inventory.saveItems[6].def;
		data.desc6 = Inventory.saveItems[6].Description;
		data.stack6 = Inventory.saveItems[6].Stackable;
		data.rar6 = Inventory.saveItems[6].Rarity;
		data.slug6 = Inventory.saveItems[6].Slug;

		// saving data in item 7
		data.id7 = Inventory.saveItems[7].ID;
		data.title7 = Inventory.saveItems[7].Title;
		data.type7 = Inventory.saveItems[7].type;
		data.value7 = Inventory.saveItems[7].Value;
		data.str7 = Inventory.saveItems[7].str;
		data.dex7 = Inventory.saveItems[7].dex;
		data.wis7 = Inventory.saveItems[7].wis;
		data.luk7 = Inventory.saveItems[7].luk;
		data.atk7 = Inventory.saveItems[7].atk;
		data.def7 = Inventory.saveItems[7].def;
		data.desc7 = Inventory.saveItems[7].Description;
		data.stack7 = Inventory.saveItems[7].Stackable;
		data.rar7 = Inventory.saveItems[7].Rarity;
		data.slug7 = Inventory.saveItems[7].Slug;

		// saving data in item 8
		data.id8 = Inventory.saveItems[8].ID;
		data.title8 = Inventory.saveItems[8].Title;
		data.type8 = Inventory.saveItems[8].type;
		data.value8 = Inventory.saveItems[8].Value;
		data.str8 = Inventory.saveItems[8].str;
		data.dex8 = Inventory.saveItems[8].dex;
		data.wis8 = Inventory.saveItems[8].wis;
		data.luk8 = Inventory.saveItems[8].luk;
		data.atk8 = Inventory.saveItems[8].atk;
		data.def8 = Inventory.saveItems[8].def;
		data.desc8 = Inventory.saveItems[8].Description;
		data.stack8 = Inventory.saveItems[8].Stackable;
		data.rar8 = Inventory.saveItems[8].Rarity;
		data.slug8 = Inventory.saveItems[8].Slug;

		// saving data in item 9
		data.id9 = Inventory.saveItems[9].ID;
		data.title9 = Inventory.saveItems[9].Title;
		data.type9 = Inventory.saveItems[9].type;
		data.value9 = Inventory.saveItems[9].Value;
		data.str9 = Inventory.saveItems[9].str;
		data.dex9 = Inventory.saveItems[9].dex;
		data.wis9 = Inventory.saveItems[9].wis;
		data.luk9 = Inventory.saveItems[9].luk;
		data.atk9 = Inventory.saveItems[9].atk;
		data.def9 = Inventory.saveItems[9].def;
		data.desc9 = Inventory.saveItems[9].Description;
		data.stack9 = Inventory.saveItems[9].Stackable;
		data.rar9 = Inventory.saveItems[9].Rarity;
		data.slug9 = Inventory.saveItems[9].Slug;

		// saving data in potion 0
		data.pid0 = PotionInventory.savePotions[0].ID;
		data.ptitle0 = PotionInventory.savePotions[0].Title;
		data.ptype0 = PotionInventory.savePotions[0].type;
		data.pvalue0 = PotionInventory.savePotions[0].Value;
		data.phealing0 = PotionInventory.savePotions[0].healing;
		data.pdesc0 = PotionInventory.savePotions[0].Description;
		data.pstack0 = PotionInventory.savePotions[0].Stackable;
		data.prar0 = PotionInventory.savePotions[0].Rarity;
		data.pslug0 = PotionInventory.savePotions[0].Slug;
		data.potionStack0 = PotionInventory.savePotions [0].stack;

		// saving data in potion 1
		data.pid1 = PotionInventory.savePotions[1].ID;
		data.ptitle1 = PotionInventory.savePotions[1].Title;
		data.ptype1 = PotionInventory.savePotions[1].type;
		data.pvalue1 = PotionInventory.savePotions[1].Value;
		data.phealing1 = PotionInventory.savePotions[1].healing;
		data.pdesc1 = PotionInventory.savePotions[1].Description;
		data.pstack1 = PotionInventory.savePotions[1].Stackable;
		data.prar1 = PotionInventory.savePotions[1].Rarity;
		data.pslug1 = PotionInventory.savePotions[1].Slug;
		data.potionStack1 = PotionInventory.savePotions [1].stack;

		// saving data in potion 2
		data.pid2 = PotionInventory.savePotions[2].ID;
		data.ptitle2 = PotionInventory.savePotions[2].Title;
		data.ptype2 = PotionInventory.savePotions[2].type;
		data.pvalue2 = PotionInventory.savePotions[2].Value;
		data.phealing2 = PotionInventory.savePotions[2].healing;
		data.pdesc2 = PotionInventory.savePotions[2].Description;
		data.pstack2 = PotionInventory.savePotions[2].Stackable;
		data.prar2 = PotionInventory.savePotions[2].Rarity;
		data.pslug2 = PotionInventory.savePotions[2].Slug;
		data.potionStack2 = PotionInventory.savePotions [2].stack;

		// saving data in potion 3
		data.pid3 = PotionInventory.savePotions[3].ID;
		data.ptitle3 = PotionInventory.savePotions[3].Title;
		data.ptype3 = PotionInventory.savePotions[3].type;
		data.pvalue3 = PotionInventory.savePotions[3].Value;
		data.phealing3 = PotionInventory.savePotions[3].healing;
		data.pdesc3 = PotionInventory.savePotions[3].Description;
		data.pstack3 = PotionInventory.savePotions[3].Stackable;
		data.prar3 = PotionInventory.savePotions[3].Rarity;
		data.pslug3 = PotionInventory.savePotions[3].Slug;
		data.potionStack3 = PotionInventory.savePotions [3].stack;

		/**
		// saving data in potion 4
		data.pid4 = PotionInventory.savePotions[4].ID;
		data.ptitle4 = PotionInventory.savePotions[4].Title;
		data.ptype4 = PotionInventory.savePotions[4].type;
		data.pvalue4 = PotionInventory.savePotions[4].Value;
		data.phealing4 = PotionInventory.savePotions[4].healing;
		data.pdesc4 = PotionInventory.savePotions[4].Description;
		data.pstack4 = PotionInventory.savePotions[4].Stackable;
		data.prar4 = PotionInventory.savePotions[4].Rarity;
		data.pslug4 = PotionInventory.savePotions[4].Slug;
		*/

		/*data.s0 = ItemDatabase.database[0];
        data.s1 = ItemDatabase.database[1];
        data.s2 = ItemDatabase.database[2];
        data.s3 = ItemDatabase.database[3];
        data.s4 = ItemDatabase.database[4];
        data.s5 = ItemDatabase.database[5];
        data.s6 = ItemDatabase.database[6];
        data.s7 = ItemDatabase.database[7];
        data.s8 = ItemDatabase.database[8];
        data.s9 = ItemDatabase.database[9];

        data.p0 = PotionDatabase.database[0];
        data.p1 = PotionDatabase.database[1];
        data.p2 = PotionDatabase.database[2];
        data.p3 = PotionDatabase.database[3];
        data.p4 = PotionDatabase.database[4];*/


		// moves to file
		bf.Serialize(file, data);
		file.Close();
		print(" Saved to: " + Application.persistentDataPath);
	}
}



[Serializable]
class PlayerData
{
	public float curHP;
	public float maxHP;
	public float curMP;
	public float maxMP;
	// reference PlayerStats
	public float wa;
	public float ma;
	public float str;
	public float dex;
	public float wis;
	public float luk;

	public float exp;
	public float nextLevel;
	public float coins;

	// item0
	public int id0;
	public string title0;
	public string type0;
	public int value0;
	public int str0;
	public int dex0;
	public int wis0;
	public int luk0;
	public int atk0;
	public int def0;
	public string desc0;
	public bool stack0;
	public int rar0;
	public string slug0;

	// item1
	public int id1;
	public string title1;
	public string type1;
	public int value1;
	public int str1;
	public int dex1;
	public int wis1;
	public int luk1;
	public int atk1;
	public int def1;
	public string desc1;
	public bool stack1;
	public int rar1;
	public string slug1;

	// item2
	public int id2;
	public string title2;
	public string type2;
	public int value2;
	public int str2;
	public int dex2;
	public int wis2;
	public int luk2;
	public int atk2;
	public int def2;
	public string desc2;
	public bool stack2;
	public int rar2;
	public string slug2;

	// item3
	public int id3;
	public string title3;
	public string type3;
	public int value3;
	public int str3;
	public int dex3;
	public int wis3;
	public int luk3;
	public int atk3;
	public int def3;
	public string desc3;
	public bool stack3;
	public int rar3;
	public string slug3;

	// item4
	public int id4;
	public string title4;
	public string type4;
	public int value4;
	public int str4;
	public int dex4;
	public int wis4;
	public int luk4;
	public int atk4;
	public int def4;
	public string desc4;
	public bool stack4;
	public int rar4;
	public string slug4;

	// item5
	public int id5;
	public string title5;
	public string type5;
	public int value5;
	public int str5;
	public int dex5;
	public int wis5;
	public int luk5;
	public int atk5;
	public int def5;
	public string desc5;
	public bool stack5;
	public int rar5;
	public string slug5;

	// item6
	public int id6;
	public string title6;
	public string type6;
	public int value6;
	public int str6;
	public int dex6;
	public int wis6;
	public int luk6;
	public int atk6;
	public int def6;
	public string desc6;
	public bool stack6;
	public int rar6;
	public string slug6;

	// item7
	public int id7;
	public string title7;
	public string type7;
	public int value7;
	public int str7;
	public int dex7;
	public int wis7;
	public int luk7;
	public int atk7;
	public int def7;
	public string desc7;
	public bool stack7;
	public int rar7;
	public string slug7;

	// item8
	public int id8;
	public string title8;
	public string type8;
	public int value8;
	public int str8;
	public int dex8;
	public int wis8;
	public int luk8;
	public int atk8;
	public int def8;
	public string desc8;
	public bool stack8;
	public int rar8;
	public string slug8;

	// item9
	public int id9;
	public string title9;
	public string type9;
	public int value9;
	public int str9;
	public int dex9;
	public int wis9;
	public int luk9;
	public int atk9;
	public int def9;
	public string desc9;
	public bool stack9;
	public int rar9;
	public string slug9;

	// potion0
	public int pid0;
	public string ptitle0;
	public string ptype0;
	public int pvalue0;
	public int phealing0;
	public string pdesc0;
	public bool pstack0;
	public int prar0;
	public string pslug0;
	public int potionStack0;

	// potion1
	public int pid1;
	public string ptitle1;
	public string ptype1;
	public int pvalue1;
	public int phealing1;
	public string pdesc1;
	public bool pstack1;
	public int prar1;
	public string pslug1;
	public int potionStack1;

	// potion2
	public int pid2;
	public string ptitle2;
	public string ptype2;
	public int pvalue2;
	public int phealing2;
	public string pdesc2;
	public bool pstack2;
	public int prar2;
	public string pslug2;
	public int potionStack2;

	// potion3
	public int pid3;
	public string ptitle3;
	public string ptype3;
	public int pvalue3;
	public int phealing3;
	public string pdesc3;
	public bool pstack3;
	public int prar3;
	public string pslug3;
	public int potionStack3;

	/**
	// potion4
	public int pid4;
	public string ptitle4;
	public string ptype4;
	public int pvalue4;
	public int phealing4;
	public string pdesc4;
	public bool pstack4;
	public int prar4;
	public string pslug4;
	public int pstack4;
	*/

	/*public Item s0;
    public Item s1;
    public Item s2;
    public Item s3;
    public Item s4;
    public Item s5;
    public Item s6;
    public Item s7;
    public Item s8;
    public Item s9;

    public Potion p0;
    public Potion p1;
    public Potion p2;
    public Potion p3;
    public Potion p4;*/
}
