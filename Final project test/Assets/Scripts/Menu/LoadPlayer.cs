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
			PlayerStatistics.baseHealth = data.baseHp;
			PlayerStatistics.health = data.curHP;
			PlayerStatistics.maxHealth = data.maxHP;
			PlayerStatistics.baseMana = data.baseMp;
			PlayerStatistics.mana = data.curMP;
			PlayerStatistics.maxMana = data.maxMP;

			PlayerStatistics.wa = data.wa;
			PlayerStatistics.ma = data.ma;
			PlayerStatistics.def = data.def;
			PlayerStatistics.str = data.str;
			PlayerStatistics.dex = data.dex;
			PlayerStatistics.wis = data.wis;
			PlayerStatistics.luk = data.luk;

			PlayerStatistics.exp = data.exp;
			PlayerStatistics.nextLevel = data.nextLevel;
			PlayerStatistics.coins = data.coins;
			PlayerStatistics.level = data.level;
			PlayerStatistics.statPoints = data.statPoints;

			PlayerSpells.saveLevel = data.spellLevel;
			PlayerSpells.saveUnlocked = data.unlocked;

			string[] split;
			Item temp;
			ItemStats temp2 = new ItemStats();

			if (data.item0 != null) {
				split = data.item0.Split (new string[] { " " }, System.StringSplitOptions.None);
				temp = new Item (int.Parse (split [0]), data.item0Title, split [1], int.Parse (split [2]),
					           int.Parse (split [3]), int.Parse (split [4]), int.Parse (split [5]), int.Parse (split [6]), 
					int.Parse (split [7]), int.Parse (split [8]), data.item0Desc, int.Parse (split [9]),
					           split [10]);
				temp2.loadStats (temp);
				Debug.Log (data.item0Title);
				a.addItem (temp2);
			}

			if (data.item1 != null) {
				split = data.item1.Split (new string[] { " " }, System.StringSplitOptions.None);
				temp = new Item (int.Parse (split [0]), data.item1Title, split [1], int.Parse (split [2]),
					int.Parse (split [3]), int.Parse (split [4]), int.Parse (split [5]), int.Parse (split [6]), 
					int.Parse (split [7]), int.Parse (split [8]), data.item1Desc, int.Parse (split [9]),
					split [10]);
				temp2.loadStats (temp);
				Debug.Log (data.item1Title);
				a.addItem (temp2);
			}
				
			if (data.item2 != null) {
				split = data.item2.Split (new string[] { " " }, System.StringSplitOptions.None);
				temp = new Item (int.Parse (split [0]), data.item2Title, split [1], int.Parse (split [2]),
					int.Parse (split [3]), int.Parse (split [4]), int.Parse (split [5]), int.Parse (split [6]), 
					int.Parse (split [7]), int.Parse (split [8]), data.item2Desc, int.Parse (split [9]),
					split [10]);
				temp2.loadStats (temp);
				a.addItem (temp2);
			}

			if (data.item3 != null) {
				split = data.item3.Split (new string[] { " " }, System.StringSplitOptions.None);
				temp = new Item (int.Parse (split [0]), data.item3Title, split [1], int.Parse (split [2]),
					int.Parse (split [3]), int.Parse (split [4]), int.Parse (split [5]), int.Parse (split [6]), 
					int.Parse (split [7]), int.Parse (split [8]), data.item3Desc, int.Parse (split [9]),
					split [10]);
				temp2.loadStats (temp);
				a.addItem (temp2);
			}

			if (data.item4 != null) {
				split = data.item4.Split (new string[] { " " }, System.StringSplitOptions.None);
				temp = new Item (int.Parse (split [0]), data.item4Title, split [1], int.Parse (split [2]),
					int.Parse (split [3]), int.Parse (split [4]), int.Parse (split [5]), int.Parse (split [6]), 
					int.Parse (split [7]), int.Parse (split [8]), data.item4Desc, int.Parse (split [9]),
					split [10]);
				temp2.loadStats (temp);
				a.addItem (temp2);
			}

			if (data.item5 != null) {
				split = data.item5.Split (new string[] { " " }, System.StringSplitOptions.None);
				temp = new Item (int.Parse (split [0]), data.item5Title, split [1], int.Parse (split [2]),
					int.Parse (split [3]), int.Parse (split [4]), int.Parse (split [5]), int.Parse (split [6]), 
					int.Parse (split [7]), int.Parse (split [8]), data.item5Desc, int.Parse (split [9]),
					split [10]);
				temp2.loadStats (temp);
				a.addItem (temp2);
			}

			if (data.item6 != null) {
				split = data.item6.Split (new string[] { " " }, System.StringSplitOptions.None);
				temp = new Item (int.Parse (split [0]), data.item6Title, split [1], int.Parse (split [2]),
					int.Parse (split [3]), int.Parse (split [4]), int.Parse (split [5]), int.Parse (split [6]), 
					int.Parse (split [7]), int.Parse (split [8]), data.item6Desc, int.Parse (split [9]),
					split [10]);
				temp2.loadStats (temp);
				a.addItem (temp2);
			}

			if (data.item7 != null) {
				split = data.item7.Split (new string[] { " " }, System.StringSplitOptions.None);
				temp = new Item (int.Parse (split [0]), data.item7Title, split [1], int.Parse (split [2]),
					int.Parse (split [3]), int.Parse (split [4]), int.Parse (split [5]), int.Parse (split [6]), 
					int.Parse (split [7]), int.Parse (split [8]), data.item7Desc, int.Parse (split [9]),
					split [10]);
				temp2.loadStats (temp);
				a.addItem (temp2);
			}

			if (data.item8 != null) {
				split = data.item8.Split (new string[] { " " }, System.StringSplitOptions.None);
				temp = new Item (int.Parse (split [0]), data.item8Title, split [1], int.Parse (split [2]),
					int.Parse (split [3]), int.Parse (split [4]), int.Parse (split [5]), int.Parse (split [6]), 
					int.Parse (split [7]), int.Parse (split [8]), data.item8Desc, int.Parse (split [9]),
					split [10]);
				temp2.loadStats (temp);
				a.addItem (temp2);
			}

			if (data.item9 != null) {
				split = data.item9.Split (new string[] { " " }, System.StringSplitOptions.None);
				temp = new Item (int.Parse (split [0]), data.item9Title, split [1], int.Parse (split [2]),
					int.Parse (split [3]), int.Parse (split [4]), int.Parse (split [5]), int.Parse (split [6]), 
					int.Parse (split [7]), int.Parse (split [8]), data.item9Desc, int.Parse (split [9]),
					split [10]);
				temp2.loadStats (temp);
				a.addItem (temp2);
			}
				
			if (data.potion0 != null) {
				split = data.potion0.Split (new string[] { " " }, System.StringSplitOptions.None);
				for (int i = 0; i < int.Parse(split[7]); i++) {
					a.addPotion (int.Parse(split[0]));
				}
			}

			if (data.potion1 != null) {
				split = data.potion1.Split (new string[] { " " }, System.StringSplitOptions.None);
				for (int i = 0; i < int.Parse(split[7]); i++) {
					a.addPotion (int.Parse(split[0]));
				}
			}

			if (data.potion2 != null) {
				split = data.potion2.Split (new string[] { " " }, System.StringSplitOptions.None);
				for (int i = 0; i < int.Parse(split[7]); i++) {
					a.addPotion (int.Parse(split[0]));
				}
			}

			if (data.potion3 != null) {
				split = data.potion3.Split (new string[] { " " }, System.StringSplitOptions.None);
				for (int i = 0; i < int.Parse(split[7]); i++) {
					a.addPotion (int.Parse(split[0]));
				}
			}

			if (data.potion4 != null) {
				split = data.potion4.Split (new string[] { " " }, System.StringSplitOptions.None);
				for (int i = 0; i < int.Parse(split[7]); i++) {
					a.addPotion (int.Parse(split[0]));
				}
			}

			if (data.potion5 != null) {
				split = data.potion5.Split (new string[] { " " }, System.StringSplitOptions.None);
				for (int i = 0; i < int.Parse(split[7]); i++) {
					a.addPotion (int.Parse(split[0]));
				}
			}

			if (data.potion6 != null) {
				split = data.potion6.Split (new string[] { " " }, System.StringSplitOptions.None);
				for (int i = 0; i < int.Parse(split[7]); i++) {
					a.addPotion (int.Parse(split[0]));
				}
			}

			if (data.potion7 != null) {
				split = data.potion7.Split (new string[] { " " }, System.StringSplitOptions.None);
				for (int i = 0; i < int.Parse(split[7]); i++) {
					a.addPotion (int.Parse(split[0]));
				}
			}

			if (data.equip0 != null) {
				split = data.equip0.Split (new string[] { " " }, System.StringSplitOptions.None);
				temp = new Item (int.Parse (split [0]), data.equip0Title, split [1], int.Parse (split [2]),
					int.Parse (split [3]), int.Parse (split [4]), int.Parse (split [5]), int.Parse (split [6]), 
					int.Parse (split [7]), int.Parse (split [8]), data.equip0Desc, int.Parse (split [9]),
					split [10]);
				a.addEquipment (temp, 0, true);
				a.resources.changeHelmet ("DrawingsV2/Items/Equipment/" + temp.Slug);
			}

			if (data.equip1 != null) {
				split = data.equip1.Split (new string[] { " " }, System.StringSplitOptions.None);
				temp = new Item (int.Parse (split [0]), data.equip1Title, split [1], int.Parse (split [2]),
					int.Parse (split [3]), int.Parse (split [4]), int.Parse (split [5]), int.Parse (split [6]), 
					int.Parse (split [7]), int.Parse (split [8]), data.equip1Desc, int.Parse (split [9]),
					split [10]);
				a.addEquipment (temp, 1, true);
				a.resources.changeArmor ("DrawingsV2/Items/Equipment/" + temp.Slug);
			}

			if (data.equip2 != null) {
				split = data.equip2.Split (new string[] { " " }, System.StringSplitOptions.None);
				temp = new Item (int.Parse (split [0]), data.equip2Title, split [1], int.Parse (split [2]),
					int.Parse (split [3]), int.Parse (split [4]), int.Parse (split [5]), int.Parse (split [6]), 
					int.Parse (split [7]), int.Parse (split [8]), data.equip2Desc, int.Parse (split [9]),
					split [10]);
				a.addEquipment (temp, 2, true);
				a.resources.changeSword ("DrawingsV2/Items/Equipment/" + temp.Slug);
			}

			if (data.equip3 != null) {
				split = data.equip3.Split (new string[] { " " }, System.StringSplitOptions.None);
				temp = new Item (int.Parse (split [0]), data.equip3Title, split [1], int.Parse (split [2]),
					int.Parse (split [3]), int.Parse (split [4]), int.Parse (split [5]), int.Parse (split [6]), 
					int.Parse (split [7]), int.Parse (split [8]), data.equip3Desc, int.Parse (split [9]),
					split [10]);
				a.addEquipment (temp, 3, true);
				a.resources.changeSpear ("DrawingsV2/Items/Equipment/" + temp.Slug);
			}

			if (data.equip4 != null) {
				split = data.equip4.Split (new string[] { " " }, System.StringSplitOptions.None);
				temp = new Item (int.Parse (split [0]), data.equip4Title, split [1], int.Parse (split [2]),
					int.Parse (split [3]), int.Parse (split [4]), int.Parse (split [5]), int.Parse (split [6]), 
					int.Parse (split [7]), int.Parse (split [8]), data.equip4Desc, int.Parse (split [9]),
					split [10]);
				a.addEquipment (temp, 4, true);
				a.resources.changeAxe ("DrawingsV2/Items/Equipment/" + temp.Slug);
			}

			if (data.equip5 != null) {
				split = data.equip5.Split (new string[] { " " }, System.StringSplitOptions.None);
				temp = new Item (int.Parse (split [0]), data.equip5Title, split [1], int.Parse (split [2]),
					int.Parse (split [3]), int.Parse (split [4]), int.Parse (split [5]), int.Parse (split [6]), 
					int.Parse (split [7]), int.Parse (split [8]), data.equip5Desc, int.Parse (split [9]),
					split [10]);
				a.addEquipment (temp, 5, true);
				a.resources.changeDagger ("DrawingsV2/Items/Equipment/" + temp.Slug);
			}

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
