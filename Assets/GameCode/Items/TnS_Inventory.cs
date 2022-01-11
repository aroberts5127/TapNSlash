using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TnS_Inventory : MonoBehaviour {


    public List<TnS_Item> itemList = new List<TnS_Item>();
    public List<TnS_Equipment> weaponList = new List<TnS_Equipment>();
    public int Gold = 0;

    public void AddItem(TnS_Item item)
    {
        if (!item.isDefault)
        {
            int v = itemList.Count;
            itemList.Add(item);
            if(v != itemList.Count)
            {
                Debug.Log("Successfully Added Item");
            }
        }
    }

    public void AddWeapon(TnS_Equipment weapon)
    {
        if (!weapon.isDefault)
        {
            int v = weaponList.Count;
            itemList.Add(weapon);
            if (v != weaponList.Count)
            {
                Debug.Log("Successfully Added Item");
            }
            //if(v == 0)
            //{
            //    //TODO - Equip Weapon because the default stick is equipped
            //}
        }
    }

    public void RemoveItem(TnS_Item item)
    {
        int v = itemList.Count;
        itemList.Remove(item);
        if (v != itemList.Count)
        {
            Debug.Log("Successfully Removed Item");
        }
    }

    public void CollectGold(int g)
    {
        Gold += g;
    }


    /// <summary>
    /// Removes gold from inventory.
    /// Shops will check to see if you have enough gold to spend and won't allow you to purchase items that would take your gold below 0
    /// Check for g >= Gold is for potential Stolen, Misplaced, or otherwise lost (not spent) gold.
    /// </summary>
    /// <param name="g"></param>
    public void ReduceGold(int g)
    {
        if (g >= Gold)
            Gold = 0;
        else
        {
            Gold -= g;
        }
    }

}
