using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStatistics  : MonoBehaviour
{
	public static float coins = 50;

	public static float lastHit = 0;

	public static float baseHealth = 100;
	// current hp
	public static float health = 100;
	// maximum health points
	public static float maxHealth = 100;

	public static float baseMana = 5;
	// current mp
	public static float mana = 5;
	// maximum mana points
	public static float maxMana = 5;

	// speed of the character
	//public static float speed;
	// rate at which the character jumps
	//public static float jumpSpeed;

	// ability stats
	// stats manipulate abilities and modifiers on weapons, skills, etc.

	// stats should be able to be rese t and reallocated through
	// earned in game currency (maybe increasing price up to fixed amount)
	public static float atk = 0;
	public static float matk = 0;
	// strength modifies all physical weapon attack damage, increases health
	// crit damage
	public static float str = 1;
	// dexterity modifies accuracy and avoidability
	public static float dex = 1;
	// increases magic attack, mana points
	public static float wis = 1;
	// increases chances of drops, exp gained
	// crit chance
	public static float luk = 1;

	// all weapons do some base damage when physically swung based on this stat
	public static float wa = 1;
	// skills and effects will scale off of magic attack
	public static float ma = 1;

	// physical defense reduces damage taken by %
	public static float def = 1;


	// the rate at which you hit the enemy (enemy avoid - your accuracy)
	public static float acc;
	// the rate at which enemies hit you (your avoid - enemy accuracy)
	public static float avo;

	// crit chance
	public static float cc = 5;

	public static float cd = 50;

	// exp as a total of all the exp the character has EVER gained
	public static float exp = 0;

	// ignore enemy defense% (enemy defense * (ied / 100))
	public static float ied = 30;

	// multiplier for exp
	public static float expMod = 1;

	public static float level = 1;
	// exp needed to reach next level
	public static float nextLevel = 10;

	// everyone starts with 5 stat points
	public static float statPoints = 5;

	public static void load() {
		maxHealth = baseHealth + (3 * str);
		maxMana = baseMana + (wis / 3);
		health = maxHealth;
		mana = maxMana;
	}

	public static float calcPD() {
		float crit = UnityEngine.Random.Range (0, 101);
		float dam = atk * 1.5f;
		if (cc > crit) {
			dam = atk * (1 + (cd / 100));
		}
		return dam;
	}

	public static float calcMD() {
		float crit = UnityEngine.Random.Range (0, 101);
		float dam = matk * 3f;
		if (cc > crit) {
			dam = matk * (1 + (cd / 100));
		}
		return dam;
	}

	public static void takeDamage(float damage) {
		if (Time.time - lastHit >= 0.5) {
			health -= (damage * (1 + (level / 50)) * (1000 / (def + 1000)));
			lastHit = Time.time;
		}
	}

	// put in stat points
	public static void aStr()
	{
		if (statPoints >= 1)
		{
			statPoints -= 1;
			str += 1;
		}
	}

	public static void aDex()
	{
		if (statPoints >= 1)
		{
			statPoints -= 1;
			dex += 1;
		}
	}

	public static void aInt()
	{
		if (statPoints >= 1)
		{
			statPoints -= 1;
			wis += 1;
		}
	}

	public static void aLuk()
	{
		if (statPoints >= 1)
		{
			statPoints -= 1;
			luk += 1;
		}
	}



	private void Update()
	{
		//
		maxHealth = baseHealth + (3 * str);
		maxMana = baseMana + (wis / 3);
		// atk scales off WA + 0.5*Str + 0.25Dex
		atk = (float)((str * 0.5) + (dex * 0.25) + wa);
		// matk scales off MA + 0.8*wis
		matk = ma + (float)(wis * 0.8);
		// crit chance scales off of 0.5 * luk
		cc = 5 + (float)(luk * 0.5);
		// more luk more crit
		expMod = 1 + (float)(luk * 0.01);
		// enemy avo - acc is hit chance
		acc = 90 + (float)(dex * 0.5);
		// chance to get hit
		avo = 10 + (float)((dex * 0.2) + (luk * 0.5));
		// ied
		ied = 30 + (float)(luk * 0.05);
		//crit damage
		cd = 50 + (float)(luk * 0.05);

		// check if exp reached
		if(exp >= nextLevel)
		{
			health = maxHealth;
			mana = maxMana;
			// next level reached
			exp -= nextLevel;
			// exp to next level += 20
			nextLevel += 20;
			// more stat points
			statPoints += 3;
			level++;
		}
	}
}
