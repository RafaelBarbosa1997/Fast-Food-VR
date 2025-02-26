using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketStatus : MonoBehaviour
{
    [SerializeField]
    private GameObject circleObj;

    [SerializeField]
    private Frying frying;

    private bool inOil;

    private AudioSource source;

    public bool InOil { get; private set; }

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Oil" && frying.HasFries)
        {
            // Basket is in oil.
            InOil = true;

            // Set progress circle.
            circleObj.SetActive(true);

            if(!source.isPlaying) source.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Oil")
        {
            // Basket if out of oil.
            InOil = false;

            // Remove progress circle.
            circleObj.SetActive(false);

            if(source.isPlaying) source.Stop();
        }
    }
}
