using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

	public class SavePoint : MonoBehaviour {

		public Boolean inside = false;

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
		data.itl = PlayerStatistics.itl;
		data.luk = PlayerStatistics.luk;

		data.exp = PlayerStatistics.exp;

			//moves to file
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
		public float itl;
		public float luk;

		public float exp;
		public float nextLevel;
	}