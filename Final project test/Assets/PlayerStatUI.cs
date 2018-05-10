using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatUI : MonoBehaviour {

    public Text str;
    public Text dex;
    public Text wis;
    public Text luk;

    public Text atk;
    public Text matk;

    public Text crit;

    public Text sP;

    public Button addStr;
    public Button addDex;
    public Button addWis;
    public Button addLuk;


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        str.text = "str: " + PlayerStatistics.str.ToString();
        dex.text = "dex: " + PlayerStatistics.dex.ToString();
        wis.text = "wis: " + PlayerStatistics.wis.ToString();
        luk.text = "luk: " + PlayerStatistics.luk.ToString();

        atk.text = "atk: " + PlayerStatistics.atk.ToString();
        matk.text = "matk: " + PlayerStatistics.matk.ToString();

        crit.text = "critical: " + PlayerStatistics.cc.ToString();

        sP.text = "stat points left: " + PlayerStatistics.statPoints.ToString();
    }

    /*
    public void buttonASTR()
    {
        PlayerStatistics.aStr();
    }

    public void buttonADEX()
    {
        PlayerStatistics.aDex();
    }

    public void buttonAWIS()
    {
        PlayerStatistics.aInt);
    }

    public void buttonALUK()
    {
        PlayerStatistics.aLuk();
    }*/

}
