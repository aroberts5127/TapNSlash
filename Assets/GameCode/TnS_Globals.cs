using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TnS_Globals : MonoBehaviour {

    #region VARIABLES
    private static TnS_Globals priv_Global;
    private TnS_PlayerCharacter priv_Player;
    private TnS_Presentation priv_Presentation;
    private TnS_Inventory priv_Inventory;
    private TnS_EquipmentManager priv_Equpment;

    public static event Action EnemyDeath;

#if UNITY_EDITOR //TODO - Move to some kind of test load script
    public string UE_AccountName = "Andrew";
#endif

    [SerializeField]
    private TnS_Enemy priv_CurrentEnemy;

    [SerializeField]
    private List<GameObject> priv_AvailableEnemiesList;

    [SerializeField]
    private Transform priv_EnemySpawnLocation;

    [SerializeField]
    private List<GameObject> priv_WeaponModels;

    [SerializeField]
    private Transform priv_LootSpawnLocation;

    //TODO: This is gonna be brute forced. Move to Level XML Table.
    public int BaseExpToNextLevel = 100;

    public float snsAttackTime = 1.5f;
    public float gsAttackTime = 1.3f;


    private int priv_GlobalEnemyRevengeValue;

    //TODO - Move Inventory Management to Presentation
    public Animator CameraAnimator;
    public Animator InventoryAnimator;
    private bool invOpen = false;
    #endregion

    #region GET/SET
    public static TnS_Globals Instance
    {
        get { return priv_Global; }
    }
    public TnS_PlayerCharacter Player
    {
        get { return priv_Player; }
        set { priv_Player = value; }
    }
    public TnS_Presentation Presentation
    {
        get { return priv_Presentation; }
    }
    public TnS_Inventory Inventory
    {
        get { return priv_Inventory; }
    }
    public TnS_EquipmentManager Equipment
    {
        get { return priv_Equpment; }
    }

    public TnS_Enemy CurrentEnemy
    {
        get { return priv_CurrentEnemy; }
        set { priv_CurrentEnemy = value; }
    }

    public List<GameObject> AvailableEnemies
    {
        get { return priv_AvailableEnemiesList; }
    }

    public Transform EnemySpawnLocation
    {
        get { return priv_EnemySpawnLocation; }
    }

    public int GlobalEnemyRevengeValue
    {
        get { return priv_GlobalEnemyRevengeValue; }
        set { priv_GlobalEnemyRevengeValue = value; }
    }

    public List<GameObject> WeaponList
    {
        get { return priv_WeaponModels; }
    }

    public Transform LootSpawn
    {
        get { return priv_LootSpawnLocation; }
    }
    #endregion

    #region UNITY FUNCTIONS
    private void Awake()
    {
        if(priv_Global == null)
            priv_Global = this;
        else
            Destroy(this);

        priv_Presentation = this.GetComponent<TnS_Presentation>();
        priv_Inventory = this.GetComponent<TnS_Inventory>();
        priv_Equpment = this.GetComponent<TnS_EquipmentManager>();
    }

    // Use this for initialization
    void Start () {
        priv_GlobalEnemyRevengeValue = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            InvAnimTest();
        }

        
	}
    #endregion

    #region PUBLIC FUNCTIONS
    #endregion

    #region PRIVATE FUNTIONS

    private void InvAnimTest()
    {
        if (invOpen == false)
        {
            CameraAnimator.Play("Inventory Open");
            InventoryAnimator.Play("Open");
            invOpen = true;
        }
        else
        {
            CameraAnimator.Play("Inventory Close");
            InventoryAnimator.Play("Close");
            invOpen = false;
        }
    }
    #endregion
}
