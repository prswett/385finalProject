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
		if (item.type == "Helmet") {
			if (eInv.slots [0].GetComponent<EquipmentSlot> ().item != null) {
				ItemStats temp = eInv.slots [0].GetComponent<EquipmentSlot> ().item.GetComponent<ItemStats> ();

				if (item.str < temp.str) {
					strdiff = "" + (item.str - temp.str);
				} else {
					strdiff = "+" + (item.str - temp.str);
				}
				if (item.dex < temp.dex) {
					dexdiff = "" + (item.dex - temp.dex);
				} else {
					dexdiff = "+" + (item.dex - temp.dex);
				}
				if (item.wis < temp.wis) {
					wisdiff = "" + (item.wis - temp.wis);
				} else {
					wisdiff = "+" + (item.wis - temp.wis);
				}
				if (item.luk < temp.luk) {
					lukdiff = "" + (item.luk - temp.luk);
				} else {
					lukdiff = "+" + (item.luk - temp.luk);
				}
				if (item.atk < temp.atk) {
					atkdiff = "" + (item.atk - temp.atk);
				} else {
					atkdiff = "+" + (item.atk - temp.atk);
				}
				if (item.def < temp.def) {
					defdiff = "" + (item.def - temp.def);
				} else {
					defdiff = "+" + (item.def - temp.def);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + 
					"\nStr: " + item.str + " (" + strdiff + ")" + 
					"\nDex: " + item.dex + " (" + dexdiff + ")" + 
					"\nWis: " + item.wis + " (" + wisdiff + ")" + 
					"\nLuk: " + item.luk + " (" + lukdiff + ")" + 
					"\nAtk: " + item.atk + " (" + atkdiff + ")" + 
					"\nDef: " + item.def + " (" + defdiff + ")" + 
					"\nValue: " + item.Value;
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			} else {
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + "\nStr: " + item.str + "\nDex: " + item.dex
					+ "\nWis: " + item.wis + "\nLuk: " + item.luk + "\nAtk: " + item.atk + "\nDef: " + item.def + "\nValue: " + item.Value;
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			}
		} else if (item.type == "Armor") {
			if (eInv.slots [1].GetComponent<EquipmentSlot> ().item != null) {
				ItemStats temp = eInv.slots [1].GetComponent<EquipmentSlot> ().item.GetComponent<ItemStats> ();
				if (item.str < temp.str) {
					strdiff = "" + (item.str - temp.str);
				} else {
					strdiff = "+" + (item.str - temp.str);
				}
				if (item.dex < temp.dex) {
					dexdiff = "" + (item.dex - temp.dex);
				} else {
					dexdiff = "+" + (item.dex - temp.dex);
				}
				if (item.wis < temp.wis) {
					wisdiff = "" + (item.wis - temp.wis);
				} else {
					wisdiff = "+" + (item.wis - temp.wis);
				}
				if (item.luk < temp.luk) {
					lukdiff = "" + (item.luk - temp.luk);
				} else {
					lukdiff = "+" + (item.luk - temp.luk);
				}
				if (item.atk < temp.atk) {
					atkdiff = "" + (item.atk - temp.atk);
				} else {
					atkdiff = "+" + (item.atk - temp.atk);
				}
				if (item.def < temp.def) {
					defdiff = "" + (item.def - temp.def);
				} else {
					defdiff = "+" + (item.def - temp.def);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + 
					"\nStr: " + item.str + " (" + strdiff + ")" + 
					"\nDex: " + item.dex + " (" + dexdiff + ")" + 
					"\nWis: " + item.wis + " (" + wisdiff + ")" + 
					"\nLuk: " + item.luk + " (" + lukdiff + ")" + 
					"\nAtk: " + item.atk + " (" + atkdiff + ")" + 
					"\nDef: " + item.def + " (" + defdiff + ")" + 
					"\nValue: " + item.Value;
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			} else {
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + "\nStr: " + item.str + "\nDex: " + item.dex
					+ "\nWis: " + item.wis + "\nLuk: " + item.luk + "\nAtk: " + item.atk + "\nDef: " + item.def + "\nValue: " + item.Value;
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			}
		} else if (item.type == "Sword") {
			if (eInv.slots [2].GetComponent<EquipmentSlot> ().item != null) {
				ItemStats temp = eInv.slots [2].GetComponent<EquipmentSlot> ().item.GetComponent<ItemStats> ();
				if (item.str < temp.str) {
					strdiff = "" + (item.str - temp.str);
				} else {
					strdiff = "+" + (item.str - temp.str);
				}
				if (item.dex < temp.dex) {
					dexdiff = "" + (item.dex - temp.dex);
				} else {
					dexdiff = "+" + (item.dex - temp.dex);
				}
				if (item.wis < temp.wis) {
					wisdiff = "" + (item.wis - temp.wis);
				} else {
					wisdiff = "+" + (item.wis - temp.wis);
				}
				if (item.luk < temp.luk) {
					lukdiff = "" + (item.luk - temp.luk);
				} else {
					lukdiff = "+" + (item.luk - temp.luk);
				}
				if (item.atk < temp.atk) {
					atkdiff = "" + (item.atk - temp.atk);
				} else {
					atkdiff = "+" + (item.atk - temp.atk);
				}
				if (item.def < temp.def) {
					defdiff = "" + (item.def - temp.def);
				} else {
					defdiff = "+" + (item.def - temp.def);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + 
					"\nStr: " + item.str + " (" + strdiff + ")" + 
					"\nDex: " + item.dex + " (" + dexdiff + ")" + 
					"\nWis: " + item.wis + " (" + wisdiff + ")" + 
					"\nLuk: " + item.luk + " (" + lukdiff + ")" + 
					"\nAtk: " + item.atk + " (" + atkdiff + ")" + 
					"\nDef: " + item.def + " (" + defdiff + ")" + 
					"\nValue: " + item.Value;
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			} else {
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + "\nStr: " + item.str + "\nDex: " + item.dex
					+ "\nWis: " + item.wis + "\nLuk: " + item.luk + "\nAtk: " + item.atk + "\nDef: " + item.def + "\nValue: " + item.Value;
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			}
		} else if (item.type == "Spear") {
			if (eInv.slots [3].GetComponent<EquipmentSlot> ().item != null) {
				ItemStats temp = eInv.slots [3].GetComponent<EquipmentSlot> ().item.GetComponent<ItemStats> ();
				if (item.str < temp.str) {
					strdiff = "" + (item.str - temp.str);
				} else {
					strdiff = "+" + (item.str - temp.str);
				}
				if (item.dex < temp.dex) {
					dexdiff = "" + (item.dex - temp.dex);
				} else {
					dexdiff = "+" + (item.dex - temp.dex);
				}
				if (item.wis < temp.wis) {
					wisdiff = "" + (item.wis - temp.wis);
				} else {
					wisdiff = "+" + (item.wis - temp.wis);
				}
				if (item.luk < temp.luk) {
					lukdiff = "" + (item.luk - temp.luk);
				} else {
					lukdiff = "+" + (item.luk - temp.luk);
				}
				if (item.atk < temp.atk) {
					atkdiff = "" + (item.atk - temp.atk);
				} else {
					atkdiff = "+" + (item.atk - temp.atk);
				}
				if (item.def < temp.def) {
					defdiff = "" + (item.def - temp.def);
				} else {
					defdiff = "+" + (item.def - temp.def);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + 
					"\nStr: " + item.str + " (" + strdiff + ")" + 
					"\nDex: " + item.dex + " (" + dexdiff + ")" + 
					"\nWis: " + item.wis + " (" + wisdiff + ")" + 
					"\nLuk: " + item.luk + " (" + lukdiff + ")" + 
					"\nAtk: " + item.atk + " (" + atkdiff + ")" + 
					"\nDef: " + item.def + " (" + defdiff + ")" + 
					"\nValue: " + item.Value;
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			} else {
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + "\nStr: " + item.str + "\nDex: " + item.dex
					+ "\nWis: " + item.wis + "\nLuk: " + item.luk + "\nAtk: " + item.atk + "\nDef: " + item.def + "\nValue: " + item.Value;
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			}
		} else if (item.type == "Axe") {
			if (eInv.slots [4].GetComponent<EquipmentSlot> ().item != null) {
				ItemStats temp = eInv.slots [4].GetComponent<EquipmentSlot> ().item.GetComponent<ItemStats> ();
				if (item.str < temp.str) {
					strdiff = "" + (item.str - temp.str);
				} else {
					strdiff = "+" + (item.str - temp.str);
				}
				if (item.dex < temp.dex) {
					dexdiff = "" + (item.dex - temp.dex);
				} else {
					dexdiff = "+" + (item.dex - temp.dex);
				}
				if (item.wis < temp.wis) {
					wisdiff = "" + (item.wis - temp.wis);
				} else {
					wisdiff = "+" + (item.wis - temp.wis);
				}
				if (item.luk < temp.luk) {
					lukdiff = "" + (item.luk - temp.luk);
				} else {
					lukdiff = "+" + (item.luk - temp.luk);
				}
				if (item.atk < temp.atk) {
					atkdiff = "" + (item.atk - temp.atk);
				} else {
					atkdiff = "+" + (item.atk - temp.atk);
				}
				if (item.def < temp.def) {
					defdiff = "" + (item.def - temp.def);
				} else {
					defdiff = "+" + (item.def - temp.def);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + 
					"\nStr: " + item.str + " (" + strdiff + ")" + 
					"\nDex: " + item.dex + " (" + dexdiff + ")" + 
					"\nWis: " + item.wis + " (" + wisdiff + ")" + 
					"\nLuk: " + item.luk + " (" + lukdiff + ")" + 
					"\nAtk: " + item.atk + " (" + atkdiff + ")" + 
					"\nDef: " + item.def + " (" + defdiff + ")" + 
					"\nValue: " + item.Value;
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			} else {
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + "\nStr: " + item.str + "\nDex: " + item.dex
					+ "\nWis: " + item.wis + "\nLuk: " + item.luk + "\nAtk: " + item.atk + "\nDef: " + item.def + "\nValue: " + item.Value;
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			}
		} else {
			if (eInv.slots [5].GetComponent<EquipmentSlot> ().item != null) {
				ItemStats temp = eInv.slots [5].GetComponent<EquipmentSlot> ().item.GetComponent<ItemStats> ();
				if (item.str < temp.str) {
					strdiff = "" + (item.str - temp.str);
				} else {
					strdiff = "+" + (item.str - temp.str);
				}
				if (item.dex < temp.dex) {
					dexdiff = "" + (item.dex - temp.dex);
				} else {
					dexdiff = "+" + (item.dex - temp.dex);
				}
				if (item.wis < temp.wis) {
					wisdiff = "" + (item.wis - temp.wis);
				} else {
					wisdiff = "+" + (item.wis - temp.wis);
				}
				if (item.luk < temp.luk) {
					lukdiff = "" + (item.luk - temp.luk);
				} else {
					lukdiff = "+" + (item.luk - temp.luk);
				}
				if (item.atk < temp.atk) {
					atkdiff = "" + (item.atk - temp.atk);
				} else {
					atkdiff = "+" + (item.atk - temp.atk);
				}
				if (item.def < temp.def) {
					defdiff = "" + (item.def - temp.def);
				} else {
					defdiff = "+" + (item.def - temp.def);
				}
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + 
					"\nStr: " + item.str + " (" + strdiff + ")" + 
					"\nDex: " + item.dex + " (" + dexdiff + ")" + 
					"\nWis: " + item.wis + " (" + wisdiff + ")" + 
					"\nLuk: " + item.luk + " (" + lukdiff + ")" + 
					"\nAtk: " + item.atk + " (" + atkdiff + ")" + 
					"\nDef: " + item.def + " (" + defdiff + ")" + 
					"\nValue: " + item.Value;
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			} else {
				data = "<color=#0473f0><b>" + item.Title + "</b></color>\n" + item.Description + "\nStr: " + item.str + "\nDex: " + item.dex
					+ "\nWis: " + item.wis + "\nLuk: " + item.luk + "\nAtk: " + item.atk + "\nDef: " + item.def + "\nValue: " + item.Value;
				tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
			}
		}
        
    }
}
