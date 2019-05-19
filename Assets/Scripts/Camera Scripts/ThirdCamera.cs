using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private InputField inputHeight;

    [SerializeField]
    private InputField inputRadius;

    [SerializeField]
    private InputField inputSpeed;


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

    public void SetHeight(string h)
    {
        height = float.Parse(h);
        inputHeight.text = "";
    }

    public void SetRadius(string r)
    {
        radius = float.Parse(r);
        inputRadius.text = "";
    }

    public void SetRotationSpeed(string rS)
    {
        rotateSpeed = float.Parse(rS);
        inputSpeed.text = "";
    }

    public void DeactivateRotation()
    {
        rotateY = false;
    }

    public void ActivateRotation()
    {
        rotateY = true;
    }
}
