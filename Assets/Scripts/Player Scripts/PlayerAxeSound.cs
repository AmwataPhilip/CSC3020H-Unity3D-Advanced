using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxeSound : MonoBehaviour
{

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] axeSound;

    void PlayWooshSound()
    {
        audioSource.clip = axeSound[Random.Range(0, axeSound.Length)];
        audioSource.Play();
    }


} // class
