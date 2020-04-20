using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoFloor : MonoBehaviour
{
    Renderer[] discoRenderers;
    Material[] discoMaterials = new Material[81];

    // Start is called before the first frame update
    void Start()
    {
        discoRenderers = GetComponentsInChildren<Renderer>();
        for(int i = 0; i < discoRenderers.Length; i++)
        {
            discoMaterials[i] = discoRenderers[i].material;
        }

        InvokeRepeating("RandomizeColor", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void RandomizeColor()
    {
        foreach(Material m in discoMaterials)
        {
            int[] r = {Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2)};

            if(r[0]+r[1]+r[2] == 0)
            {
                int rNew = Random.Range(0, 3);
                r[rNew] = 1;
            }
            else if(r[0]+r[1]+r[2] == 3)
            {
                int rNew = Random.Range(0, 3);
                r[rNew] = 0;
            }
            m.color = new Color(r[0], r[1], r[2]);
        }
    }
}
