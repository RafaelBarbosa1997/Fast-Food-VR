using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BasketGrab : XRGrabInteractable
{
    [SerializeField]
    private BasketStatus status;

    private Frying frying;

    private void Start()
    {
        frying = GetComponent<Frying>();
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if (!status.InOil || !frying.HasFries)// If basket isn't in oil, return it to default position.
        {
            GetComponent<ObjectReturn>().ReturnObject();
        }
    }
}
