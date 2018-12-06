using System;
using System.Collections.Generic;

namespace Assets.Script.BlockAndItem
{
    public class Item
    {
        private static BlockDictionary blockDictionary;//temp
        private int maxStack;
        
        protected Tool      tool;
        protected ToolLevel toolLevel;

        protected int[]  id;
        protected string name;

        protected int    stack;

        protected bool   breakable;
        protected float  durability;      

        public Item(string name)
        {
            maxStack   = 99;   //temp

            breakable  = false;//temp
            durability = 200;  //temp
            
            tool      = Tool.Hand;
            toolLevel = ToolLevel.None;            
            this.name = name;
            stack     = 1;

            id = new int[2];
            //---------------------//temp
            blockDictionary = new BlockDictionary();
            id[0] = blockDictionary.Dictionary[name].mainNum;
            id[1] = blockDictionary.Dictionary[name].subNum;
            //----------------------
        }
        public int stackItem(int num)
        {              
            stack += num;
            if ( stack > maxStack )
            {
                int remain = maxStack - stack;
                stack = maxStack;

                return remain;
            }
            else return 0;              
        }
    }
}
