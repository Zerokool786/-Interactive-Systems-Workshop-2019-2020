using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody))]
public class Fly : MonoBehaviour
{

    public float AmbientSpeed = 100.0f;

    public float RotationSpeed = 100.0f;

    private Rigidbody Eagle; //little bug private keeps it from not interfering with Eagle Movement 

    // Use this for initialization
    void Start()
    {
        Eagle = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    

    void FixedUpdate()
    {
       UpdateFunction();
        
    }

    void UpdateFunction()
    {
        Quaternion AddRot = Quaternion.identity;
        float roll = 0;
        float pitch = 0;
        float yaw = 0;
        roll = Input.GetAxis("Roll") * (Time.fixedDeltaTime * RotationSpeed);
        pitch = Input.GetAxis("Pitch") * (Time.fixedDeltaTime * RotationSpeed);
        yaw = Input.GetAxis("Yaw") * (Time.fixedDeltaTime * RotationSpeed);
        AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
        Eagle.rotation *= AddRot;
        Vector3 AddPos = Vector3.forward;
        AddPos = Eagle.rotation * AddPos;
        Eagle.velocity = AddPos * (Time.fixedDeltaTime * AmbientSpeed);

    }
}
