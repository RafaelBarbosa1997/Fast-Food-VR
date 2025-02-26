using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour
{
    [SerializeField]
    private int pattyAmount;
    [SerializeField]
    private int lettuceAmount;
    [SerializeField]
    private int cheeseAmount;
    [SerializeField]
    private int cowTongueAmount;
    [SerializeField]
    private int greenCandyAmount;
    [SerializeField]
    private int blueRingAmount;
    [SerializeField]
    private int bunAmount;

    private TopBunCheck topBunCheck;

    public int PattyAmount { get => pattyAmount; private set => pattyAmount = value; }
    public int LettuceAmount { get => lettuceAmount; private set => lettuceAmount = value; }
    public int CheeseAmount { get => cheeseAmount; private set => cheeseAmount = value; }
    public int CowTongueAmount { get => cowTongueAmount; private set => cowTongueAmount = value; }
    public int GreenCandyAmount { get => greenCandyAmount; private set => greenCandyAmount = value; }
    public int BlueRingAmount { get => blueRingAmount; private set => blueRingAmount = value; }
    public int BunAmount { get => bunAmount; private set => bunAmount = value; }
    public TopBunCheck TopBunCheck { get => topBunCheck; private set => topBunCheck = value; }

    private void OnTriggerEnter(Collider other)
    {
        // Add patty.
        if(other.tag == "Patty")
        {
            PattyStatus patty = other.GetComponent<PattyStatus>();

            if (patty.Cooked) pattyAmount++;
        }

        // Add ingredient.
        if(other.tag == "Ingredient")
        {
            Ingredient ingredient = other.GetComponent<Ingredient>();

            switch (ingredient.Type)
            {
                case Ingredient.IngredientType.LETTUCE: 
                    lettuceAmount++; 
                    break;
                case Ingredient.IngredientType.CHEESE: 
                    cheeseAmount++; 
                    break;
                case Ingredient.IngredientType.COWTONGUE: 
                    cowTongueAmount++; 
                    break;
                case Ingredient.IngredientType.GREENCANDY:
                    greenCandyAmount++;
                    break;
                case Ingredient.IngredientType.BLUERING:
                    blueRingAmount++;
                    break;
                case Ingredient.IngredientType.BUN:
                    bunAmount++;
                    if(bunAmount == 1) topBunCheck = other.transform.GetChild(0).GetComponent<TopBunCheck>();
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove patty.
        if(other.tag == "Patty")
        {
            PattyStatus patty = other.GetComponent<PattyStatus>();

            if (patty.Cooked) pattyAmount--;
        }

        // Remove ingredient.
        if (other.tag == "Ingredient")
        {
            Ingredient ingredient = other.GetComponent<Ingredient>();

            switch (ingredient.Type)
            {
                case Ingredient.IngredientType.LETTUCE:
                    lettuceAmount--;
                    break;
                case Ingredient.IngredientType.CHEESE:
                    cheeseAmount--;
                    break;
                case Ingredient.IngredientType.COWTONGUE:
                    cowTongueAmount--;
                    break;
                case Ingredient.IngredientType.GREENCANDY:
                    greenCandyAmount--;
                    break;
                case Ingredient.IngredientType.BLUERING:
                    blueRingAmount--;
                    break;
                case Ingredient.IngredientType.BUN:
                    bunAmount--;
                    if (bunAmount == 1) topBunCheck = other.transform.GetChild(0).GetComponent<TopBunCheck>();
                    break;
            }
        }
    }
}
