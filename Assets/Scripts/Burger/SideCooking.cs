using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCooking : MonoBehaviour
{
    private bool isCooking;// Is this burger side currently being cooked.

    private float cookAmount;// how cooked is this side, from 0 to 1 for lerping.

    [SerializeField]
    private float cookSpeed;

    [SerializeField]
    private float minCook;// Value when burger enters cooked state.
    [SerializeField]
    private float maxCook;// Value when burger enters overcooked state.

    [SerializeField]
    private GameObject cookStatusPrefab;// Interact with cooking progress circle.
    [SerializeField]
    private Transform cookStatusTransform;
    [SerializeField]
    private Vector3 statusRotation;
    private CookStatus activeStatus;

    [SerializeField]
    private MeshRenderer sideMat;// Reference to material for this side of burger.
    [SerializeField]
    private int matIndex;
    [SerializeField]
    private Material undercooked;
    [SerializeField]
    private Material cooked;
    [SerializeField]
    private Material burnt;

    public bool IsCooking { get => isCooking; set => isCooking = value; }

    public float MinCook { get => minCook; private set => minCook = value; }

    public float MaxCook { get => maxCook; private set => maxCook = value; }

    public bool IsCooked => cookAmount >= minCook && cookAmount <= maxCook;

    public float CookAmount
    {
        get => cookAmount;

        private set
        {
            if(value < 0) cookAmount = 0;
            else if (value > 1) cookAmount = 1;
            else cookAmount = value;
        }
    }

    private void Start()
    {
        ChangeMat(undercooked);
    }

    private void Update()
    {
        if (isCooking)// Cook patty.
        {
            CookAmount += cookSpeed * Time.deltaTime;

            if (cookAmount > minCook && cookAmount < maxCook && sideMat.materials[matIndex] != cooked) ChangeMat(cooked);
            else if (cookAmount > maxCook && sideMat.materials[matIndex] != burnt) ChangeMat(burnt);
        }
    }

    private void ChangeMat(Material newMat)
    {
        Material[] mats = sideMat.materials;

        mats[matIndex] = newMat;

        sideMat.materials = mats;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Grill")// When entering grill.
        {
            // Start cooking.
            isCooking = true;

            // Start progress circle.
            GameObject go = Instantiate(cookStatusPrefab);
            activeStatus = go.GetComponent<CookStatus>();
            activeStatus.SetParameters(this, cookStatusTransform, statusRotation);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Grill")// When leaving grill.
        {
            // Stop cooking.
            isCooking = false;

            // Stop progress circle.
            Destroy(activeStatus.gameObject);
            activeStatus = null;
        }
    }
}
