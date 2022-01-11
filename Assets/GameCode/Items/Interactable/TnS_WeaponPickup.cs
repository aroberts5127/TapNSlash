using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TnS_WeaponPickup : TnS_Interactable {

    public EquipmentVO weapon;

	// Use this for initialization
	void Start () {
		
	}
	
    public override void Interact()
    {
        base.Interact();
        CollectWeapon(weapon);
    }

    private void CollectWeapon(EquipmentVO weapon)
    {
        Debug.Log("Weapon Name: " + weapon.name);
        //TODO - Create a Weapon Inventory List to house all the weapons/equipment the Player collects
        //TODO - Autoassign first collected weapon over default Fist/Stick/Sword
    }
}
