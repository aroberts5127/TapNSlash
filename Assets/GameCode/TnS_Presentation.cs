using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TnS_Presentation : MonoBehaviour {

    //[SerializeField]
    //private Button m_AtkButton;

    [SerializeField]
    private GameObject priv_HealthBar_go;
    [SerializeField]
    private Text priv_LevelText_go;
    [SerializeField]
    private Text priv_AccountName_Text;


    public GameObject HealthBarGO
    {
        get { return priv_HealthBar_go; }
    }
    public Text LevelText
    {
        get { return priv_LevelText_go; }
    }
	// Use this for initialization
	void Start () {
        //m_AtkButton.onClick.AddListener(delegate { TnS_Globals.Instance.Player.Attack(); }); 
        SpawnEnemy();
        if(!TnS_GlobalSettings.RELEASE_VERSION)
            priv_AccountName_Text.text = TnS_Globals.Instance.UE_AccountName;
        else
            priv_AccountName_Text.text = "USER";

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnEnemy()
    {
        int r = Random.Range(0, TnS_Globals.Instance.AvailableEnemies.Count);
        GameObject newEnemy = Instantiate(TnS_Globals.Instance.AvailableEnemies[r]);
        newEnemy.transform.position = TnS_Globals.Instance.EnemySpawnLocation.position;
        TnS_Globals.Instance.CurrentEnemy = newEnemy.GetComponent<TnS_Enemy>();
    }
}
