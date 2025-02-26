using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoop : MonoBehaviour
{
    [SerializeField]
    private GameObject fryModel;

    private bool filled;

    [SerializeField]
    private bool grabbed;

    public bool Filled { get => filled; private set => filled = value; }


    public void SetScoop()
    {
        fryModel.SetActive(true);
        filled = true;

        AudioManager.Instance.PlaySFX("Fry", true);
    }

    public void SetGrabbedOn()
    {
        grabbed = true;
    }

    public void SetGrabbedOff()
    {
        grabbed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FryBox" && filled && grabbed)
        {
            FryBox box = other.transform.parent.GetComponent<FryBox>();

            if (box.Full) return;

            box.AddScoop();

            filled = false;
            fryModel.SetActive(false);
        }
    }
}
