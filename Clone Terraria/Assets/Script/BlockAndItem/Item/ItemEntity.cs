using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.BlockAndItem
{
    public class ItemEntity : Item
    {
        protected static string imagePath = "tempImage/";
        protected GameObject itemEntityObject;

        public ItemEntity( string objectName ,Vector2 position ,string name ) : base(name)
        {
            itemEntityObject = new GameObject(objectName);

            itemEntityObject.AddComponent<SpriteRenderer>();
            itemEntityObject.transform.position = position;

            itemEntityObject.layer = LayerMask.NameToLayer("Item");
            itemEntityObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(imagePath + name);

            itemEntityObject.AddComponent<BoxCollider2D>().size = new Vector2(1 ,1);
            itemEntityObject.SetActive(false);//先隱藏
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
