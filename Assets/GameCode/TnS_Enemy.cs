using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TnS_Enemy : MonoBehaviour, iDamagable {

    #region VARIABLES

    #region Private Variables

    [SerializeField]
    private string priv_Name;
    [SerializeField]
    private int priv_Health;
    [SerializeField]
    private int priv_Attack;
    [SerializeField]
    private int priv_Defense;

    [SerializeField]
    private int priv_ExperienceReward;

    [SerializeField]
    private TextMesh priv_NameTextObj;

    [SerializeField]
    private List<TnS_Interactable> priv_DroppableItems;
    [SerializeField]
    private List<float> priv_DroppableItemRates;
    [SerializeField]
    private int priv_GoldDropValueMin;
    [SerializeField]
    private int priv_GoldDropValueMax;


    private int priv_EnemyRevengeValue;
    private bool isDying = false;
    private bool isAttacking = false;
    #endregion

    #region Getter/Setter
    public string Name
    {
        get { return priv_Name; }
    }
    public int Health
    {
        get { return priv_Health; }
        set { priv_Health = value; }
    }
    public int Attack
    {
        get { return priv_Attack; }
    }
    public int Defense
    {
        get { return priv_Defense; }
    }
    public int ExpReward
    {
        get { return priv_ExperienceReward; }
    }

    public bool Dying
    {
        get { return isDying; }
    }
    #endregion

    #endregion

    // Use this for initialization
    void Start () {
        priv_NameTextObj.text = this.priv_Name;
	}
	
	// Update is called once per frame
	void Update () {
		if(priv_EnemyRevengeValue <= TnS_Globals.Instance.GlobalEnemyRevengeValue)
        {
            EnemyAttack();
        }
	}

    private void EnemyAttack()
    {
        isAttacking = true;
        //TODO - Enemy Attack
        //TODO - Initiate Player Dodge/Guard Chance
        //TODO - ENEMY CANNOT ALWAYS BE DEFENDED AGAINST!
        TnS_Globals.Instance.Player.UpdateHealthBar();
    }

    public void EnemyTakeDamage(int incDamage)
    {
        if(!isAttacking)
            this.GetComponent<Animator>().Play("damage");
        Debug.Log("TnS_Enemy - Health: " + this.Health);
        this.Health -= incDamage;
        Debug.Log("TnS_Enemy - Health After Damage: " + this.Health);
        if(this.Health <= 0)
        {
            Debug.Log("TnS_Enemy - I'm Dead");
            StartCoroutine(Die());
        }
    }

    //TODO - SOLID Implement - move this into a response to a PlayerAttack Action/Event
    public void TakeDamage(int incDamage)
    {
    }

    public IEnumerator Die()
    {
        isDying = true;
        this.GetComponent<Animator>().speed = 2.0f;
        this.GetComponent<Animator>().Play("die");
        //TODO - Graphics For Awarded EXP
        TnS_Globals.Instance.Player.AwardExp(this.ExpReward);
        DropItems();
        yield return new WaitForSeconds(1.9f);
        TnS_Globals.Instance.Presentation.SpawnEnemy();
        Destroy(this.gameObject);
    }

    public void DropItems()
    {
        Debug.Log("ENEMY - Dropping Items");
        for (int i = 0; i < priv_DroppableItems.Count; i++)
        {
            if (priv_DroppableItemRates[i] == 100)
            {
                GenerateItem(priv_DroppableItems[i]);
            }
            else
            {
                float r = Random.Range(0, 1);
                if (0 <= r && r <= priv_DroppableItemRates[i] / 100)
                {
                    GenerateItem(priv_DroppableItems[i]);
                }
            }
        }
    }

    private void GenerateItem(TnS_Interactable item)
    {
        GameObject newItem = Instantiate(item.gameObject, TnS_Globals.Instance.LootSpawn, false);
        if (item.GetComponent<TnS_GoldPickup>())
        {
            int goldDropValue = Random.Range(priv_GoldDropValueMin, priv_GoldDropValueMax);
            item.GetComponent<TnS_GoldPickup>().goldValue = goldDropValue;
        }
        newItem.transform.position = TnS_Globals.Instance.LootSpawn.position;
    }
}

public interface iDamagable
{
    void TakeDamage(int incDamage);
}
