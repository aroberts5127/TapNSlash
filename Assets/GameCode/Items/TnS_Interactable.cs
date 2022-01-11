using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TnS_Interactable : MonoBehaviour {


    public virtual void Interact()
    {
        //Debug.Log("Interacting With " + this.name);
        Destroy(this.gameObject);
    }

    public void OnMouseDown()
    {
        Interact();
    }

    private IEnumerator AutoCollect()
    {
        yield return new WaitForSeconds(3.0f);
        Interact();
    }
}
