using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumUtil;

public class TnS_EquipmentManager : MonoBehaviour {

    public TnS_Equipment[] currentEquipment;
    public Dictionary<EnumEquipmentSlot, TnS_Equipment> currentEquipmentDictionary;

	// Use this for initialization
	void Start () {

        
        currentEquipmentDictionary = new Dictionary<EnumEquipmentSlot, TnS_Equipment>();
        int numSlots = System.Enum.GetNames(typeof(EnumEquipmentSlot)).Length;
        for(int i = 0; i < numSlots; i++)
        {
            //ReadFromSave Current Equipment <stored in JSON>
            currentEquipmentDictionary.Add((EnumEquipmentSlot)i, new TnS_Equipment());
        }
        foreach(KeyValuePair<EnumEquipmentSlot, TnS_Equipment> kvp in currentEquipmentDictionary)
        {
            Debug.Log(kvp.Key + ", " + kvp.Value.WeaponName);
        }
        currentEquipment = new TnS_Equipment[numSlots];
	}
}
