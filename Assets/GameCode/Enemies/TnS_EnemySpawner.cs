using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TnS_EnemySpawner : MonoBehaviour
{
    public static TnS_EnemySpawner Instance;

    Dictionary<int, List<TnS_Enemy>> enemiesPerLevelList; //TODO - Get This in Place
    // Start is called before the first frame update
    void Start()
    {
        EncounterEventController.Instance.enemyDeathEvent += SpawnEnemy;
    }

    public void SpawnEnemy()
    {
        int r = Random.Range(0, TnS_Globals.Instance.AvailableEnemies.Count);
        GameObject newEnemy = Instantiate(TnS_Globals.Instance.AvailableEnemies[r]);
        newEnemy.transform.position = TnS_Globals.Instance.EnemySpawnLocation.position;
        newEnemy.transform.parent = TnS_Globals.Instance.EnemySpawnParent;
        TnS_Globals.Instance.CurrentEnemy = newEnemy.GetComponent<TnS_Enemy>();
    }
}
