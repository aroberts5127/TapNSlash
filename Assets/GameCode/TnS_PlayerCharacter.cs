using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum TnS_WeaponType { NONE, SWaSH, GS}

public class TnS_PlayerCharacter : MonoBehaviour, iDamagable
{

    #region Variables

    private PlayerStats priv_playerStats;

    #region Private Attributes
    [SerializeField]
    private TnS_WeaponType priv_WeaponType;

    private TnS_Equipment priv_CurrentWeapon;

    [SerializeField]
    private Transform priv_BindToWeapon;

    private float priv_AttackAnimTime;

    public TnS_WeaponType WeaponType
    {
        get { return priv_WeaponType; }
        set { priv_WeaponType = value; }
    }

    

    public TnS_Equipment CurrentWeapon
    {
        get { return priv_CurrentWeapon; }
        set { priv_CurrentWeapon = value; }
    }

    public Transform BindToWeapon
    {
        get { return priv_BindToWeapon; }
    }
    #endregion

    public bool isAttacking;

    #endregion

    void Awake()
    {
        
    }

    void Start()
    {
        //Debug.Log(this.gameObject.name);
        priv_playerStats = GetComponent<PlayerStats>();
        isAttacking = false;
        EncounterEventController.Instance.enemyAttackEvent += TakeDamage;
        if (TnS_Globals.Instance.Player == null)
        {
            TnS_Globals.Instance.Player = this;
        }
        else
        {
            Debug.Log("This Player Shouldn't Exist");
            Destroy(this.gameObject);
        }
        //if (PlayerPrefs.HasKey(TnS_GlobalSettings.TNS_FISTTIMELOAD))
        //{
        Debug.Log("FirstLoad");
            SetWeapon(TnS_WeaponType.SWaSH);
        priv_playerStats.PC_Level = 1;
        priv_playerStats.PC_CurrentHealth = priv_playerStats.PC_MaxHealth;
        priv_playerStats.ExpToNextLevel = TnS_Globals.Instance.BaseExpToNextLevel;
        priv_playerStats.PC_CurrentHealth = priv_playerStats.PC_MaxHealth;
        UpdateHealthBar();
        UpdateLevelDisplay();
        this.GetComponent<TnS_Magic>().InitMagic();
        //}
        //else
        //{
        //    Debug.Log("Not First Load");
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }

    //void OnMouseDown()
    //{
    //    StartCoroutine(Attack());
    //}

    #region PUBLIC FUNCTIONS
    /// <summary>
    /// Searches Through The Global For The Current Enemy And Deals Damage
    /// Will Also Begin The Animation Sequence
    /// </summary>
    /// 
    private void AttackFunction()
    {
        StartCoroutine(Attack());
    }
    public IEnumerator Attack()
    {
        
        isAttacking = true;
        //Debug.Log("TnS_PlayerCharacter - " + isAttacking);
        this.transform.GetComponentInChildren<Animator>().Play("Attack");
        //Debug.Log("TnS_PlayerCharacter - OH YEAH! YOU LIKE THAT!?");
        yield return new WaitForSeconds(priv_AttackAnimTime /2);
        //TODO - Deal Damage to Enemy in Scene
        //TnS_Globals.Instance.CurrentEnemy.EnemyTakeDamage(priv_playerStats.PC_Attack);
        EncounterEventController.Instance.OnPlayerAttack(priv_playerStats.PC_Attack);
        yield return new WaitForSeconds(priv_AttackAnimTime / 2);
        //Debug.Log("TnS_PlayerCharacter - May Attack Again");
        isAttacking = false;
        //Debug.Log("TnS_PlayerCharacter - " + isAttacking);
    }

    public void SetWeapon(TnS_WeaponType weapon)
    {
        switch (weapon)
        {
            case (TnS_WeaponType.SWaSH):
                priv_WeaponType = TnS_WeaponType.SWaSH;
                priv_AttackAnimTime = TnS_Globals.Instance.snsAttackTime;
                return;
            case (TnS_WeaponType.GS):
                priv_WeaponType = TnS_WeaponType.GS;
                priv_AttackAnimTime = TnS_Globals.Instance.gsAttackTime;
                return;
            default:
                return;
        }
    }

    //Should be listening for Enemy Death
    public void AwardExp(int incExp)
    {
        priv_playerStats.AwardExp(incExp);
    }

   

    public void UpdateHealthBar()
    {
        TnS_Globals.Instance.Presentation.HealthBarGO.transform.Find("BarFill").GetComponent<Image>().fillAmount = (priv_playerStats.PC_CurrentHealth / priv_playerStats.PC_MaxHealth);
        TnS_Globals.Instance.Presentation.HealthBarGO.transform.Find("BarValue").GetComponent<Text>().text = (priv_playerStats.PC_CurrentHealth + "/" + priv_playerStats.PC_MaxHealth);
    }
    public void UpdateLevelDisplay()
    {
        TnS_Globals.Instance.Presentation.LevelText.text = priv_playerStats.PC_Level.ToString();
    }
    //TODO - SOLID: make this react to Enemy Attack Action/Event
    public void TakeDamage(int incDamage)
    {

    }
    #endregion

    #region PRIVATE FUNTIONS



    /// <summary>
    /// After Spawning the Button this will Initialize the mitigation of damage for the enemy attack
    /// Also begins the option to Parry should the game lean towards that
    /// </summary>
    private void Defend()
    {
        //TODO - When Enemy.isAttacking == True Genereate Dialogues/Reactions to Dodge/Block/etc
        //TODO - Balance the timing/No. Of Times It Can Occur/Efficiency/Potential For Enemy To Do Damage
        //TODO - ENEMY CANNOT ALWAYS BE DEFENDED AGAINST!
        Debug.Log("TnS_PlayerCharacter - CAN'T TOUCH ME!!!");
    }

    #endregion


}
