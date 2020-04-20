using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyInfluence : MonoBehaviour
{
    private int _partygoerLayer;
    public List<PartygoerScript> partygoers;

    void Start()
    {
        _partygoerLayer = LayerMask.NameToLayer("Partygoer");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == _partygoerLayer)
        {
            partygoers.Add(other.GetComponent<PartygoerScript>());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == _partygoerLayer)
        {
            partygoers.Remove(other.GetComponent<PartygoerScript>());
        }
    }

    public void Influence()
    {
        foreach(PartygoerScript ps in partygoers)
        {
            ps.IncreasePartyMood(transform.position, 1);
        }
    }
}
