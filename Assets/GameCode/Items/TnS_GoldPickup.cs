using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TnS_GoldPickup : TnS_Interactable {

    public int goldValue = 1;

    public void Start()
    {
        StartCoroutine(AutoCollect());
    }


    public override void Interact()
    {
        base.Interact();
        //Debug.Log("INTERACTABLE - Collecting " + goldValue + " Gold");
        CollectGold(goldValue);
    }

    private void CollectGold(int value)
    {
        TnS_Globals.Instance.Inventory.CollectGold(value);
    }

    private IEnumerator AutoCollect()
    {
        yield return new WaitForSeconds(3.0f);
        Interact();
    }

}
