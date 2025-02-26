using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryReserve : MonoBehaviour
{
    private int scoops;
    [SerializeField]
    private int maxScoops;

    [SerializeField]
    private GameObject[] fryModels;

    public bool IsFull => scoops == maxScoops;

    private void Start()
    {
        foreach (GameObject go in fryModels)
        {
            go.SetActive(false);
        }
    }

    public void SetScoops()
    {
        scoops = maxScoops;

        foreach (GameObject go in fryModels)
        {
            go.SetActive(true);
        }

        AudioManager.Instance.PlaySFX("Fry", true);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Scoop") && scoops > 0)
        {
            Scoop scoop = other.GetComponent<Scoop>();
            if (!scoop.Filled)// If scoop doesn't already have fries on it.
            {
                // Handle scoop.
                AudioManager.Instance.PlaySFX("Fry", true);

                scoop.SetScoop();
                scoops--;

                // Handle fry reserve visuals.
                if(scoops == 4) fryModels[2].SetActive(false);
                if(scoops == 2) fryModels[1].SetActive(false);
                if(scoops == 0) fryModels[0].SetActive(false);
            }
        }
    }
}
