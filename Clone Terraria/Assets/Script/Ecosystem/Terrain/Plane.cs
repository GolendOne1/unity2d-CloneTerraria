using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.BlockAndItem;

public class Plane : Terrain
{
    public Plane( int width = 100 ,int maxHeight = 20 ,int minFloor = 20/*seaLevel*/ ) : base(width ,maxHeight ,minFloor)
    {
        blocks = new Block[width * CEILING];//new Block[width * maxHeight];

        Vector3 startPosition = new Vector3(-1.0f * width/2 ,0.0f) ;
        Vector3 endPosition   = new Vector3( 1.0f * width/2 ,0.0f);

        Vector3 dir    = endPosition - startPosition;
        float interval = dir.magnitude / width;//(width + 1);
        dir.Normalize();

        //設定地圖
        string blockName;
        int offset = CEILING/2 - 1;//256;

        for ( int i = 0 ; i < maxHeight ; i++ )
        {
            for ( int j = 0 ; j < width ; j++ )
            {
                blockName = string.Format("block({0} ,{1})" ,j ,-i);
                Vector2 pos = new Vector2(( startPosition + dir * interval * j ).x ,-i );

                if ( i == 0 )
                    blocks[( offset + i ) * width + j] = new Block(blockName ,pos ,"Grass");
                else if ( i <= 3 )
                    blocks[( offset + i ) * width + j] = new Block(blockName ,pos ,"Dirt");
                else
                {
                    int n = UnityEngine.Random.Range(0, 100) % 2;

                    switch ( n )
                    {
                        case 0:
                            blocks[( offset + i ) * width + j] = new Block(blockName ,pos ,"Dirt");
                            break;
                        case 1:
                            blocks[( offset + i ) * width + j] = new Block(blockName ,pos ,"Stone");
                            break;
                    }
                }
            }
        }

        //剩下填成空氣
        for ( int i = 0 ; i < CEILING ; i++ )
        {
            for ( int j = 0 ; j < width ; j++ )
            {
                if ( blocks[i * width + j] == null )
                {
                    blockName = string.Format("block({0} ,{1})" ,j ,CEILING / 2 - i);
                    Vector2 pos = new Vector2(( startPosition + dir * interval * j ).x ,CEILING/2 -i );

                    blocks[i * width + j] = new Block(blockName ,pos ,"Air");
                }
            }
        }
        Debug.Log("create Done");
    }
}
