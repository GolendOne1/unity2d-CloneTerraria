using System.Collections;
using System.Collections.Generic;

namespace Assets.Script.BlockAndItem
{
    public abstract class Block
    {
        //public const  int MAXDAMAGE = 1000;//temp
        public static BlockDictionary blockDictionary = new BlockDictionary();

        /*
        protected Tool tool;
        protected int[] id;

        protected string name;
        protected int durability;
        */
        public BlockProperty blockProperty;
        protected int durability;
        /*
        public Tool Tool
        {
            get{return tool;}
        }
        */
        public Block( string name )
        {
            blockProperty = blockDictionary.Dictionary[name];
            durability    = blockProperty.durability;
            /*
            id = new int[2];

            BlockProperty blockType = blockDictionary.Dictionary[name];
            id[0] = blockType.mainNum;
            id[1] = blockType.subNum;

            this.name  = name;
            durability = blockType.durability;
            tool       = Tool.Hand;//預設值
            */
        }

        public virtual void transformBlock( string name )
        {
            blockProperty = blockDictionary.Dictionary[name];
            /*
            id[0] = blockType.mainNum;
            id[1] = blockType.subNum;

            this.name  = name;
            durability = blockType.durability;
            tool       = Tool.Hand;//預設值
            */
        }
        public bool isTouchable()
        {
            return !( blockProperty.mainNum == blockDictionary.Dictionary["Air"].mainNum );
        }
    }
}