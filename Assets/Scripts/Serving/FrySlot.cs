using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrySlot : MonoBehaviour
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

    public void SetTrayFries(FryBox box)
    {
        highlight.SetActive(false);

        tray.FryBox = box;
        slotted = true;
    }

    public void RemoveTrayFries()
    {
        highlight.SetActive(true);

        tray.FryBox = null;
        slotted = false;
    }
}
