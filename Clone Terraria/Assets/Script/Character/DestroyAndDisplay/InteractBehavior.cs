using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.BlockAndItem;

namespace Assets.Script.Character
{
    public class InteractBehavior
    {
        private static GameObject cursor;
        private static GameObject frame;
        private Camera  mainCamera;
        private Terrain terrain;

        protected Block block;

        public InteractBehavior( Camera mainCamera ,Terrain terrain )
        {
            this.mainCamera = mainCamera;
            this.terrain = terrain;

            setIndicator();
        }


        public virtual void execute()
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint( new Vector3(Input.mousePosition.x ,Input.mousePosition.y));
            mousePosition.z = 0;

            Vector3 tilePosition  = new Vector3(Mathf.Round(mousePosition.x) ,Mathf.Round(mousePosition.y) ,0);
            updateIndicator(mousePosition ,tilePosition);
            updateBlock(tilePosition);
        }
        private void setIndicator()
        {
            if ( !cursor )
            {
                frame = new GameObject("frame");
                cursor = new GameObject("cursor");

                setIndictorEntity("tempImage/Frame" ,frame);
                setIndictorEntity("tempImage/Cursor" ,cursor);
            }
        }
        private void setIndictorEntity( string path ,GameObject indictor )
        {
            indictor.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
            indictor.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        private void updateIndicator( Vector3 mousePosition ,Vector3 tilePosition )
        {
            cursor.transform.position = mousePosition;
            frame.transform.position = tilePosition;
        }
        private void updateBlock( Vector3 tilePosition )
        {
            tilePosition.y = ( Terrain.CEILING / 2 - 1 ) - tilePosition.y;
            tilePosition.x = tilePosition.x + terrain.Width / 2;

            int index = (int)( tilePosition.x + tilePosition.y * terrain.Width );
            block = terrain.Blocks[index];
        }
    }
}
