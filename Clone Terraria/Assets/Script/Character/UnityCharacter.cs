using Assets.Script.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Character
{
    public class UnityCharacter : MonoBehaviour
    {
        public Player mainCharacter;

        void FixedUpdate()
        {
            mainCharacter.MoveBehavior.computePhysics();          
        }
        void Update()
        {
            mainCharacter.move();
            mainCharacter.interactWithBlock();
        }
    }
}