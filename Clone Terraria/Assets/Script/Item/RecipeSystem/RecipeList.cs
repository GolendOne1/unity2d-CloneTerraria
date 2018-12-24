using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class RecipeList
{
    public List<Recipe> Recipes = new List<Recipe>();  //The list of recipe  #ArrayList
    public Recipe this[int i]
    {
        get
        {
            return Recipes[i];
        }
    }  //indexer

    //Constructor
    public RecipeList()
    {
        ItemID[] Ingredients;
        RecipeType type;

        type = RecipeType.Shaped_3x3;
        Ingredients = new ItemID[9]{
                               ItemID.wood_plank,   ItemID.wood_plank,   ItemID.wood_plank,
                               ItemID.air,          ItemID.stick,        ItemID.air,
                               ItemID.air,          ItemID.stick,        ItemID.air
        };
        AddRecipe(type, Ingredients, ItemID.wood_pickaxe);

        Ingredients = new ItemID[9]{
                               ItemID.cobbleStone,  ItemID.cobbleStone,  ItemID.cobbleStone,
                               ItemID.air,          ItemID.stick,        ItemID.air,
                               ItemID.air,          ItemID.stick,        ItemID.air
        };
        AddRecipe(type, Ingredients, ItemID.stone_pickaxe);

        Ingredients = new ItemID[9]{
                               ItemID.gold_ore,     ItemID.iron_ingot,   ItemID.gold_ore,
                               ItemID.air,          ItemID.air,          ItemID.air,
                               ItemID.air,          ItemID.air,          ItemID.air
        };
        AddRecipe(type, Ingredients, ItemID.silver_ingot);

        Ingredients = new ItemID[9]{
                               ItemID.wood_plank,   ItemID.wood_plank,   ItemID.air,
                               ItemID.wood_plank,   ItemID.stick,        ItemID.air,
                               ItemID.air,          ItemID.stick,        ItemID.air
        };
        AddRecipe(type, Ingredients, ItemID.wood_axe);

        Ingredients = new ItemID[9]{
                               ItemID.cobbleStone,  ItemID.cobbleStone,  ItemID.air,
                               ItemID.cobbleStone,  ItemID.stick,        ItemID.air,
                               ItemID.air,          ItemID.stick,        ItemID.air
        };
        AddRecipe(type, Ingredients, ItemID.stone_axe);
    }

    //public function
    public void AddRecipe(RecipeType type, ItemID[] ingredients, ItemID output)
    {
        Recipes.Add(new Recipe(type, ingredients, output));
    }
    public void RemoveRecipe(int[] ingredients)
    {

    }
    public int? IndexOf(ItemID[] InputIGD)
    {
        //RCP is recipes
        //IGD is ingredients
        //int? MatchRCPindex = null;
        for (int RCPindex = 0; RCPindex < Recipes.Count; RCPindex++)  //search from all recipes
        {
            switch (Recipes[RCPindex].Type)
            {
                case RecipeType.Shaped_3x3:
                    {
                        int count = 0;
                        for (int IGDindex = 0; IGDindex < Recipes[RCPindex].Ingredients.Length; IGDindex++)  //call out all ingredients
                        {
                            if (InputIGD[IGDindex] == Recipes[RCPindex].Ingredients[IGDindex])
                            {
                                count++;
                            }
                        }
                        if (count == 9)
                        {
                            //MatchRCPindex = RCPindex;  //the index
                            //RCPindex = recipes.Count;  //break loop
                            return RCPindex;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        return null;
    }
}