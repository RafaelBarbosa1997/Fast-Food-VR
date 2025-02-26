using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReturn : MonoBehaviour
{
    [SerializeField]
    private Transform returnPoint;

    private Rigidbody rb;

    private Quaternion rotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        rotation = transform.rotation;
    }

    public void PickUpObject()
    {
        // Rigidbody is not kinematic when player is interacting with it.
        rb.isKinematic = false;
    }

    public void ReturnObject()
    {
        // When player drops object, make rigidbody kinematic and return it to its default position.
        rb.isKinematic = true;

        transform.position = returnPoint.position;
        transform.rotation = rotation;
    }
}
