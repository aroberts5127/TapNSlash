using UnityEngine;


[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class TnS_ItemSO : ScriptableObject {

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefault = false;
    public GameObject itemMesh = null;
 
}
