/*
 *  @author: Philip Amwata
 *  Date: 09/05/2019
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintCrouch : MonoBehaviour
{
    private PlayerController pController;

    public float sprintSpeed = 10.0f; // speed of player while sprinting
    public float moveSpeed = 5.0f; // Speed of player while walking
    public float crouchSpeed = 2.0f; // Speed of player while crouching

    private Transform viewRoot; // Get reference to first person camera object
    private float standHeight = 1.6f; // Camera height while standing 
    private float crouchHeight = 1.0f; // Camera height while crouching

    private bool isCrouching; // Check if crouching

    private PlayerMoveSounds footstepScript; // Get reference to PlayerMoveSounds script

    private float sprintVolume = 1.0f; // Value of volume of steps while sprinting
    private float crouchVolume = 0.1f; // Value of volume of steps while crouching
    private float walkVolumeMin = 0.2f, walkVolumeMax = 0.6f; // Range of volume of steps while walking

    private float walkStepLength = 0.4f; // Players step length
    private float crouchStepLength = 0.5f; // Players step length
    private float sprintStepLength = 0.2f; // Players step length

    // Start is called before the first frame update
    void Awake()
    {
        pController = GetComponent<PlayerController>();
        footstepScript = GetComponentInChildren<PlayerMoveSounds>();
        viewRoot = transform.GetChild(0);
    }

    private void Start()
    {
        footstepScript.volumeMax = walkVolumeMax;
        footstepScript.volumeMin = walkVolumeMin;
        footstepScript.stepDistance = walkStepLength;

    }

    // Update is called once per frame
    void Update()
    {
        Sprint(); // Sprint method
        Crouch(); // Crouch method
    }

    // Allow player to sprint while holding down left shift
    void Sprint()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching)
        {
            pController.speed = sprintSpeed;
            footstepScript.stepDistance = sprintStepLength; // Set step length to sprintStepLength
            footstepScript.volumeMin = sprintVolume; // Set minimum of volume range to sprint volume
            footstepScript.volumeMax = sprintVolume; // Set maximum of volume range to sprint volume
        }

        if(Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
        {
            pController.speed = moveSpeed; // Reset player speed to walking speed
            footstepScript.volumeMax = walkVolumeMax;
            footstepScript.volumeMin = walkVolumeMin;
            footstepScript.stepDistance = walkStepLength;
        }
    }

    // Allow player to crouch after pressing C
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isCrouching) // Crouching so stand
            {
                viewRoot.localPosition = new Vector3(0.0f, standHeight, 0.0f); // Change FP camera height to standHeight
                pController.speed = moveSpeed; // Set player speed to walking speed
                footstepScript.volumeMax = walkVolumeMax;
                footstepScript.volumeMin = walkVolumeMin;
                footstepScript.stepDistance = walkStepLength; // Set step length to crouch step length
                isCrouching = false; // Set crouching to false
            }
            else // Not crouching then crouch
            {
                viewRoot.localPosition = new Vector3(0.0f, crouchHeight, 0.0f); // Change FP camera height to crouchHeight
                pController.speed = crouchSpeed; // Set player speed to crouching speed
                footstepScript.volumeMax = crouchVolume;
                footstepScript.volumeMin = crouchVolume;
                footstepScript.stepDistance = crouchStepLength; // Set step length to crouch step length
                isCrouching = true; // Set crouching to true
            }
        }
    }
}
