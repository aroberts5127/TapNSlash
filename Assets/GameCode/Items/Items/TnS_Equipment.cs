using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumUtil;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class TnS_Equipment : MonoBehaviour {

    public EquipmentSlot equipSlot;
    public EquipmentVO itemData;

    [SerializeField]
    private Mesh priv_EquipmentModel;

    [SerializeField]
    private List<Material> priv_EquipmentMaterials;

    [SerializeField]
    private int priv_WeaponAttack;

    [SerializeField]
    private int priv_ArmorModifier;

    private TnS_WeaponType priv_WeaponType;

    public TnS_Equipment(object data)
    {
        itemData = data as EquipmentVO;
    }

    public Mesh WeaponModel
    {
        get { return priv_EquipmentModel; }
    }

    public List<Material> EquipmentMaterials
    {
        get { return priv_EquipmentMaterials; }
    }

    public string WeaponName
    {
        get { return itemData.name; }
    }
    public int WeaponAttack
    {
        get { return priv_WeaponAttack; }
    }

    public int ArmorModifier
    {
        get { return priv_ArmorModifier; }
    }

    public TnS_Equipment()
    {
        itemData = null;
    }

    public TnS_Equipment(TnS_EquipmentSO data)
    {
        itemData = null;
    }

    public void Use()
    {
        //base.Use();
        //TnS_Globals.Instance.Equipment.Equip(this);
    }
}


