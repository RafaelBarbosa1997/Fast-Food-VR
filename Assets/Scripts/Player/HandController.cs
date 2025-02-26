using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HandController : MonoBehaviour
{
    [SerializeField]
    private Transform hand;

    private Rigidbody rb;

    [SerializeField]
    private PhysicMaterial handPMat;
    private Collider[] colliders;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        colliders = GetComponentsInChildren<Collider>();

        // Set hand physics material on all colliders.
        foreach (Collider collider in colliders)
        {
            collider.material = handPMat;
        }
    }

    private void FixedUpdate()
    {
        // Position.
        rb.velocity = (hand.position - transform.position) / Time.fixedDeltaTime;

        // Rotation.
        Quaternion rotationDifference = hand.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }

    public void EnableHandColliders()
    {
        foreach(Collider collider in colliders)
        {
            collider.enabled = true;
        }
    }

    public void DisableHandColliders()
    {
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
    }
}
