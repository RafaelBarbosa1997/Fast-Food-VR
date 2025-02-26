using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ticket : MonoBehaviour
{
    private FryBox.FRYSIZE frySize;

    private Drink.DRINKSIZE drinkSize;
    private MachineSlot.DRINKTYPE drinkType;

    private int pattyAmount;
    private int lettuceAmount;
    private int cheeseAmount;
    private int cowTongueAmount;
    private int greenCandyAmount;
    private int blueRingAmount;

    [SerializeField]
    private Recipe[] recipes;

    private Recipe selectedRecipe;

    [SerializeField]
    private TMP_Text fryText;
    [SerializeField]
    private TMP_Text drinkText;
    [SerializeField]
    private TMP_Text burgerText;
    [SerializeField]
    private TMP_Text ingredientText;

    public FryBox.FRYSIZE FrySize { get => frySize; private set => frySize = value; }
    public Drink.DRINKSIZE DrinkSize { get => drinkSize; private set => drinkSize = value; }
    public MachineSlot.DRINKTYPE DrinkType { get => drinkType; private set => drinkType = value; }
    public int PattyAmount { get => pattyAmount; private set => pattyAmount = value; }
    public int LettuceAmount { get => lettuceAmount; private set => lettuceAmount = value; }
    public int CheeseAmount { get => cheeseAmount; private set => cheeseAmount = value; }
    public int CowTongueAmount { get => cowTongueAmount; private set => cowTongueAmount = value; }
    public int GreenCandyAmount { get => greenCandyAmount; private set => greenCandyAmount = value; }
    public int BlueRingAmount { get => blueRingAmount; private set => blueRingAmount = value; }

    private void Start()
    {
        RandomizeFries();
        RandomizeDrink();
        RandomizeRecipe();

        SetText();
    }

    private void RandomizeFries()
    {
        int max = Enum.GetNames(typeof(FryBox.FRYSIZE)).Length - 1;
        int selection = UnityEngine.Random.Range(0, max);

        frySize = (FryBox.FRYSIZE)selection;
    }

    private void RandomizeDrink()
    {
        // Drink size.
        int max = Enum.GetNames(typeof(Drink.DRINKSIZE)).Length - 1;
        int selection = UnityEngine.Random.Range(0, max);

        drinkSize = (Drink.DRINKSIZE)selection;

        // Drink type.
        max = Enum.GetNames(typeof(MachineSlot.DRINKTYPE)).Length - 1;
        selection = UnityEngine.Random.Range(1, max);// 1 cause 0 is empty.

        drinkType = (MachineSlot.DRINKTYPE)selection;
    }

    private void RandomizeRecipe()
    {
        int max = recipes.Length - 1;
        int selection = UnityEngine.Random.Range(0, max);

        selectedRecipe = recipes[selection];

        pattyAmount = selectedRecipe.PattyAmount;
        lettuceAmount = selectedRecipe.LettuceAmount;
        cheeseAmount = selectedRecipe.CheeseAmount;
        cowTongueAmount = selectedRecipe.CowTongueAmount;
        greenCandyAmount = selectedRecipe.GreenCandyAmount;
        blueRingAmount = selectedRecipe.BlueRingAmount;
    }

    private void SetText()
    {
        // Fries.
        fryText.text = frySize.ToString() + " Fries";

        // Drink.
        drinkText.text = drinkSize.ToString() + " " + drinkType.ToString();

        // Burger.
        burgerText.text = selectedRecipe.name + " Burger";

        // Ingredients.
        ingredientText.text = "";
        if (pattyAmount > 0) ingredientText.text += pattyAmount.ToString() + " Patties \n";
        if (lettuceAmount > 0) ingredientText.text += lettuceAmount.ToString() + " Lettuce \n";
        if (cheeseAmount > 0) ingredientText.text += cheeseAmount.ToString() + " Cheese \n";
        if (cowTongueAmount > 0) ingredientText.text += cowTongueAmount.ToString() + " Cow Tongue \n";
        if (greenCandyAmount > 0) ingredientText.text += greenCandyAmount.ToString() + " Candy \n";
        if (blueRingAmount > 0) ingredientText.text += blueRingAmount.ToString() + " Blue Ring \n";

        ingredientText.text += "Top with bun";
    }
}
