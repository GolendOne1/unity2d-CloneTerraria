using UnityEngine;

namespace Assets.Script.Character.Movement
{
    public abstract class MoveBehavior
    {
        protected Vector2 velocity;
        protected Rigidbody2D rb2d;
        public MoveBehavior(GameObject character)
        {
            rb2d = character.GetComponent<Rigidbody2D>();
        }
        public abstract void computeVelocity();
        public abstract void computePhysics();
    }
}
