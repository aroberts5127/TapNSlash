using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TnS_EquipmentManager : MonoBehaviour {

    public TnS_Equipment[] currentEquipment;

	// Use this for initialization
	void Start () {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new TnS_Equipment[numSlots];
	}
	
	public void Equip(TnS_Equipment newItem)
    {
        int SlotInDex = (int)newItem.equipSlot;

        currentEquipment[SlotInDex] = newItem;
    }
}
