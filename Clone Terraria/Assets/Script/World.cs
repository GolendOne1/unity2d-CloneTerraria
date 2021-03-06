﻿using System;
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
        public GameObject playerEntity;

        public MainCamera mainCamera;

        public void Start()
        {
            terrain = new Plane();
            createPlayer();

            mainCamera = new MainCamera(gameObject ,playerEntity);
        }
        private void createPlayer()
        {
            playerEntity = Resources.Load<GameObject>("Prefab/MainCharacter");
            playerEntity = Instantiate(playerEntity);
            playerEntity.transform.name = "MainCharacter";

            List<InteractBehavior> interactBehavior = new List<InteractBehavior>();
            interactBehavior.Add(new Destory(gameObject.GetComponent<Camera>() ,terrain));

            player = new Character.Player(new PhysicsMovement(playerEntity) ,interactBehavior);
            playerEntity.GetComponent<UnityCharacter>().mainCharacter = player;
        }

        void LateUpdate()
        {
            mainCamera.computeCamera();
        }
    }
}
