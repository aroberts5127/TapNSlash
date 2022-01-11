using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Used to pick up consumable items like Potions, Food, or other Single Use (non-equip) items
/// </summary>
public class TnS_ItemPickup : TnS_Interactable{

    public TnS_Item item;

	// Use this for initialization

    //TODO - Make consumables stackable somehow. Will require a small overhaul of the Inventory
	public void Start ()
    {
        StartCoroutine(AutoCollect());
    }

    public override void Interact()
    {
        base.Interact();
        Debug.Log("INTERACTABLE - Picking Up " + item.name);
        CollectItem();
    }

    private void CollectItem()
    {
        //TODO - Add Item To Inventory
        TnS_Globals.Instance.Inventory.AddItem(item);
    }

    private IEnumerator AutoCollect()
    {
        yield return new WaitForSeconds(3.0f);
        Interact();
    }


}
