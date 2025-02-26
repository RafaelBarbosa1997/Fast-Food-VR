using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookStatus : MonoBehaviour
{
    [SerializeField]
    private Image progressCircle;

    private Vector3 targetRotation;

    private SideCooking side;// Get cook state change values.
    private Transform followTransform;

    private void Update()
    {
        if(side == null) return;

        // Set image fill.
        progressCircle.fillAmount = side.CookAmount;

        transform.position = followTransform.position;

        transform.rotation = Quaternion.Euler(targetRotation);
    }

    public void SetParameters(SideCooking newSide, Transform follow, Vector3 rotation)
    {
        side = newSide;
        followTransform = follow;
        targetRotation = rotation;
    }
}
