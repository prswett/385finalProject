using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPlayer : MonoBehaviour {

	// loading data if exists
	public void Load(Player a)
	{
		// if file exists, load
		if (File.Exists(Application.persistentDataPath + "/pss.sb"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/pss.sb", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();
			PlayerStatistics.health = data.curHP;
			PlayerStatistics.maxHealth = data.maxHP;
			PlayerStatistics.mana = data.curMP;
			PlayerStatistics.maxMana = data.maxMP;

			PlayerStatistics.wa = data.wa;
			PlayerStatistics.ma = data.ma;

			PlayerStatistics.str = data.str;
			PlayerStatistics.dex = data.dex;
			PlayerStatistics.wis = data.wis;
			PlayerStatistics.luk = data.luk;

			PlayerStatistics.exp = data.exp;
			PlayerStatistics.nextLevel = data.nextLevel;
			PlayerStatistics.coins = data.coins;

			a.addItem(data.id0);
			a.addItem(data.id1);
			a.addItem(data.id2);
			a.addItem(data.id3);
			a.addItem(data.id4);
			a.addItem(data.id5);
			a.addItem(data.id6);
			a.addItem(data.id7);
			a.addItem(data.id8);
			a.addItem(data.id9);

			print("pid0 is: " + data.pid0);
			a.addPotion(data.pid0);
			a.addPotion(data.pid1);
			a.addPotion(data.pid2);
			a.addPotion(data.pid3);
			//a.addPotion(data.pid4);

			/*
            // loading items
			Inventory.items[0] = new Item(data.id0, data.title0, data.type0, data.value0, data.str0, data.dex0, data.wis0, data.luk0, data.atk0, data.def0, data.desc0, data.stack0, data.rar0, data.slug0);
			Inventory.items[1] = new Item(data.id1, data.title1, data.type1, data.value1, data.str1, data.dex1, data.wis1, data.luk1, data.atk1, data.def1, data.desc1, data.stack1, data.rar1, data.slug1);
			Inventory.items[2] = new Item(data.id2, data.title2, data.type2, data.value2, data.str2, data.dex2, data.wis2, data.luk2, data.atk2, data.def2, data.desc2, data.stack2, data.rar2, data.slug2);
			Inventory.items[3] = new Item(data.id3, data.title3, data.type3, data.value3, data.str3, data.dex3, data.wis3, data.luk3, data.atk3, data.def3, data.desc3, data.stack3, data.rar3, data.slug3);
			Inventory.items[4] = new Item(data.id4, data.title4, data.type4, data.value4, data.str4, data.dex4, data.wis4, data.luk4, data.atk4, data.def4, data.desc4, data.stack4, data.rar4, data.slug4);
			Inventory.items[5] = new Item(data.id5, data.title5, data.type5, data.value5, data.str5, data.dex5, data.wis5, data.luk5, data.atk5, data.def5, data.desc5, data.stack5, data.rar5, data.slug5);
			Inventory.items[6] = new Item(data.id6, data.title6, data.type6, data.value6, data.str6, data.dex6, data.wis6, data.luk6, data.atk6, data.def6, data.desc6, data.stack6, data.rar6, data.slug6);
			Inventory.items[7] = new Item(data.id7, data.title7, data.type7, data.value7, data.str7, data.dex7, data.wis7, data.luk7, data.atk7, data.def7, data.desc7, data.stack7, data.rar7, data.slug7);
			Inventory.items[8] = new Item(data.id8, data.title8, data.type8, data.value8, data.str8, data.dex8, data.wis8, data.luk8, data.atk8, data.def8, data.desc8, data.stack8, data.rar8, data.slug8);
			Inventory.items[9] = new Item(data.id9, data.title9, data.type9, data.value9, data.str9, data.dex9, data.wis9, data.luk9, data.atk9, data.def9, data.desc9, data.stack9, data.rar9, data.slug9);

			// loading potions
			PotionInventory.potions[0] = new Potion(data.pid0, data.ptitle0, data.ptype0, data.pvalue0, data.phealing0, data.pdesc0, data.pstack0, data.prar0, data.pslug0);
			PotionInventory.potions[1] = new Potion(data.pid1, data.ptitle1, data.ptype1, data.pvalue1, data.phealing1, data.pdesc1, data.pstack1, data.prar1, data.pslug1);
			PotionInventory.potions[2] = new Potion(data.pid2, data.ptitle2, data.ptype2, data.pvalue2, data.phealing2, data.pdesc2, data.pstack2, data.prar2, data.pslug2);
			PotionInventory.potions[3] = new Potion(data.pid3, data.ptitle3, data.ptype3, data.pvalue3, data.phealing3, data.pdesc3, data.pstack3, data.prar3, data.pslug3);
			PotionInventory.potions[4] = new Potion(data.pid4, data.ptitle4, data.ptype4, data.pvalue4, data.phealing4, data.pdesc4, data.pstack4, data.prar4, data.pslug4);
			*/

			/*ItemDatabase.database[0] = data.s0;
			ItemDatabase.database[1] = data.s1;
			ItemDatabase.database[2] = data.s2;
			ItemDatabase.database[3] = data.s3;
			ItemDatabase.database[4] = data.s4;
			ItemDatabase.database[5] = data.s5;
			ItemDatabase.database[6] = data.s6;
			ItemDatabase.database[7] = data.s7;
			ItemDatabase.database[8] = data.s8;
			ItemDatabase.database[9] = data.s9;

			PotionDatabase.database[0] = data.p0;
			PotionDatabase.database[1] = data.p1;
			PotionDatabase.database[2] = data.p2;
			PotionDatabase.database[3] = data.p3;
			//PotionDatabase.database[4] = data.p4;*/

			print(" Loaded saved file.");
		}
		SceneManager.LoadScene(1);
	}

	public void loadY()
	{
		Player.loadedChar = true;
		SceneManager.LoadScene(1);
	}
	// Update is called once per frame
	void Update () {

	}
}
