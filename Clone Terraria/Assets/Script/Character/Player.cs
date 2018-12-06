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

        public MoveBehavior MoveBehavior
        {
            get { return moveBehavior; }
        }

        public Player( MoveBehavior moveBehavior ,List<InteractBehavior> interactBehavior )
        {
            this.moveBehavior     = moveBehavior;
            this.interactBehavior = interactBehavior;
        }

        public void move()
        {
            moveBehavior.computeVelocity();
        }
        public void interactWithBlock()
        {
            for(int i = 0 ; i < interactBehavior.Count ; i++ )
            {
                interactBehavior[i].execute();
            }
        }
    }
}
