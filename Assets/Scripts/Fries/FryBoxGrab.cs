using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FryBoxGrab : XRGrabInteractable
{
    private FrySlot slot;

    private Rigidbody rb;

    [SerializeField]
    private Vector3 slotOffset;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if(slot != null )
        {
            slot.RemoveTrayFries();
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if (slot != null && !slot.Slotted)
        {
            if (!rb.isKinematic) rb.isKinematic = true;

            Vector3 pos = slot.transform.position - slotOffset;
            transform.position = pos;
            transform.rotation = Quaternion.identity;

            slot.SetTrayFries(GetComponent<FryBox>());
        }

        else if (rb.isKinematic) rb.isKinematic = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FrySlot")
        {
            slot = other.GetComponent<FrySlot>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "FrySlot")
        {
            slot = null;
        }
    }
}
