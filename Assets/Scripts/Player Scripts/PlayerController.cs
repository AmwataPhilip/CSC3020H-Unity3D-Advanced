using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController charController;
    private Vector3 moveDirection;
    private float fGravity = 20.0f;
    private float vertVelocity;

    public float speed = 5.0f;
    public float fJump = 10.0f;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        moveDirection = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0.0f, Input.GetAxis(Axis.VERTICAL));

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        ApplyGravity();

        charController.Move(moveDirection);
    }

    void ApplyGravity()
    {
        vertVelocity -= fGravity * Time.deltaTime;

        JumpPlayer();

        moveDirection.y = vertVelocity * Time.deltaTime;
    }

    void JumpPlayer()
    {
        if(charController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            vertVelocity = fJump;
        }
    }
}
