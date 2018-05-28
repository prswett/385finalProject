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
	public Text def;
	public Text avo;

    public Text sP;
	public Text cd;

	void Awake() {
		str = GameObject.Find ("str").GetComponentInChildren<Text> ();
		dex = GameObject.Find ("dex").GetComponentInChildren<Text> ();
		wis = GameObject.Find ("wis").GetComponentInChildren<Text> ();
		luk = GameObject.Find ("luk").GetComponentInChildren<Text> ();
		atk = GameObject.Find ("atk").GetComponentInChildren<Text> ();
		matk = GameObject.Find ("matk").GetComponentInChildren<Text> ();
		crit = GameObject.Find ("critical").GetComponentInChildren<Text> ();
		sP = GameObject.Find ("sP").GetComponentInChildren<Text> ();
		def = GameObject.Find ("def").GetComponentInChildren<Text> ();
		avo = GameObject.Find ("avo").GetComponentInChildren<Text> ();
		cd = GameObject.Find ("cd").GetComponentInChildren<Text> ();
	}

    void Start () {
		
	}

	void Update () {
        str.text = "str: " + PlayerStatistics.str.ToString();
        dex.text = "dex: " + PlayerStatistics.dex.ToString();
        wis.text = "wis: " + PlayerStatistics.wis.ToString();
        luk.text = "luk: " + PlayerStatistics.luk.ToString();

        atk.text = "atk: " + PlayerStatistics.atk.ToString();
        matk.text = "matk: " + PlayerStatistics.matk.ToString();

        crit.text = "critical: " + PlayerStatistics.cc.ToString();

        sP.text = "stat points left: " + PlayerStatistics.statPoints.ToString();
		def.text = "def: " + PlayerStatistics.def.ToString ();
		avo.text = "avo: " + PlayerStatistics.avo.ToString ();
		cd.text = "cd: " + PlayerStatistics.cd.ToString ();
    }

}
