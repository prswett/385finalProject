using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour {

	public int id;
	public GameObject item;
	public Equipment equipInv;

	// Use this for initialization
	void Start () {
		equipInv = GameObject.Find ("Equipment").GetComponent<Equipment> ();
	}
	

}
