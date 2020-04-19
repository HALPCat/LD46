using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 1;
    public float accelerationSpeed = 1;
    public float deAccelerationSpeed = 1;
    [SerializeField]
    private float speed = 0;

    [SerializeField]
    Vector3 inputVector;
    [SerializeField]
    Vector3 movementVector;
    [SerializeField]
    Vector3 lastInputVector;

    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();

        Vector3 firstWayPoint = WaypointManager.Instance.GetFirstWaypoint().transform.position;
        transform.position = new Vector3(firstWayPoint.x, 0, firstWayPoint.z);
    }

    void Update()
    {
        if(inputVector != Vector3.zero)
        {
            lastInputVector = inputVector.normalized;
        }
        UpdateInputVector();
        UpdateMovementVector();
        if(inputVector != Vector3.zero)
        {
            cc.Move(movementVector * Time.deltaTime);
        }else{
            cc.Move(lastInputVector * speed * Time.deltaTime);
        }
        
        Quaternion target = Quaternion.LookRotation(lastInputVector, Vector3.up);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, 5f * Time.deltaTime);
    }

    void UpdateInputVector()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    void UpdateMovementVector()
    {
        if(inputVector.magnitude != 0){
            //Debug.Log("Calling");
            if(speed < maxSpeed){
                speed += Time.deltaTime * accelerationSpeed;
                //Debug.Log(speed);
                //Debug.Log(accelerationSpeed);
            }else{
                speed = maxSpeed;
            }
        }else{
            if(speed > 0){
                speed -= deAccelerationSpeed * Time.deltaTime;
            }else{
                speed = 0;
            }
        }
        movementVector = inputVector.normalized * speed;
    }
}
