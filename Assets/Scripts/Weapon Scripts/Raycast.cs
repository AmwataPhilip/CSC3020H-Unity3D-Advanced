using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField]
    private float maxFireRange = 25.0f;

    private Raycast hit;

    private void FixedUpdate()
    {
        Ray bullet = new Ray(transform.position, Vector3.right);
        
        if(Physics.Raycast(bullet, maxFireRange))
        {
            GameObject enemy = GameObject.Find(hit.transform.name);
            Destroy(enemy);
        }
    }
}
