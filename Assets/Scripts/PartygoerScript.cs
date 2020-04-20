using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartygoerScript : MonoBehaviour
{
    private int _partymood = 0;
    private int maxPartyMood = 3;

    public int Partymood{
        get { return _partymood; }
    }

    public void IncreasePartyMood(int increment){
        if(_partymood == maxPartyMood)
        {
            ConvertPartygoer();
        }else{
            _partymood += increment;
        }
    }

    public void ConvertPartygoer()
    {
        GameManager.Instance.AddScore(100);
    }
}
