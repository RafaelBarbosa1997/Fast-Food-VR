using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PattyStatus : MonoBehaviour
{
    [SerializeField]
    private SideCooking top;// Get cook amount of top side.
    [SerializeField]
    private SideCooking bottom;// Get cook amount of bottom side.

    private bool isGrabbing;// Is the patty being grabbed by player.

    public bool Cooked => (top.IsCooked && bottom.IsCooked);// If both sides are cooked burger is cooked.

    public bool IsGrabbing { get => isGrabbing; private set => isGrabbing = value; }

    public void StartGrabbing()
    {
        isGrabbing = true;
    }

    public void StopGrabbing()
    {
        isGrabbing = false;
    }
}
