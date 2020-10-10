using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ARFollowCam : MonoBehaviour
{
    public Transform ARCam;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    
    void FixedUpdate()
    {
        Vector3 desiredPosition = ARCam.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;

        
    }
}
