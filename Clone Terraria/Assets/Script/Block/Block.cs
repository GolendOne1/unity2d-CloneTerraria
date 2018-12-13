using UnityEngine;

namespace Assets.Script.BlockAndItem
{
    public class Block
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

        private static string imagePath = "tempImage/";
        private GameObject gameObject;
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
        public Block(string objectName ,Vector2 position ,string name) : this(name)
        {
            gameObject = new GameObject(objectName);

            gameObject.AddComponent<SpriteRenderer>();
            gameObject.transform.position = position;


            if ( blockDictionary.Dictionary[name].isAir )
            {
                gameObject.layer = LayerMask.NameToLayer("Air");
                gameObject.GetComponent<SpriteRenderer>().sprite = null;
            }
            else
            {
                gameObject.layer = LayerMask.NameToLayer("Block");
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(imagePath + name);
            }

            gameObject.AddComponent<BoxCollider2D>().size = new Vector2(1 ,1);
        }

        //public virtual void transformBlock( string name )
        //{
        //    blockProperty = blockDictionary.Dictionary[name];
        //    /*
        //    id[0] = blockType.mainNum;
        //    id[1] = blockType.subNum;

        //    this.name  = name;
        //    durability = blockType.durability;
        //    tool       = Tool.Hand;//預設值
        //    */
        //}
        public bool isTouchable()
        {
            return !( blockProperty.mainNum == blockDictionary.Dictionary["Air"].mainNum );
        }

        public ItemEntity beDestory(float destroyDamage)
        {
            if ( Input.GetMouseButton(0) )//按下左鍵
            {
                durability -= (int)Mathf.Round(destroyDamage * Time.deltaTime);
                Debug.Log(" durability: " + durability + "deltadurability: " + (int)( destroyDamage * Time.deltaTime ));//for test

                if ( durability <= 0 )
                {
                    Debug.Log("break");//for test                    
                    string itemName = blockProperty.dropItem;

                    transformBlock();//也許不適合??
                    return new ItemEntity(gameObject.name + " " + itemName ,Vector2.zero ,itemName);
                }
            }
            else if ( Input.GetMouseButtonUp(0) )
            {
                beRelease();
            }
            return null;
        }
        public void beRelease()
        {
            durability = blockProperty.durability;
        }
        public void transformBlock(string name = "Air")//也許不能用?
        {
            blockProperty = blockDictionary.Dictionary[name];

            if ( blockDictionary.Dictionary[name].isAir )
            {
                gameObject.layer = LayerMask.NameToLayer("Air");
                gameObject.GetComponent<SpriteRenderer>().sprite = null;
            }
            else
            {
                gameObject.layer = LayerMask.NameToLayer("Block");
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(imagePath + name);
            }
        }
    }
}