using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartygoerScript : MonoBehaviour
{
    [SerializeField]
    private int _partymood = 0;
    [SerializeField]
    private int maxPartyMood = 3;
    [SerializeField]
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
        if(_partymood < 0)
        {
            _partymood = 0;
        }
    }

    public void ConvertPartygoer()
    {
        GameManager.Instance.AddScore(100);
    }
}
