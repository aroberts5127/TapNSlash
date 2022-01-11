using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MagicSpells { FIREBALL, BLADESTORM, LIGHTNING};


public class TnS_Magic : MonoBehaviour{
    public static int NoOfSpells = 3;
    public List<int> MagicLevels;
    
    public void InitMagic() {
        //Debug.Log("NoOfSpells: " + NoOfSpells);
        //MagicLevels = new List<int>(NoOfSpells);
        //IF NEW GAME
        //if (!PlayerPrefs.HasKey(TnS_GlobalSettings.TNS_FISTTIMELOAD))
        //{
        for (int i = 0; i < NoOfSpells; i++)
        {
            //Debug.Log("HERE");
            int SpellLevel = 0;
            MagicLevels.Add(SpellLevel);
        }
        //Debug.Log("After Adding Spell Levels");
        //}
        //Not New Game (Save Data in PlayerPrefs)
        //else
        //{
        //    for (int i = 0; i < NoOfSpells; i++)
        //    {
        //        MagicLevels[i] = PlayerPrefs.GetInt(TnS_GlobalSettings.TNS_MAGIC[i]);
        //    }
        //}

        //DEBUG
        for (int j = 0; j < NoOfSpells; j++)
        {
            //Debug.Log(MagicLevels[j]);
        }
    }
}
