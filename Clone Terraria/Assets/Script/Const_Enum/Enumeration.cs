using System;
using System.Collections.Generic;

namespace Data
{
    //備註:
    //enum ID : long 可以儲存為Long的型態
    public enum ItemID
    {
        ///////////////////////  Blocks
        air = -1,
        grass,
        dirt,
        stone,
        wood,
        wood_plank,
        cobbleStone,
        iron_ore,
        gold_ore,
        silver_ore,
        ///////////////////////  Tools
        wood_axe,
        wood_pickaxe,
        wood_shovel,
        wood_hammer,
        stone_axe,
        stone_pickaxe,
        stone_shovel,
        stone_hammer,
        ///////////////////////  Others
        iron_ingot,
        gold_ingot,
        silver_ingot,
        stick
    }
    public enum ToolType
    {
        Axe,
        Pickaxe,
        Shovel,
        Hammer,
        Other
    }
    public enum ToolLevel
    {
        None,
        Wood,
        Stone,
        Iron,
        Diamond
    }
    public enum RecipeType
    {
        Shaped_3x3,
        Shaped_2x2,
        Shaped_3x1,
        Formless
    }
}

[Obsolete("This Enum is obsolete. Use Data.ToolType instead.")]
public enum Tool
{
    Hand,
    Pickaxe,
    Shovel,
    Axe
}

[Obsolete("This Enum is obsolete. Use Data.ToolLevel instead.")]
public enum ToolLevel
{
    None,
    Wood,
    Stone,
    Iron,
    Diamond
}

