using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        origin = new Vector3(0.0f, 1.0f, 0.0f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vMove = Input.GetAxis("Vertical");
        float hMove = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(hMove, 0.0f, vMove);

        if(transform.position.y < 0)
        {
            transform.position = origin;
        }
        else
        {
            rb.AddForce(movement);
        }

    }
}
