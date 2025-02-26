using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSlot : MonoBehaviour
{
    [SerializeField]
    private string ValidTag;

    [SerializeField]
    private Material noHighlight;
    [SerializeField]
    private Material highlight;

    [SerializeField]
    private MeshRenderer slotRenderer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ValidTag)
        {
            Material[] originalMats = slotRenderer.materials;

            for(int i = 0; i < originalMats.Length; i++)
            {
                originalMats[i] = highlight;
            }

            slotRenderer.materials = originalMats;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Material[] originalMats = slotRenderer.materials;

        for(int i = 0; i < originalMats.Length; i++)
        {
            originalMats[i] = noHighlight;
        }

        slotRenderer.materials = originalMats;
    }
}
