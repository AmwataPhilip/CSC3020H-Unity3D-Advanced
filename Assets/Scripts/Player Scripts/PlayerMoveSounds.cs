/*
 *  @author: Philip Amwata
 *  Date: 09/05/2019
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSounds : MonoBehaviour
{
    private AudioSource footstepSound; // AudioSource object

    [SerializeField]
    private AudioClip[] footstepClips; // AudioClip array to hold footstep sounds clips

    [HideInInspector]
    public float volumeMin, volumeMax, stepDistance; // Minimum/Maximum volume and step girth

    private float distanceMoved; // Total distance before step sound is played

    [SerializeField]
    private CharacterController charController; // Character controller for player object

    // Start is called before the first frame update
    void Awake()
    {
        footstepSound = GetComponent<AudioSource>(); // Get reference to AudioSource component
    }

    // Update is called once per frame
    void Update()
    {
        SoundChecker();
    }

    void SoundChecker()
    {
        // Check to see if player is on the ground
        if (charController.isGrounded)
        {
            // Check to see if object is moving (player)
            if (charController.velocity.sqrMagnitude > 0)
            {
                distanceMoved += Time.deltaTime;
                if (distanceMoved > stepDistance)
                {
                    footstepSound.volume = Random.Range(volumeMin, volumeMax); // Set play volume to random value
                    footstepSound.clip = footstepClips[Random.Range(0, footstepClips.Length)]; // Get random audio clip to play
                    footstepSound.Play();
                    print("Playing sound");

                    distanceMoved = 0.0f; // Reset distance moved by player
                }
            }
            else
            {
                distanceMoved = 0.0f; // Reset distance moved by player
            }
        }
        else
        {
            return;
        }

    }
}
