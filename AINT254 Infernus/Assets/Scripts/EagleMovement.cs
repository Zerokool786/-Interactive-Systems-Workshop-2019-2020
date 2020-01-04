using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMovement : MonoBehaviour
{
    private Rigidbody Eagle2;
    public float hoverUp; //display on inspector
    private float forwardSpeed = 500.0f;
    private float leaningForward = 0f; //amount of tilt 
    private float slantForward; //value for smoothing out angle when leaning forward 
    private void Awake()
    {
        Eagle2 = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Debug.Log("EagleMovement Script added to: " + gameObject.name);
    }

    private void FixedUpdate() //great with physics in unity
    {
        HoverUpDown();
        Forward();

        Eagle2.AddForce(Vector3.up * hoverUp);
        Eagle2.rotation = Quaternion.Euler(new Vector3(leaningForward, Eagle2.rotation.y, Eagle2.rotation.z)); //xyzw 4 components of a quaternion only need 3, only rotate around x-axis
    }
    void HoverUpDown() //WASD Movement
    {
        if (Input.GetKey(KeyCode.I))
        {
            hoverUp = 450;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            hoverUp = -200; //downforce like a dive from a eagle
        }
        else if (!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K))   //// if not clicking then hoverup by 98.1 default value for gravity inside unity
        {
            hoverUp = 98.1f; //gravity * mass 
        }
    }

    void Forward() //add Speed
    {
        if(Input.GetAxis("Vertical") != 0) //ws if not zero then 
        {
            Eagle2.AddForce(Vector3.forward * Input.GetAxis("Vertical") * forwardSpeed);
            leaningForward = Mathf.SmoothDamp(leaningForward, 10 * Input.GetAxis("Vertical"), ref slantForward, 0.1f);  //, ref slantForward, 0.1f); //20 degrees, referencing slanting velocity when leaning forward inside variable leaningForward
        }
     
    }
}

