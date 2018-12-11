using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Character;
using Assets.Script.Character.Movement;

namespace Assets.Script
{
    class World : MonoBehaviour
    {
        public Terrain terrain;
        public Player     player;
        public MainCamera mainCamera;

        public void Start()
        {
            terrain = new Plane();
            createPlayer();

            mainCamera = new MainCamera(gameObject ,player.Entity);
        }
        public void LateUpdate()
        {
            mainCamera.computeCamera();
        }


        private void createPlayer()
        {
            List<InteractBehavior> interactBehavior = new List<InteractBehavior>();
            interactBehavior.Add(new Destory(gameObject.GetComponent<Camera>() ,terrain));

            player = new Player(interactBehavior);
        }
    }
}
