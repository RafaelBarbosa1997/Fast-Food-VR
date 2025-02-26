using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkSlot : MonoBehaviour
{
    private Tray tray;

    private bool slotted;

    [SerializeField]
    private GameObject highlight;

    public bool Slotted { get => slotted; private set => slotted = value; }

    private void Start()
    {
        tray = transform.parent.GetComponent<Tray>();
    }

    public void SetTrayDrink(Drink drink)
    {
        highlight.SetActive(false);

        tray.Drink = drink;
        slotted = true;
    }

    public void RemoveTrayDrink()
    {
        highlight.SetActive(true);

        tray.Drink = null;
        slotted = false;
    }
}
