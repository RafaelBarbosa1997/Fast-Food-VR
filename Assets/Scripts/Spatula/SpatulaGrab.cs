using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatulaGrab : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;

    private int pattyAmount;

    private void OnTriggerEnter(Collider other)
    {
        // When spatula head touches burger flop it on top of spatula.
        if(other.tag == "Patty")
        {
            pattyAmount++;

            // Return if were already picking a patty up.
            if (pattyAmount > 1) return;

            // Return if player is grabbing patty.
            if (other.GetComponent<PattyStatus>().IsGrabbing) return;

            Transform burger = other.transform;

            burger.position = spawnPoint.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Patty")
        {
            pattyAmount--;
        }
    }
}
