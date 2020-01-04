using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProppelerRotation : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.forward, 5f);
    }
}
