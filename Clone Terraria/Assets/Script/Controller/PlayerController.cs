using Assets.Script.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Character
{
    public delegate void ComputePhysics();
    public delegate void Move();
    public delegate void Interact();

    public class PlayerController : MonoBehaviour
    {
        public ComputePhysics computePhysics;
        public Move move;
        public Interact interact;

        void FixedUpdate()
        {
            computePhysics();         
        }
        void Update()
        {
            move();
            interact();
        }
    }
}