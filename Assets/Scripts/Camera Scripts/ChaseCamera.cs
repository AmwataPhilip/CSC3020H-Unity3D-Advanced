using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float cameraSpeed = 5.0f;

    [SerializeField]
    private float cameraDistance = 5.0f;

    [SerializeField]
    private Vector3 offset;



    void FixedUpdate()
    {
        Vector3 translationVector = new Vector3(0, 0, cameraSpeed * Time.deltaTime);
        Vector3 lookPos = player.position + offset;
        transform.LookAt(lookPos);

        if(Vector3.Distance(transform.position, lookPos) > cameraDistance)
        {
            transform.Translate(translationVector);
        }
    }

    public void SetCameraDistance(float d)
    {
        cameraDistance = d;
    }

    public void SetCameraSpeed (float s)
    {
        cameraSpeed = s;
    }
}
