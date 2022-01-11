using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAccountInformation : MonoBehaviour
{
    public static PlayerAccountInformation Instance;

    private int m_enemiesKilledLifetime;

    public int EnemiesKilledLifetime
    {
        get { return m_enemiesKilledLifetime; }
        set { m_enemiesKilledLifetime = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerAccountInformation.Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            PlayerAccountInformation.Instance = this;
        }
        if (PlayerPrefs.HasKey(TnS_GlobalSettings.TNS_ENEMIESKILLEDLIFETIME))
        {
            EnemiesKilledLifetime = PlayerPrefs.GetInt(TnS_GlobalSettings.TNS_ENEMIESKILLEDLIFETIME);
        }
        else
        {
            EnemiesKilledLifetime = 0;
            PlayerPrefs.SetInt(TnS_GlobalSettings.TNS_ENEMIESKILLEDLIFETIME, EnemiesKilledLifetime);
        }
        EncounterEventController.Instance.enemyDeathEvent += SaveEnemiesKilledValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveEnemiesKilledValue()
    {
        EnemiesKilledLifetime++;
        Debug.Log("ACCOUNT - Enemies Killed: " + EnemiesKilledLifetime);
        PlayerPrefs.SetInt(TnS_GlobalSettings.TNS_ENEMIESKILLEDLIFETIME, EnemiesKilledLifetime);
    }
}
