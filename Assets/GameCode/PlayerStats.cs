using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private int priv_MaxHealth;
    [SerializeField]
    private int priv_Attack;
    

    private int priv_CurrentHealth;
    private int priv_Level;
    private int priv_CurrentExperience;
    private int priv_ExpToNextLevel;

    


    public int PC_MaxHealth
    {
        get { return priv_MaxHealth; }
        set { priv_MaxHealth = value; }
    }

    public int PC_CurrentHealth
    {
        get { return priv_CurrentHealth; }
        set { priv_CurrentHealth = value; }
    }

    public int PC_Attack
    {
        get { return priv_Attack; }
        set { priv_Attack = value; }
    }
    public int PC_Level
    {
        get { return priv_Level; }
        set { priv_Level = value; }
    }
    public int CurrentExperience
    {
        get { return priv_CurrentExperience; }
        set { priv_CurrentExperience = value; }
    }
    public int ExpToNextLevel
    {
        get { return priv_ExpToNextLevel; }
        set { priv_ExpToNextLevel = value; }
    }

    public void AwardExp(int expAdded)
    {
        CurrentExperience += expAdded;
        if (CurrentExperience >= ExpToNextLevel)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {

        PC_Level++;
        Debug.Log("Tns_PlayerCharacter - Level Up: " + PC_Level);
        if (CurrentExperience > ExpToNextLevel)
        {
            CurrentExperience = ExpToNextLevel - CurrentExperience;
        }
        else
        {
            CurrentExperience = 0;
        }
        ExpToNextLevel = (int)(ExpToNextLevel * 1.2f);
        //Debug.Log("Tns_PlayerCharacter - CurExp: " + priv_playerStats.CurrentExperience);
        //Debug.Log("TnS_PlayerCharacter - ExpToNext: " + priv_playerStats.ExpToNextLevel);
        TnS_Globals.Instance.Player.UpdateLevelDisplay();
    }
}
