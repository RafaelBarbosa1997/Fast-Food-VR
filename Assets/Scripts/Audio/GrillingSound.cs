using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillingSound : MonoBehaviour
{
    private AudioSource source;

    private int pattyAmount;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Patty")
        {
            pattyAmount++;

            UpdateSoundStatus();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Patty")
        {
            pattyAmount--;

            UpdateSoundStatus();
        }
    }

    private void UpdateSoundStatus()
    {
        if (pattyAmount > 0 && !source.isPlaying) source.Play();

        else if(pattyAmount <= 0 && source.isPlaying) source.Stop();
    }
}
