using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addStat : MonoBehaviour {

	public void addStr()
    {
        PlayerStatistics.aStr();
    }
    public void addDex()
    {
        PlayerStatistics.aDex();
    }
    public void addWis()
    {
        PlayerStatistics.aInt();
    }
    public void addLuk()
    {
        PlayerStatistics.aLuk();
    }
}
