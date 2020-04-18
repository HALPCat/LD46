using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    Vector3 inputVector;
    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();

        Vector3 firstWayPoint = WaypointManager.Instance.GetFirstWaypoint().transform.position;
        transform.position = new Vector3(firstWayPoint.x, 0, firstWayPoint.z);
    }

    void Update()
    {
        UpdateInputVector();
        cc.Move(inputVector.normalized * speed * Time.deltaTime);
    }

    void UpdateInputVector()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
