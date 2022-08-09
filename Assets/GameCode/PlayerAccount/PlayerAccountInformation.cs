using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAccountInformation : SingletonClass<PlayerAccountInformation>, IInitializationClass
{
    private int m_enemiesKilledLifetime;
    private bool _initialized;

    public int EnemiesKilledLifetime
    {
        get { return m_enemiesKilledLifetime; }
        set { m_enemiesKilledLifetime = value; }
    }

    public bool AllInitialized => _initialized;

    public void SaveEnemiesKilledValue()
    {
        EnemiesKilledLifetime++;
        Debug.Log("ACCOUNT - Enemies Killed: " + EnemiesKilledLifetime);
        PlayerPrefs.SetInt(TnS_GlobalSettings.TNS_ENEMIESKILLEDLIFETIME, EnemiesKilledLifetime);
    }

    public void InitializeClass()
    {
        Debug.Log("PlayerAccountInformation");
        if (PlayerPrefs.HasKey(TnS_GlobalSettings.TNS_ENEMIESKILLEDLIFETIME))
        {
            EnemiesKilledLifetime = PlayerPrefs.GetInt(TnS_GlobalSettings.TNS_ENEMIESKILLEDLIFETIME);
        }
        else
        {
            EnemiesKilledLifetime = 0;
            PlayerPrefs.SetInt(TnS_GlobalSettings.TNS_ENEMIESKILLEDLIFETIME, EnemiesKilledLifetime);
        }
        _initialized = true;
    }

    public void WaitingOnOtherInit()
    {
        
    }
}
