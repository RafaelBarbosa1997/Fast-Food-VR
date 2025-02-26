using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOrder : MonoBehaviour
{
    private List<GameObject> objectsToDestroy = new List<GameObject>();

    public void DestroyObjects()
    {
        foreach(GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }

        objectsToDestroy.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Patty" || other.tag == "Ingredient" || other.tag == "Drink" || other.tag == "Fries")
        {
            objectsToDestroy.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Patty" || other.tag == "Ingredient" || other.tag == "Drink" || other.tag == "Fries")
        {
            objectsToDestroy.Remove(other.gameObject);
        }
    }
}
