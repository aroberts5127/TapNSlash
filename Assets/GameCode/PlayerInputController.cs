using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            if (!TnS_Globals.Instance.Player.isAttacking && !TnS_Globals.Instance.CurrentEnemy.Dying)
            {
                //Debug.Log("TnS_PlayerCharacter - Update - Run Attack Funtion In Editor");
                StartCoroutine(TnS_Globals.Instance.Player.Attack());
            }
        }
#else
        if(Input.touchCount > 0)
        {
           if (!TnS_Globals.Instance.Player.isAttacking && !TnS_Globals.Instance.CurrentEnemy.Dying)
            {
                //Debug.Log("TnS_PlayerCharacter - Update - Run Attack Funtion On Device");
                StartCoroutine(TnS_Globals.Instance.Player.Attack());
            }
        }
#endif
    }
}
