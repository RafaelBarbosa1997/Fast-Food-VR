using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineSlot : MonoBehaviour
{
    public enum DRINKTYPE
    {
        EMPTY,
        Bepsi,
        Ecola,
        Logger,
        Sprunk
    }

    [SerializeField]
    private DRINKTYPE drinkType;

    [SerializeField]
    private MeshRenderer lightRenderer;
    [SerializeField]
    private Material fillingMat;
    [SerializeField]
    private Material filledMat;
    private Material defaultMat;

    private bool slotted;// Is a drink slotted into this slot.

    [SerializeField]
    private MeshRenderer slotRenderer;

    [SerializeField]
    private GameObject stream;

    private AudioSource audioSource;

    public DRINKTYPE DrinkType { get => drinkType; private set => drinkType = value; }
    public bool Slotted { get => slotted; set => slotted = value; }


    private void Start()
    {
        defaultMat = lightRenderer.material;
        audioSource = GetComponent<AudioSource>();
    }

    public void SetLightDisabled()
    {
       if(lightRenderer.material != defaultMat) lightRenderer.material = defaultMat;
    }

    public void SetLightFilled()
    {
        lightRenderer.material = filledMat;
    }

    public void SetLightFilling()
    {
        lightRenderer.material = fillingMat;
    }

    public void disableHighlight()
    {
        slotRenderer.enabled = false;
    }

    public void enableHighlight()
    {
        slotRenderer.enabled = true;
    }

    public void EnableStream()
    {
        stream.SetActive(true);
    }

    public void DisableStream()
    {
        stream.SetActive(false);
    }

    public void PlayAudio()
    {
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
}
