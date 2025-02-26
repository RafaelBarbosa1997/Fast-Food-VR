using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
    [SerializeField]
    private Burger burger;

    [SerializeField]
    private FryBox fryBox;

    [SerializeField]
    private Drink drink;

    public FryBox FryBox { get => fryBox; set => fryBox = value; }
    public Drink Drink { get => drink; set => drink = value; }
    public Burger Burger { get => burger; set => burger = value; }
}
