using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.BlockAndItem
{
    public class BlockEntity : Block
    {
        protected static string imagePath = "tempImage/";
        protected GameObject blockEntityObject;

        public BlockEntity( string objectName ,Vector2 position ,string name ) : base(name)
        {
            blockEntityObject = new GameObject(objectName);

            blockEntityObject.AddComponent<SpriteRenderer>();
            blockEntityObject.transform.position = position;


            if ( blockDictionary.Dictionary[name].isAir )
            {
                blockEntityObject.layer = LayerMask.NameToLayer("Air");
                blockEntityObject.GetComponent<SpriteRenderer>().sprite = null;
            }
            else
            {
                blockEntityObject.layer = LayerMask.NameToLayer("Block");
                blockEntityObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(imagePath + name);
            }

            blockEntityObject.AddComponent<BoxCollider2D>().size = new Vector2(1 ,1);
        }

        public ItemEntity beDestory( float destroyDamage)
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
                    return new ItemEntity(blockEntityObject.name + " " + itemName ,Vector2.zero ,itemName);
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

        public override void transformBlock( string name = "Air" )//也許不能用?
        {
            base.transformBlock(name);

            if ( blockDictionary.Dictionary[name].isAir )
            {
                blockEntityObject.layer = LayerMask.NameToLayer("Air");
                blockEntityObject.GetComponent<SpriteRenderer>().sprite = null;
            }
            else
            {
                blockEntityObject.layer = LayerMask.NameToLayer("Block");
                blockEntityObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(imagePath + name);
            }
        }
    }
}