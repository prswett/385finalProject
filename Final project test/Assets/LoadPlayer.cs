using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPlayer : MonoBehaviour {

	// loading data if exists
	public void Load()
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
			PlayerStatistics.itl = data.itl;
			PlayerStatistics.luk = data.luk;

			PlayerStatistics.exp = data.exp;
			PlayerStatistics.nextLevel = data.nextLevel;
		}
		SceneManager.LoadScene(1);
	}

	// Update is called once per frame
	void Update () {

	}
}