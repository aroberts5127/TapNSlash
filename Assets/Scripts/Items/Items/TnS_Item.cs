using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TnS_Item
{

    public ItemVO itemData;

    public TnS_Item()
    {
        itemData = null;
    }

    public TnS_Item(ItemVO data)
    {
        itemData = data;
    }

    public virtual void Use()
    {
        Debug.Log("Using " + this);
    }

}
