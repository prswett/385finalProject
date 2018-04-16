using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStatistics {
    // current hp
    public float health = 5;
    // maximum health points
    public float maxHealth = 5;
    // current mp
    public float mana = 5;
    // maximum mana points
    public float maxMana = 5;

    // speed of the character
    //public static float speed;
    // rate at which the character jumps
    //public static float jumpSpeed;

    // ability stats
    // stats manipulate abilities and modifiers on weapons, skills, etc.

    // stats should be able to be rese t and reallocated through
    // earned in game currency (maybe increasing price up to fixed amount)

    // strength modifies all physical weapon attack damage, increases health
    // crit damage
    public static float str;
    // dexterity modifies accuracy and avoidability
    public static float dex;
    // increases magic attack, mana points
    public static float itl;
    // increases chances of drops, exp gained
    // crit chance
    public static float luk;

    // all weapons do some base damage when physically swung based on this stat
    public static float atk;
    // skills and effects will scale off of magic attack
    public static float matk;

    // the rate at which you hit the enemy (enemy avoid - your accuracy)
    public static float acc;
    // the rate at which enemies hit you (your avoid - enemy accuracy)
    public static float avo;

    // exp as a total of all the exp the character has EVER gained
    public static float exp;

}
