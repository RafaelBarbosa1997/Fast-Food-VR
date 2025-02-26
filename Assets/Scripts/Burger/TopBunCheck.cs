using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBunCheck : MonoBehaviour
{
    private int ingredientAmount;

    public int IngredientAmount { get => ingredientAmount; private set => ingredientAmount = value; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ingredient")
        {
            ingredientAmount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ingredient")
        {
            ingredientAmount--;
        }
    }
}
