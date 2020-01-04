
using UnityEngine;

public class ChaseCam : MonoBehaviour
{
    public Transform target; //

    public Vector3 offset;

    public float smoothSpeed = 0.125f; //smooth amount, small value takes more time smoothing whereas higher value locks faster to target

    private void FixedUpdate() //runs late after target has started moving in game
    {
        Vector3 desiredPosition = target.position + offset; //every frame snap to target

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);  //smooth tavel from A to B, when 1 take desired position if 0 takes first position or b/w 0 and 1 get mix of two depending on smooth speed
        transform.position = smoothedPosition;     //add x-postion of offset and target

        transform.LookAt(target);

      

    }
}
