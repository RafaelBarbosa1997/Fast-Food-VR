using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAnchorVisuals : MonoBehaviour
{
    [SerializeField]
    private GameObject visuals;

    public void ActivateVisuals()
    {
        if (!visuals.activeInHierarchy) visuals.SetActive(true);
    }

    public void DeactivateVisuals()
    {
        if (visuals.activeInHierarchy) visuals.SetActive(false);
    }
}
