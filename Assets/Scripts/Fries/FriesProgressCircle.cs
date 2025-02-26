using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriesProgressCircle : MonoBehaviour
{
    private Frying frying;

    [SerializeField]
    private Transform followTransform;

    [SerializeField]
    private GameObject progressObject;
    [SerializeField]
    private Image progressCircle;

    private void Start()
    {
        frying = GetComponent<Frying>();
    }

    private void Update()
    {
        progressCircle.fillAmount = frying.FryStatus;

        progressObject.transform.position = followTransform.position;
    }
}
