using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera
{
    private GameObject camera;
    private GameObject player;
    private Vector3    offset;

    private Vector3 velocity;
    bool change;

    public MainCamera( GameObject camera ,GameObject player )
    {
        this.camera = camera;
        this.player = player;
        change = false;

        offset = this.camera.transform.position - this.player.transform.position;
    }
    public void computeCamera()
    {
        neededToChange();
        changePosition();
    }
    private void neededToChange()
    {
        if ( !change )
        {
            change = ( player.transform.position.y < camera.transform.position.y - 5 ||
                       player.transform.position.y > camera.transform.position.y + 5 );

            velocity = ( player.transform.position - camera.transform.position ) * 2f;
        }
        else
        {
            change = !( player.transform.position.y <= camera.transform.position.y + 2 &&
                        player.transform.position.y >= camera.transform.position.y - 2 );

            if ( change )
            {
                Vector3 velocityTemp = ( player.transform.position - camera.transform.position )* 2f;
                velocity = ( Vector3.Dot(velocityTemp ,velocity) < 0 ) ? velocityTemp : velocity;
            }
        }
    }
    private void changePosition()
    {
        camera.transform.position = new Vector3(player.transform.position.x ,camera.transform.position.y ,0) + offset;
        if ( change )
        {
            camera.transform.position += new Vector3(0 ,velocity.y * Time.deltaTime);
        }
    }
}
