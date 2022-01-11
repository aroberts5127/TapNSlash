using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TnS_EquipmentManager : MonoBehaviour {

    public TnS_Equipment[] currentEquipment;
    public Dictionary<EquipmentSlot, TnS_Equipment> currentEquipmentDictionary;

	// Use this for initialization
	void Start () {

        
        currentEquipmentDictionary = new Dictionary<EquipmentSlot, TnS_Equipment>();
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        for(int i = 0; i < numSlots; i++)
        {
            //ReadFromSave Current Equipment <stored in JSON>
            currentEquipmentDictionary.Add((EquipmentSlot)i, new TnS_Equipment());
        }
        foreach(KeyValuePair<EquipmentSlot, TnS_Equipment> kvp in currentEquipmentDictionary)
        {
            Debug.Log(kvp.Key + ", " + kvp.Value.WeaponName);
        }
        currentEquipment = new TnS_Equipment[numSlots];
	}
}
