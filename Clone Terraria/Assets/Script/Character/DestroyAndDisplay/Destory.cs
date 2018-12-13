using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.BlockAndItem;

namespace Assets.Script.Character
{
    public class Destory : InteractBehavior
    {
        private const  float DIRTDAMAGE        = 1000;//temp
        private const  float DIRT_DESTORY_TIME = 0.6f;//摧毀一塊"泥土"所花的時間(秒)

        private float destroyDamage;
        private Block preBlock;

        public Destory( Camera mainCamera ,Terrain terrain ) : base(mainCamera ,terrain)
        {
            destroyDamage = DIRTDAMAGE / DIRT_DESTORY_TIME;//一秒鐘摧毀多少耐久度
            preBlock = null;
        }

        public override void execute()
        {
            base.execute();

            if ( block.isTouchable() )
            {
                if ( preBlock != block && preBlock != null )
                {
                    preBlock.beRelease();
                    preBlock = block;
                }

                ItemEntity dropItem = block.beDestory( computeDestoryDamage() );
                if ( dropItem != null )
                {
                    //放進背包
                }
            }
        }
        private float computeDestoryDamage()
        {
            if ( Tool.Hand == block.blockProperty.tool )//根據player的工具判斷
            {
                destroyDamage += 0.5f * (int)ToolLevel.None;//根據player的工具等級判斷
            }
            else
            {
                destroyDamage *= 0.5f;
            }

            return destroyDamage;
        }
    }
}
