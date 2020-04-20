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

    public Animator animator;

    Vector3 target = Vector3.forward;

    void Start()
    {
        //animator = GetComponentInChildren<Animator>();
        Vector2 randCircle = Random.insideUnitCircle.normalized;
        Vector3 randCirclev3 = new Vector3(randCircle.x, 0, randCircle.y);
        target = transform.position + randCirclev3;
    }

    void Update()
    {
        Quaternion targetQ = new Quaternion();
        targetQ = Quaternion.LookRotation(target - transform.position, Vector3.up); 

        transform.rotation = Quaternion.Slerp(transform.rotation, targetQ, 5f * Time.deltaTime);
    }

    public int Partymood{
        get { return _partymood; }
    }

    public void IncreasePartyMood(Vector3 position, int increment){
        target = position;

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
        animator.SetBool("Converted", true);
    }
}
