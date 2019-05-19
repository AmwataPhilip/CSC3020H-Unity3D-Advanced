using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private InputField inputDistance;

    [SerializeField]
    private InputField inputSpeed;


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

    public void SetCameraDistance(string d)
    {
        cameraDistance = float.Parse(d);
        inputDistance.text = "";
    }

    public void SetCameraSpeed (string s)
    {
        cameraSpeed = float.Parse(s);
        inputSpeed.text = "";
    }
}
