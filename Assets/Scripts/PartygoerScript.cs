using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartygoerScript : MonoBehaviour
{
    private int _partymood = 0;
    private int maxPartyMood = 3;
    bool converted = false;

    public int Partymood{
        get { return _partymood; }
    }

    public void IncreasePartyMood(int increment){
        if(!converted){
            if(_partymood < maxPartyMood-1)
            {
                _partymood += increment;
            }else{
                ConvertPartygoer();
                converted = true;
            }
        }
    }

    public void ConvertPartygoer()
    {
        GameManager.Instance.AddScore(100);
    }
}
