using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableGrabWhileCooking : XRGrabInteractable
{
    [SerializeField]
    private SideCooking top;
    [SerializeField]
    private SideCooking bottom;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // If burger is on grill (cooking) we don't allow the player to grab it.
        if(top.IsCooking || bottom.IsCooking)
        {
            interactionManager.SelectExit(args.interactorObject, this);
            return;
        }

        base.OnSelectEntered(args);
    }
}
