using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

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
        ActivateGooglePlayServices();
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

    private void ActivateGooglePlayServices()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        // enables saving game progress.
        .EnableSavedGames()
        // requests the email address of the player be available.
        // Will bring up a prompt for consent.
        .RequestEmail()
        // requests a server auth code be generated so it can be passed to an
        //  associated back end server application and exchanged for an OAuth token.
        .RequestServerAuthCode(false)
        // requests an ID token be generated.  This OAuth token can be used to
        //  identify the player to other services such as Firebase.
        .RequestIdToken()
        .Build();

        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
    }

    
}
