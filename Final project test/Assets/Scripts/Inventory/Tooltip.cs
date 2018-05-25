using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

    private ItemStats item;
    private string data;
    private GameObject tooltip;
	public Equipment eInv;

	string strdiff;
	string dexdiff;
	string wisdiff;
	string lukdiff;
	string atkdiff;
	string defdiff;

    void Start()
    {
		eInv = GameObject.Find ("EquipmentInventory").GetComponent<Equipment> ();
        tooltip = GameObject.Find("Tooltip");
        tooltip.SetActive(false);
    }

    void Update()
    {
        if (tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition;
        }
    }

    public void Activate(ItemStats item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
    }

    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    public void ConstructDataString()
    {
		string upgradeCost;
		if (item.type == "Helmet") {
			if (eInv.slots [0].GetComponent<EquipmentSlot> ().item != null) {
				ItemStats temp = eInv.slots [0].GetComponent<EquipmentSlot> ().item.GetComponent<ItemStats> ();
				if (item.str < temp.str) {
					strdiff = "<color=#f00b04><b>" + (item.str - temp.str);
				} else {
					strdiff = "<color=#0473f0><b>+" + (item.str - temp.str);
				}
				if (item.dex < temp.dex) {
					dexdiff = "<color=#f00b04><b>" + (item.dex - temp.dex);
				} else {
					dexdiff = "<color=#0473f0><b>+" + (item.dex - temp.dex);
				}
				if (item.wis < temp.wis) {
					wisdiff = "<color=#f00b04><b>" + (item.wis - temp.wis);
				} else {
					wisdiff = "<color=#0473f0><b>+" + (item.wis - temp.wis);
				}
				if (item.luk < temp.luk) {
					lukdiff = "<color=#f00b04><b>" + (item.luk - temp.luk);
				} else {
					lukdiff = "<color=#0473f0><b>+" + (item.luk - temp.luk);
				}
				if (item.atk < temp.atk) {
					atkdiff = "<color=#f00b04><b>" + (item.atk - temp.atk);
				} else {
					atkdiff = "<color=#0473f0><b>+" + (item.atk - temp.atk);
				}
				if (item.def < temp.def) {
					defdiff = "<color=#f00b04><b>" + (item.def - temp.def);
				} else {
					defdiff = "<color=#0473f0><b>+" + (item.def - temp.def);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + 
					"\nStr: " + item.str + " (" + strdiff + "</b></color>)" + 
					"\nDex: " + item.dex + " (" + dexdiff + "</b></color>)" + 
					"\nWis: " + item.wis + " (" + wisdiff + "</b></color>)" + 
					"\nLuk: " + item.luk + " (" + lukdiff + "</b></color>)" + 
					"\nAtk: " + item.atk + " (" + atkdiff + "</b></color>)" + 
					"\nDef: " + item.def + " (" + defdiff + "</b></color>)" + 
					"\n<color=#e9f004><b>Value: " + item.Value +
					"\nUpgrade Cost: " + item.Rarity * item.Value + "</b></color>";
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			} else {
				upgradeCost = "<color=#e9f004><b>" + (item.Rarity * item.Value);
				if (item.str < 0) {
					strdiff = "<color=#f00b04><b>" + (item.str - 0);
				} else {
					strdiff = "<color=#0473f0><b>+" + (item.str - 0);
				}
				if (item.dex < 0) {
					dexdiff = "<color=#f00b04><b>" + (item.dex - 0);
				} else {
					dexdiff = "<color=#0473f0><b>+" + (item.dex - 0);
				}
				if (item.wis < 0) {
					wisdiff = "<color=#f00b04><b>" + (item.wis - 0);
				} else {
					wisdiff = "<color=#0473f0><b>+" + (item.wis - 0);
				}
				if (item.luk < 0) {
					lukdiff = "<color=#f00b04><b>" + (item.luk - 0);
				} else {
					lukdiff = "<color=#0473f0><b>+" + (item.luk - 0);
				}
				if (item.atk < 0) {
					atkdiff = "<color=#f00b04><b>" + (item.atk - 0);
				} else {
					atkdiff = "<color=#0473f0><b>+" + (item.atk - 0);
				}
				if (item.def < 0) {
					defdiff = "<color=#f00b04><b>" + (item.def - 0);
				} else {
					defdiff = "<color=#0473f0><b>+" + (item.def - 0);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description +
					"\nStr: " + item.str + " (" + strdiff + "</b></color>)" +
					"\nDex: " + item.dex + " (" + dexdiff + "</b></color>)" +
					"\nWis: " + item.wis + " (" + wisdiff + "</b></color>)" +
					"\nLuk: " + item.luk + " (" + lukdiff + "</b></color>)" +
					"\nAtk: " + item.atk + " (" + atkdiff + "</b></color>)" +
					"\nDef: " + item.def + " (" + defdiff + "</b></color>)" +
					"\n<color=#e9f004><b>Value: " + item.Value +
					"\nUpgrade Cost: " + item.Rarity * item.Value + "</b></color>";
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			}
		} else if (item.type == "Armor") {
			if (eInv.slots [1].GetComponent<EquipmentSlot> ().item != null) {
				ItemStats temp = eInv.slots [1].GetComponent<EquipmentSlot> ().item.GetComponent<ItemStats> ();
				if (item.str < temp.str) {
					strdiff = "<color=#f00b04><b>" + (item.str - temp.str);
				} else {
					strdiff = "<color=#0473f0><b>+" + (item.str - temp.str);
				}
				if (item.dex < temp.dex) {
					dexdiff = "<color=#f00b04><b>" + (item.dex - temp.dex);
				} else {
					dexdiff = "<color=#0473f0><b>+" + (item.dex - temp.dex);
				}
				if (item.wis < temp.wis) {
					wisdiff = "<color=#f00b04><b>" + (item.wis - temp.wis);
				} else {
					wisdiff = "<color=#0473f0><b>+" + (item.wis - temp.wis);
				}
				if (item.luk < temp.luk) {
					lukdiff = "<color=#f00b04><b>" + (item.luk - temp.luk);
				} else {
					lukdiff = "<color=#0473f0><b>+" + (item.luk - temp.luk);
				}
				if (item.atk < temp.atk) {
					atkdiff = "<color=#f00b04><b>" + (item.atk - temp.atk);
				} else {
					atkdiff = "<color=#0473f0><b>+" + (item.atk - temp.atk);
				}
				if (item.def < temp.def) {
					defdiff = "<color=#f00b04><b>" + (item.def - temp.def);
				} else {
					defdiff = "<color=#0473f0><b>+" + (item.def - temp.def);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + 
					"\nStr: " + item.str + " (" + strdiff + "</b></color>)" + 
					"\nDex: " + item.dex + " (" + dexdiff + "</b></color>)" + 
					"\nWis: " + item.wis + " (" + wisdiff + "</b></color>)" + 
					"\nLuk: " + item.luk + " (" + lukdiff + "</b></color>)" + 
					"\nAtk: " + item.atk + " (" + atkdiff + "</b></color>)" + 
					"\nDef: " + item.def + " (" + defdiff + "</b></color>)" + 
					"\n<color=#e9f004><b>Value: " + item.Value +
					"\nUpgrade Cost: " + item.Rarity * item.Value + "</b></color>";
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			} else {
				 upgradeCost = "<color=#e9f004><b>" + item.Rarity * item.Value;
				if (item.str < 0) {
					strdiff = "<color=#f00b04><b>" + (item.str - 0);
				} else {
					strdiff = "<color=#0473f0><b>+" + (item.str - 0);
				}
				if (item.dex < 0) {
					dexdiff = "<color=#f00b04><b>" + (item.dex - 0);
				} else {
					dexdiff = "<color=#0473f0><b>+" + (item.dex - 0);
				}
				if (item.wis < 0) {
					wisdiff = "<color=#f00b04><b>" + (item.wis - 0);
				} else {
					wisdiff = "<color=#0473f0><b>+" + (item.wis - 0);
				}
				if (item.luk < 0) {
					lukdiff = "<color=#f00b04><b>" + (item.luk - 0);
				} else {
					lukdiff = "<color=#0473f0><b>+" + (item.luk - 0);
				}
				if (item.atk < 0) {
					atkdiff = "<color=#f00b04><b>" + (item.atk - 0);
				} else {
					atkdiff = "<color=#0473f0><b>+" + (item.atk - 0);
				}
				if (item.def < 0) {
					defdiff = "<color=#f00b04><b>" + (item.def - 0);
				} else {
					defdiff = "<color=#0473f0><b>+" + (item.def - 0);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description +
					"\nStr: " + item.str + " (" + strdiff + "</b></color>)" +
					"\nDex: " + item.dex + " (" + dexdiff + "</b></color>)" +
					"\nWis: " + item.wis + " (" + wisdiff + "</b></color>)" +
					"\nLuk: " + item.luk + " (" + lukdiff + "</b></color>)" +
					"\nAtk: " + item.atk + " (" + atkdiff + "</b></color>)" +
					"\nDef: " + item.def + " (" + defdiff + "</b></color>)" +
					"\n<color=#e9f004><b>Value: " + item.Value +
					"\nUpgrade Cost: " + item.Rarity * item.Value + "</b></color>";
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			}
		} else if (item.type == "Sword") {
			if (eInv.slots [2].GetComponent<EquipmentSlot> ().item != null) {
				ItemStats temp = eInv.slots [2].GetComponent<EquipmentSlot> ().item.GetComponent<ItemStats> ();
				if (item.str < temp.str) {
					strdiff = "<color=#f00b04><b>" + (item.str - temp.str);
				} else {
					strdiff = "<color=#0473f0><b>+" + (item.str - temp.str);
				}
				if (item.dex < temp.dex) {
					dexdiff = "<color=#f00b04><b>" + (item.dex - temp.dex);
				} else {
					dexdiff = "<color=#0473f0><b>+" + (item.dex - temp.dex);
				}
				if (item.wis < temp.wis) {
					wisdiff = "<color=#f00b04><b>" + (item.wis - temp.wis);
				} else {
					wisdiff = "<color=#0473f0><b>+" + (item.wis - temp.wis);
				}
				if (item.luk < temp.luk) {
					lukdiff = "<color=#f00b04><b>" + (item.luk - temp.luk);
				} else {
					lukdiff = "<color=#0473f0><b>+" + (item.luk - temp.luk);
				}
				if (item.atk < temp.atk) {
					atkdiff = "<color=#f00b04><b>" + (item.atk - temp.atk);
				} else {
					atkdiff = "<color=#0473f0><b>+" + (item.atk - temp.atk);
				}
				if (item.def < temp.def) {
					defdiff = "<color=#f00b04><b>" + (item.def - temp.def);
				} else {
					defdiff = "<color=#0473f0><b>+" + (item.def - temp.def);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + 
					"\nStr: " + item.str + " (" + strdiff + "</b></color>)" + 
					"\nDex: " + item.dex + " (" + dexdiff + "</b></color>)" + 
					"\nWis: " + item.wis + " (" + wisdiff + "</b></color>)" + 
					"\nLuk: " + item.luk + " (" + lukdiff + "</b></color>)" + 
					"\nAtk: " + item.atk + " (" + atkdiff + "</b></color>)" + 
					"\nDef: " + item.def + " (" + defdiff + "</b></color>)" + 
					"\n<color=#e9f004><b>Value: " + item.Value +
					"\nUpgrade Cost: " + item.Rarity * item.Value + "</b></color>";
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			} else {
				 upgradeCost = "<color=#e9f004><b>" + item.Rarity * item.Value;
				if (item.str < 0) {
					strdiff = "<color=#f00b04><b>" + (item.str - 0);
				} else {
					strdiff = "<color=#0473f0><b>+" + (item.str - 0);
				}
				if (item.dex < 0) {
					dexdiff = "<color=#f00b04><b>" + (item.dex - 0);
				} else {
					dexdiff = "<color=#0473f0><b>+" + (item.dex - 0);
				}
				if (item.wis < 0) {
					wisdiff = "<color=#f00b04><b>" + (item.wis - 0);
				} else {
					wisdiff = "<color=#0473f0><b>+" + (item.wis - 0);
				}
				if (item.luk < 0) {
					lukdiff = "<color=#f00b04><b>" + (item.luk - 0);
				} else {
					lukdiff = "<color=#0473f0><b>+" + (item.luk - 0);
				}
				if (item.atk < 0) {
					atkdiff = "<color=#f00b04><b>" + (item.atk - 0);
				} else {
					atkdiff = "<color=#0473f0><b>+" + (item.atk - 0);
				}
				if (item.def < 0) {
					defdiff = "<color=#f00b04><b>" + (item.def - 0);
				} else {
					defdiff = "<color=#0473f0><b>+" + (item.def - 0);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description +
					"\nStr: " + item.str + " (" + strdiff + "</b></color>)" +
					"\nDex: " + item.dex + " (" + dexdiff + "</b></color>)" +
					"\nWis: " + item.wis + " (" + wisdiff + "</b></color>)" +
					"\nLuk: " + item.luk + " (" + lukdiff + "</b></color>)" +
					"\nAtk: " + item.atk + " (" + atkdiff + "</b></color>)" +
					"\nDef: " + item.def + " (" + defdiff + "</b></color>)" +
					"\n<color=#e9f004><b>Value: " + item.Value +
					"\nUpgrade Cost: " + item.Rarity * item.Value + "</b></color>";
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			}
		} else if (item.type == "Spear") {
			if (eInv.slots [3].GetComponent<EquipmentSlot> ().item != null) {
				ItemStats temp = eInv.slots [3].GetComponent<EquipmentSlot> ().item.GetComponent<ItemStats> ();
				if (item.str < temp.str) {
					strdiff = "<color=#f00b04><b>" + (item.str - temp.str);
				} else {
					strdiff = "<color=#0473f0><b>+" + (item.str - temp.str);
				}
				if (item.dex < temp.dex) {
					dexdiff = "<color=#f00b04><b>" + (item.dex - temp.dex);
				} else {
					dexdiff = "<color=#0473f0><b>+" + (item.dex - temp.dex);
				}
				if (item.wis < temp.wis) {
					wisdiff = "<color=#f00b04><b>" + (item.wis - temp.wis);
				} else {
					wisdiff = "<color=#0473f0><b>+" + (item.wis - temp.wis);
				}
				if (item.luk < temp.luk) {
					lukdiff = "<color=#f00b04><b>" + (item.luk - temp.luk);
				} else {
					lukdiff = "<color=#0473f0><b>+" + (item.luk - temp.luk);
				}
				if (item.atk < temp.atk) {
					atkdiff = "<color=#f00b04><b>" + (item.atk - temp.atk);
				} else {
					atkdiff = "<color=#0473f0><b>+" + (item.atk - temp.atk);
				}
				if (item.def < temp.def) {
					defdiff = "<color=#f00b04><b>" + (item.def - temp.def);
				} else {
					defdiff = "<color=#0473f0><b>+" + (item.def - temp.def);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + 
					"\nStr: " + item.str + " (" + strdiff + "</b></color>)" + 
					"\nDex: " + item.dex + " (" + dexdiff + "</b></color>)" + 
					"\nWis: " + item.wis + " (" + wisdiff + "</b></color>)" + 
					"\nLuk: " + item.luk + " (" + lukdiff + "</b></color>)" + 
					"\nAtk: " + item.atk + " (" + atkdiff + "</b></color>)" + 
					"\nDef: " + item.def + " (" + defdiff + "</b></color>)" + 
					"\n<color=#e9f004><b>Value: " + item.Value +
					"\nUpgrade Cost: " + item.Rarity * item.Value + "</b></color>";
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			} else {
				 upgradeCost = "<color=#e9f004><b>" + item.Rarity * item.Value;
				if (item.str < 0) {
					strdiff = "<color=#f00b04><b>" + (item.str - 0);
				} else {
					strdiff = "<color=#0473f0><b>+" + (item.str - 0);
				}
				if (item.dex < 0) {
					dexdiff = "<color=#f00b04><b>" + (item.dex - 0);
				} else {
					dexdiff = "<color=#0473f0><b>+" + (item.dex - 0);
				}
				if (item.wis < 0) {
					wisdiff = "<color=#f00b04><b>" + (item.wis - 0);
				} else {
					wisdiff = "<color=#0473f0><b>+" + (item.wis - 0);
				}
				if (item.luk < 0) {
					lukdiff = "<color=#f00b04><b>" + (item.luk - 0);
				} else {
					lukdiff = "<color=#0473f0><b>+" + (item.luk - 0);
				}
				if (item.atk < 0) {
					atkdiff = "<color=#f00b04><b>" + (item.atk - 0);
				} else {
					atkdiff = "<color=#0473f0><b>+" + (item.atk - 0);
				}
				if (item.def < 0) {
					defdiff = "<color=#f00b04><b>" + (item.def - 0);
				} else {
					defdiff = "<color=#0473f0><b>+" + (item.def - 0);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description +
					"\nStr: " + item.str + " (" + strdiff + "</b></color>)" +
					"\nDex: " + item.dex + " (" + dexdiff + "</b></color>)" +
					"\nWis: " + item.wis + " (" + wisdiff + "</b></color>)" +
					"\nLuk: " + item.luk + " (" + lukdiff + "</b></color>)" +
					"\nAtk: " + item.atk + " (" + atkdiff + "</b></color>)" +
					"\nDef: " + item.def + " (" + defdiff + "</b></color>)" +
					"\n<color=#e9f004><b>Value: " + item.Value +
					"\nUpgrade Cost: " + item.Rarity * item.Value + "</b></color>";
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			}
		} else if (item.type == "Axe") {
			if (eInv.slots [4].GetComponent<EquipmentSlot> ().item != null) {
				ItemStats temp = eInv.slots [4].GetComponent<EquipmentSlot> ().item.GetComponent<ItemStats> ();
				if (item.str < temp.str) {
					strdiff = "<color=#f00b04><b>" + (item.str - temp.str);
				} else {
					strdiff = "<color=#0473f0><b>+" + (item.str - temp.str);
				}
				if (item.dex < temp.dex) {
					dexdiff = "<color=#f00b04><b>" + (item.dex - temp.dex);
				} else {
					dexdiff = "<color=#0473f0><b>+" + (item.dex - temp.dex);
				}
				if (item.wis < temp.wis) {
					wisdiff = "<color=#f00b04><b>" + (item.wis - temp.wis);
				} else {
					wisdiff = "<color=#0473f0><b>+" + (item.wis - temp.wis);
				}
				if (item.luk < temp.luk) {
					lukdiff = "<color=#f00b04><b>" + (item.luk - temp.luk);
				} else {
					lukdiff = "<color=#0473f0><b>+" + (item.luk - temp.luk);
				}
				if (item.atk < temp.atk) {
					atkdiff = "<color=#f00b04><b>" + (item.atk - temp.atk);
				} else {
					atkdiff = "<color=#0473f0><b>+" + (item.atk - temp.atk);
				}
				if (item.def < temp.def) {
					defdiff = "<color=#f00b04><b>" + (item.def - temp.def);
				} else {
					defdiff = "<color=#0473f0><b>+" + (item.def - temp.def);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + 
					"\nStr: " + item.str + " (" + strdiff + "</b></color>)" + 
					"\nDex: " + item.dex + " (" + dexdiff + "</b></color>)" + 
					"\nWis: " + item.wis + " (" + wisdiff + "</b></color>)" + 
					"\nLuk: " + item.luk + " (" + lukdiff + "</b></color>)" + 
					"\nAtk: " + item.atk + " (" + atkdiff + "</b></color>)" + 
					"\nDef: " + item.def + " (" + defdiff + "</b></color>)" + 
					"\n<color=#e9f004><b>Value: " + item.Value +
					"\nUpgrade Cost: " + item.Rarity * item.Value + "</b></color>";
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			} else {
				 upgradeCost = "<color=#e9f004><b>" + item.Rarity * item.Value;
				if (item.str < 0) {
					strdiff = "<color=#f00b04><b>" + (item.str - 0);
				} else {
					strdiff = "<color=#0473f0><b>+" + (item.str - 0);
				}
				if (item.dex < 0) {
					dexdiff = "<color=#f00b04><b>" + (item.dex - 0);
				} else {
					dexdiff = "<color=#0473f0><b>+" + (item.dex - 0);
				}
				if (item.wis < 0) {
					wisdiff = "<color=#f00b04><b>" + (item.wis - 0);
				} else {
					wisdiff = "<color=#0473f0><b>+" + (item.wis - 0);
				}
				if (item.luk < 0) {
					lukdiff = "<color=#f00b04><b>" + (item.luk - 0);
				} else {
					lukdiff = "<color=#0473f0><b>+" + (item.luk - 0);
				}
				if (item.atk < 0) {
					atkdiff = "<color=#f00b04><b>" + (item.atk - 0);
				} else {
					atkdiff = "<color=#0473f0><b>+" + (item.atk - 0);
				}
				if (item.def < 0) {
					defdiff = "<color=#f00b04><b>" + (item.def - 0);
				} else {
					defdiff = "<color=#0473f0><b>+" + (item.def - 0);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description +
					"\nStr: " + item.str + " (" + strdiff + "</b></color>)" +
					"\nDex: " + item.dex + " (" + dexdiff + "</b></color>)" +
					"\nWis: " + item.wis + " (" + wisdiff + "</b></color>)" +
					"\nLuk: " + item.luk + " (" + lukdiff + "</b></color>)" +
					"\nAtk: " + item.atk + " (" + atkdiff + "</b></color>)" +
					"\nDef: " + item.def + " (" + defdiff + "</b></color>)" +
					"\n<color=#e9f004><b>Value: " + item.Value +
					"\nUpgrade Cost: " + item.Rarity * item.Value + "</b></color>";
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			}
		} else {
			upgradeCost = "<color=#e9f004><b>" + item.Rarity * item.Value;
			if (eInv.slots [5].GetComponent<EquipmentSlot> ().item != null) {
				ItemStats temp = eInv.slots [5].GetComponent<EquipmentSlot> ().item.GetComponent<ItemStats> ();
				if (item.str < temp.str) {
					strdiff = "<color=#f00b04><b>" + (item.str - temp.str);
				} else {
					strdiff = "<color=#0473f0><b>+" + (item.str - temp.str);
				}
				if (item.dex < temp.dex) {
					dexdiff = "<color=#f00b04><b>" + (item.dex - temp.dex);
				} else {
					dexdiff = "<color=#0473f0><b>+" + (item.dex - temp.dex);
				}
				if (item.wis < temp.wis) {
					wisdiff = "<color=#f00b04><b>" + (item.wis - temp.wis);
				} else {
					wisdiff = "<color=#0473f0><b>+" + (item.wis - temp.wis);
				}
				if (item.luk < temp.luk) {
					lukdiff = "<color=#f00b04><b>" + (item.luk - temp.luk);
				} else {
					lukdiff = "<color=#0473f0><b>+" + (item.luk - temp.luk);
				}
				if (item.atk < temp.atk) {
					atkdiff = "<color=#f00b04><b>" + (item.atk - temp.atk);
				} else {
					atkdiff = "<color=#0473f0><b>+" + (item.atk - temp.atk);
				}
				if (item.def < temp.def) {
					defdiff = "<color=#f00b04><b>" + (item.def - temp.def);
				} else {
					defdiff = "<color=#0473f0><b>+" + (item.def - temp.def);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + 
					"\nStr: " + item.str + " (" + strdiff + "</b></color>)" + 
					"\nDex: " + item.dex + " (" + dexdiff + "</b></color>)" + 
					"\nWis: " + item.wis + " (" + wisdiff + "</b></color>)" + 
					"\nLuk: " + item.luk + " (" + lukdiff + "</b></color>)" + 
					"\nAtk: " + item.atk + " (" + atkdiff + "</b></color>)" + 
					"\nDef: " + item.def + " (" + defdiff + "</b></color>)" + 
					"\n<color=#e9f004><b>Value: " + item.Value +
					"\nUpgrade Cost: " + item.Rarity * item.Value + "</b></color>";
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			} else {
				 upgradeCost = "<color=#e9f004><b>" + item.Rarity * item.Value;
				if (item.str < 0) {
					strdiff = "<color=#f00b04><b>" + (item.str - 0);
				} else {
					strdiff = "<color=#0473f0><b>+" + (item.str - 0);
				}
				if (item.dex < 0) {
					dexdiff = "<color=#f00b04><b>" + (item.dex - 0);
				} else {
					dexdiff = "<color=#0473f0><b>+" + (item.dex - 0);
				}
				if (item.wis < 0) {
					wisdiff = "<color=#f00b04><b>" + (item.wis - 0);
				} else {
					wisdiff = "<color=#0473f0><b>+" + (item.wis - 0);
				}
				if (item.luk < 0) {
					lukdiff = "<color=#f00b04><b>" + (item.luk - 0);
				} else {
					lukdiff = "<color=#0473f0><b>+" + (item.luk - 0);
				}
				if (item.atk < 0) {
					atkdiff = "<color=#f00b04><b>" + (item.atk - 0);
				} else {
					atkdiff = "<color=#0473f0><b>+" + (item.atk - 0);
				}
				if (item.def < 0) {
					defdiff = "<color=#f00b04><b>" + (item.def - 0);
				} else {
					defdiff = "<color=#0473f0><b>+" + (item.def - 0);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description +
				"\nStr: " + item.str + " (" + strdiff + "</b></color>)" +
				"\nDex: " + item.dex + " (" + dexdiff + "</b></color>)" +
				"\nWis: " + item.wis + " (" + wisdiff + "</b></color>)" +
				"\nLuk: " + item.luk + " (" + lukdiff + "</b></color>)" +
				"\nAtk: " + item.atk + " (" + atkdiff + "</b></color>)" +
				"\nDef: " + item.def + " (" + defdiff + "</b></color>)" +
				"\n<color=#e9f004><b>Value: " + item.Value +
				"\nUpgrade Cost: " + item.Rarity * item.Value + "</b></color>";
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			}
		}
        
    }
}
