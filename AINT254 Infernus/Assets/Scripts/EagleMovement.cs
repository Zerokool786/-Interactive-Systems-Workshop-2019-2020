using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMovement : MonoBehaviour
{
    Rigidbody Eagle;
    public float HoverUp; //display on inspector

    private void Awake()
    {
        Eagle = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() //great with physics in unity
    {
        HoverUpDown();

        Eagle.AddRelativeForce(Vector3.up * HoverUp);
    }
    void HoverUpDown() //WASD Movement
    {
        if (Input.GetKey(KeyCode.I))
        {
            HoverUp = 450;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            HoverUp = -200;
        }
        else if (!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K))   //// if not clicking then hoverup by 98.1 default value for gravity inside unity
        {
            HoverUp = 98.1f; //gravity * mass
        }
    }
}

