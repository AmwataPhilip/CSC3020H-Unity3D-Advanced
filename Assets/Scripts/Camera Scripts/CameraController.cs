using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject thirdCamera;

    [SerializeField]
    private GameObject firstCamera;

    [SerializeField]
    private GameObject chaseCamera;

    [SerializeField]
    private int cameraMode = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            if(cameraMode == 2)
            {
                cameraMode = 0;
            }
            else if ( cameraMode == 1)
            {
                cameraMode += 1;
            }
            else
            {
                cameraMode += 1;
            }

            StartCoroutine(CameraChange());
        }
    }

    IEnumerator CameraChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (cameraMode == 0)
        {
            firstCamera.SetActive(true);
            thirdCamera.SetActive(false);
            chaseCamera.SetActive(false);
        }
        if (cameraMode == 1)
        {
            thirdCamera.SetActive(true);
            firstCamera.SetActive(false);
            chaseCamera.SetActive(false);
        } if(cameraMode == 2)
        {
            chaseCamera.SetActive(true);
            firstCamera.SetActive(false);
            thirdCamera.SetActive(false);
        }
    }
}
