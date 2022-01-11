using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class TnS_Equipment : TnS_Item {

    public EquipmentSlot equipSlot;

    [SerializeField]
    private Mesh priv_EquipmentModel;

    [SerializeField]
    private List<Material> priv_EquipmentMaterials;

    [SerializeField]
    private int priv_WeaponAttack;

    [SerializeField]
    private int priv_ArmorModifier;

    private TnS_WeaponType priv_WeaponType;

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
        get { return name; }
    }
    public int WeaponAttack
    {
        get { return priv_WeaponAttack; }
    }

    public int ArmorModifier
    {
        get { return priv_ArmorModifier; }
    }

    public override void Use()
    {
        base.Use();
        //TnS_Globals.Instance.Equipment.Equip(this);
    }
}

public enum EquipmentSlot
{
    Head, Chest, Legs, Feet, MainHand, OffHand
}
