using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Script.BlockAndItem
{
    public class BlockProperty
    {
        private const int DIRT_MAX_DURABILITY = 1000;

        public int    mainNum; 
        public int    subNum;  

        public bool   isAir;
        public string dropItem;
        public int    durability;
        public Tool   tool;

        private BlockProperty( int mainNum ,int subNum ,string dropItem ,bool isAir ,int durability ,Tool tool )
        {
            this.mainNum = mainNum;
            this.subNum = subNum;

            this.isAir = isAir;
            this.dropItem = dropItem;
            this.durability = durability;
            this.tool = tool;
        }
        public class Builder
        {
            private int    mainNum;
            private int    subNum;
            private bool   isAir;
            private string dropItem;
            private int    durability;
            private Tool   useTool;

            public Builder( int mainNum ,string dropItem )
            {
                this.mainNum  = mainNum;             
                this.dropItem = dropItem;

                this.subNum     = 0;
                this.isAir      = false;
                this.durability = DIRT_MAX_DURABILITY;
                this.useTool    = Tool.Hand;
            }

            public Builder setMainNum( int mainNum )
            {
                this.mainNum = mainNum;
                return this;
            }
            public Builder setSubNum( int subNum )
            {
                this.subNum = subNum;
                return this;
            }
            public Builder IsAir(bool isAir)
            {
                this.isAir = isAir;
                return this;
            }
            public Builder DropItem(string dropItem )
            {
                this.dropItem = dropItem;
                return this;
            }
            public Builder Durability(float durabilityMul )//比泥土的耐久度多幾倍
            {
                this.durability = (int)(DIRT_MAX_DURABILITY * durabilityMul);
                return this;
            }
            public Builder UseTool( Tool useTool )
            {
                this.useTool = useTool;
                return this;
            }
            public BlockProperty build()
            {
                return new BlockProperty(mainNum ,subNum ,dropItem ,isAir ,durability ,useTool);
            }
        }
    }
    public class BlockDictionary
    {
        private static int count = 0;
        private Dictionary<string, BlockProperty> dictionary;

        public Dictionary<string ,BlockProperty> Dictionary
        {
            get { return dictionary; }
        }

        public BlockDictionary()
        {
            dictionary = new Dictionary<string ,BlockProperty>();

            dictionary.Add("Air"   ,getIdentity("Air" ,"").IsAir(true).build() );
            dictionary.Add("Grass" ,getIdentity("Grass").build());
            dictionary.Add("Dirt"  ,getIdentity("Dirt" ).build());
            dictionary.Add("Stone" ,getIdentity("Stone").build());
        }
        private BlockProperty.Builder getIdentity(string mainTypeName)
        {
            return getIdentity(mainTypeName ,mainTypeName);
        }
        private BlockProperty.Builder getIdentity( string mainTypeName ,string dropItem)
        {
            if ( dictionary.ContainsKey(mainTypeName) )
            {
                return new BlockProperty.Builder(dictionary[mainTypeName].mainNum ,dropItem)
                                       .setSubNum(++dictionary[mainTypeName].subNum);
            }
            else
            {
                return new BlockProperty.Builder(count++ ,dropItem);
            }
        }
    }
}