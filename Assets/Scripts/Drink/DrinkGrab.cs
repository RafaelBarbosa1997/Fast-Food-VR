using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrinkGrab : XRGrabInteractable
{
    [SerializeField]
    private Drink drink;

    private MachineSlot machineSlot;

    private DrinkSlot drinkSlot;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float machineOffset;
    [SerializeField]
    private float trayOffset;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (drinkSlot != null) drinkSlot.RemoveTrayDrink();
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if(machineSlot != null && !machineSlot.Slotted && !drink.IsFull) // Drop drink into machine slot.
        {
            // Position drink in slot.
            Vector3 pos = machineSlot.transform.position - new Vector3(0, machineOffset, 0);
            transform.position = pos;
            transform.rotation = Quaternion.identity;

            // Setup machine slot.
            machineSlot.SetLightFilling();
            machineSlot.EnableStream();
            machineSlot.disableHighlight();
            machineSlot.PlayAudio();
            machineSlot.Slotted = true;

            // Setup drink and start filling.
            drink.SetDrinkType(machineSlot.DrinkType);
            drink.SetCurrentSlot(machineSlot);
            drink.StartFilling();

            // Kinematic while slotted.
            rb.isKinematic = true;

            // Player can't grab drink while its filling.
            enabled = false;
        }

        else if(drinkSlot != null && !drinkSlot.Slotted) // Drop drink into tray slot.
        {
            // Position drink in slot.
            Vector3 pos = drinkSlot.transform.position - new Vector3(0, trayOffset, 0);
            transform.position = pos;
            transform.rotation = Quaternion.identity;

            // Setup drink slot.
            drinkSlot.SetTrayDrink(drink);

            // Kinematic while slotted.
            rb.isKinematic = true;
        }

        else if(rb.isKinematic) rb.isKinematic = false;// Not kinematic if not slotted anywhere.
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MachineSlot")
        {
            machineSlot = other.GetComponent<MachineSlot>();
        }

        else if(other.tag == "DrinkSlot")
        {
            drinkSlot = other.GetComponent<DrinkSlot>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "MachineSlot" && machineSlot != null)
        {
            if (drink.IsFull)
            {
                machineSlot.enableHighlight();
                machineSlot.SetLightDisabled();
            }

            machineSlot = null;
        }

        else if(other.tag == "DrinkSlot")
        {
            drinkSlot = null;
        }
    }
}
