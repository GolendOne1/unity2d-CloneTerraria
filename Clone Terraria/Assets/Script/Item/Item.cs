using UnityEngine;

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

        private static string imagePath = "tempImage/";
        private GameObject gameObject;

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
        public Item(string objectName ,Vector2 position ,string name) : this(name)
        {
            gameObject = new GameObject(objectName);

            gameObject.AddComponent<SpriteRenderer>();
            gameObject.transform.position = position;

            gameObject.layer = LayerMask.NameToLayer("Item");
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(imagePath + name);

            gameObject.AddComponent<BoxCollider2D>().size = new Vector2(1 ,1);
            gameObject.SetActive(false);//先隱藏
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
        public bool beDestory()//temp
        {
            if ( Input.GetMouseButton(0) )//按下左鍵
            {
                durability -= 1 * Time.deltaTime;
                Debug.Log(" durability: " + durability + "deltadurability: " + 1 * Time.deltaTime);//for test

                if ( durability <= 0 )
                {
                    Debug.Log("tool break");//for test
                    return true;
                }
            }
            return false;
        }
    }
}
