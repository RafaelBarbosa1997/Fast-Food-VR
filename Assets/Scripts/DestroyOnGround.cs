using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnGround : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Destroy objects when they fall on the ground.
        if(other.tag == "Patty" || other.tag == "Ingredient" || other.tag == "Fries" || other.tag == "Drink")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
