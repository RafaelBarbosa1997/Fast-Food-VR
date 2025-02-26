using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Drink : MonoBehaviour
{
    public enum DRINKSIZE
    {
        Small,
        Medium,
        Large
    }

    [SerializeField]
    private DRINKSIZE size;

    [SerializeField]
    private MachineSlot.DRINKTYPE type;

    [SerializeField]
    private float maxDrink;// How much to fill until full.
    [SerializeField]
    private float currentDrink;// How much is currently filled.

    [SerializeField]
    private float fillSpeed;
    private bool filling;// Is the drink currently being filled.

    private MachineSlot currentSlot;// The machine slot this drink is currently slotted to.

    [SerializeField]
    private GameObject cap;// Drink cap to put on after drink is filled.

    private DrinkGrab grab;

    public bool IsFull => currentDrink == maxDrink;

    public DRINKSIZE Size { get => size; private set => size = value; }
    public MachineSlot.DRINKTYPE Type { get => type; private set => type = value; }
    public bool Filling { get => filling; private set => filling = value; }

    public float CurrentDrink
    {
        get { return currentDrink; }
        private set
        {
            if (value < 0) currentDrink = 0;
            else if (value > maxDrink) currentDrink = maxDrink;
            else currentDrink = value;
        }
    }

    private void Start()
    {
        grab = GetComponent<DrinkGrab>();
    }

    private void Update()
    {
        if (filling)
        {
            // Fill drink.
            CurrentDrink += fillSpeed * Time.deltaTime;

            if (IsFull)// When drink has been filled.
            {
                // No longer filling.
                filling = false;

                // Setup slot to be empty.
                currentSlot.SetLightFilled();
                currentSlot.DisableStream();
                currentSlot.StopAudio();
                currentSlot.Slotted = false;
                currentSlot = null;

                // Put cap on drink.
                cap.SetActive(true);

                // Let player grab drink again once it's full.
                grab.enabled = true;
            }
        }
    }

    public void StartFilling()
    {
        filling = true;
    }

    public void SetDrinkType(MachineSlot.DRINKTYPE drinkType)
    {
        type = drinkType;
    }

    public void SetCurrentSlot(MachineSlot slot)
    {
        currentSlot = slot;
    }
}
