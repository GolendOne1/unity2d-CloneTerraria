using UnityEngine;

namespace Assets.Script.Character.Movement
{
    class PhysicsMovement : MoveBehavior
    {
        private PhysicsConstants physicsConstants;
        /*============================================================*/
        protected bool grounded;
        protected Vector2 groundNormal;
        protected ContactFilter2D contactFilter;
        protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];

        protected const float minMoveDistance = 0.001f;
        protected const float shellRadius     = 0.01f;
        protected float minGroundNormalY      = .65f;
        public PhysicsMovement(GameObject character) : base(character)
        {
            physicsConstants = new PhysicsConstants(character);


            contactFilter.useTriggers = false;
            contactFilter.SetLayerMask(LayerMask.GetMask("Block"));
            contactFilter.useLayerMask = true;
        }
        public override void computeVelocity()
        {
            if ( Input.GetButton("Jump") && grounded )
            {
                velocity.y = physicsConstants.VelocityInit;
            }
            else if ( Input.GetButtonUp("Jump") && velocity.y > 0 )
            {
                velocity.y *= 0.5f;
            }
            velocity.x = Input.GetAxis("Horizontal") * PhysicsConstants.MAXSPEED;

            //Debug.Log("character velocity: " + velocity);
        }
        public override void computePhysics()
        {
            velocity.y = ( grounded && velocity.y <= 0 ) ? 0
                                                         : velocity.y + physicsConstants.GravityModifier * Physics2D.gravity.y * Time.deltaTime;

            grounded = false;
            Vector2 deltaPosition = velocity * Time.deltaTime; //速度 * 時間       

            Vector2 moveAlongGround = new Vector2 (groundNormal.y, -groundNormal.x);
            Vector2 move = moveAlongGround * deltaPosition.x;
            movement(move ,false);

            move = Vector2.up * deltaPosition.y;
            movement(move ,true);
        }
        private void movement(Vector2 move ,bool yMovement)
        {
            float distance = move.magnitude;

            if ( distance > minMoveDistance )
            {
                int count = rb2d.Cast (move, contactFilter, hitBuffer, distance + shellRadius);
                for ( int i = 0 ; i < count ; i++ )
                {
                    Vector2 currentNormal = hitBuffer[i].normal;

                    if ( currentNormal.y > minGroundNormalY )
                    {
                        grounded = true;
                        if ( yMovement )
                        {
                            groundNormal = currentNormal;
                            currentNormal.x = 0;
                        }
                    }
                    float projection = Vector2.Dot (velocity, currentNormal);
                    if ( projection < 0 )
                    {
                        velocity -= projection * currentNormal;
                    }

                    float modifiedDistance = hitBuffer[i].distance - shellRadius;
                    distance = ( modifiedDistance < distance ) ? modifiedDistance : distance;
                }
            }
            //Debug.DrawRay(this.rb2d.transform.position ,move * 10 ,Color.blue);

            rb2d.position += move.normalized * distance;
        }
    }
}