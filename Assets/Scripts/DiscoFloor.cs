using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoFloor : MonoBehaviour
{
    Renderer[] discoRenderers;
    [SerializeField]
    Material[] discoMaterials = new Material[80];

    // Start is called before the first frame update
    void Start()
    {
        discoRenderers = GetComponentsInChildren<Renderer>();
        for(int i = 0; i < discoRenderers.Length-1; i++)
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
            m.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}
