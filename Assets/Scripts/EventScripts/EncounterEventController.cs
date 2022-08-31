using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EncounterEventController : MonoBehaviour
{
    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
    }


    public static EncounterEventController Instance;

    public event Action<int> playerAttackEvent;
    public event Action<int> enemyAttackEvent;
    public event Action enemyDeathEvent;

    public void OnPlayerAttack(int dmg)
    {
        playerAttackEvent?.Invoke(dmg);
    }

    public void OnEnemyAttack(int dmg)
    {
        enemyAttackEvent?.Invoke(dmg);
    }

    public void OnEnemyDead()
    {
        Debug.Log("Enemy Is Dead");
        enemyDeathEvent?.Invoke();
    }
}
