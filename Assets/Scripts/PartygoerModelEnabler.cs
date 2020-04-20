using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartygoerModelEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int r = Random.Range(0, 4);
        for(int i = 0; i < transform.childCount; i++)
        {
            if(i == r)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                GetComponent<PartygoerScript>().animator = transform.GetChild(i).GetComponent<Animator>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
