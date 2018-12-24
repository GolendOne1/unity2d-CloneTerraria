using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class Recipe
{
    public readonly ItemID[] Ingredients; //ingredients ID
    public readonly ItemID Output;
    public readonly RecipeType Type;
    public string Name
    {
        get
        {
            return Output.ToString();
        }
    }

    // Constructor
    public Recipe(RecipeType Type, ItemID[] Ingredients, ItemID Output)
    {
        switch (Type)
        {
            case RecipeType.Shaped_3x3:
                this.Ingredients = new ItemID[9];
                for (int i = 0; i < 9; i++)
                {
                    this.Ingredients[i] = Ingredients[i];
                }
                break;
            case RecipeType.Shaped_3x1:
                break;
            case RecipeType.Shaped_2x2:
                break;
            case RecipeType.Formless:
                break;
            default:
                break;
        }
        this.Type = Type;
        this.Output = Output;
    }
}
