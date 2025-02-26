using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;

public class StartupTrackingChange : MonoBehaviour
{
    private XROrigin origin;

    private float timer;
    [SerializeField]
    private float timerMax;

    private void Start()
    {
        origin = GetComponent<XROrigin>();

        timer = timerMax;
    }

    private void Update()
    {
        // Only start timer once device is active.
        if (XRSettings.isDeviceActive)
        {
            // To account for delay.
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                // Set tracking, if switch worked destroy this.
                origin.RequestedTrackingOriginMode = XROrigin.TrackingOriginMode.Floor;
                if (origin.CurrentTrackingOriginMode == TrackingOriginModeFlags.Floor) Destroy(this);
            }
        }
    }
}
