using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;

    [SerializeField]
    private float rotateSpeed = 5.0f;

    [SerializeField]
    private float height = 2.0f;

    [SerializeField]
    private float radius = 2.0f;

    public bool rotateY = true;


    void FixedUpdate()
    {
        if(player != null)
        {
            transform.LookAt(player.transform);

            if (rotateY)
            {
                transform.RotateAround(player.transform.position, Vector3.up, rotateSpeed);
            }
        }
    }

    public void SetHeight(float h)
    {
        this.height = h;
    }

    public void SetRadius(float r)
    {
        this.radius = r;
    }

    public void SetRotationSpeed(float rS)
    {
        this.rotateSpeed = rS;
    }

    public void DeactivateRotation()
    {
        this.rotateY = false;
    }

    public void ActivateRotation()
    {
        this.rotateY = true;
    }
}
