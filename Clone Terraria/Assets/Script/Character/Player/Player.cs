using Assets.Script.Character.Movement;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Character
{
    public class Player
    {
        private MoveBehavior moveBehavior;
        private List<InteractBehavior> interactBehavior;
        private GameObject gameObject;

        public GameObject Entity
        {
            get { return gameObject; }
        }

        public Player(List<InteractBehavior> interactBehavior)
        {
            gameObject = Resources.Load<GameObject>("Prefab/MainCharacter");
            gameObject = GameObject.Instantiate(gameObject);
            gameObject.transform.name = "MainCharacter";

            this.moveBehavior = new PhysicsMovement(gameObject);
            this.interactBehavior = interactBehavior;

            gameObject.GetComponent<PlayerController>().move = this.move;
            gameObject.GetComponent<PlayerController>().interact = this.interactWithBlock;
            gameObject.GetComponent<PlayerController>().computePhysics = this.moveBehavior.computePhysics;
        }

        public void move()
        {
            moveBehavior.computeVelocity();
        }
        public void interactWithBlock()
        {
            for ( int i = 0 ; i < interactBehavior.Count ; i++ )
            {
                interactBehavior[i].execute();
            }
        }
    }
}
