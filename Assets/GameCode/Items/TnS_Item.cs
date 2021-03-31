using UnityEngine;


[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class TnS_Item : ScriptableObject {

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefault = false;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }

}
