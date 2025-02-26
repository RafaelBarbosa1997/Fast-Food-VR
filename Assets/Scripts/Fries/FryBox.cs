using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryBox : MonoBehaviour
{
    public enum FRYSIZE
    {
        Small,
        Medium,
        Large
    }

    [SerializeField]
    private FRYSIZE size;

    [SerializeField]
    private int maxScoops;
    private int currentScoops;

    [SerializeField]
    private GameObject[] fryModels;

    public bool Full => currentScoops == maxScoops;

    public FRYSIZE Size { get => size; private set => size = value; }

    public void AddScoop()
    {
        fryModels[currentScoops].SetActive(true);

        currentScoops++;

        AudioManager.Instance.PlaySFX("Fry", true);
    }
}
