using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObjects : MonoBehaviour {

	// Variables needed for physics control

	// minGroundNormalY determines the angle of being grounded. Use to get the slope right.
	public float minGroundNormalY = .65f;

	// modifies gravity strength
    public float gravityModifier = 1f;

	// the velocity of the target
    protected Vector2 targetVelocity;

	// bool to signal if object is grounded or not
    protected bool grounded;

    protected Vector2 groundNormal;

	// Rigidbody call to work with rigidbodies
    protected Rigidbody2D rb2d;

    protected Vector2 velocity;

    protected ContactFilter2D contactFilter;

	// settign up a buffer to not go crazy with all the hits
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];

	// stores the results for the hitbuffer when it actually hits
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D> (16);

	// variable used to check if there are collisions 
    protected const float minMoveDistance = 0.001f;

	// sets up a radius to give distance between colliders to prevent getting colliders stuck
    protected const float shellRadius = 0.01f;

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    void Start () 
    {
		// detect collisions by using physics2D settings
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask (Physics2D.GetLayerCollisionMask (gameObject.layer));
        contactFilter.useLayerMask = true;
    }
    
    void Update () 
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity (); 
    }

    protected virtual void ComputeVelocity()
    {
    
    }

    void FixedUpdate()
    {
		// Gravity coding
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.x = targetVelocity.x;

		// grounded is always false unless a collision is registered
        grounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 moveAlongGround = new Vector2 (groundNormal.y, -groundNormal.x);

		// Horrizontal movement
        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement (move, false);

		// Verticle movement
        move = Vector2.up * deltaPosition.y;

        Movement (move, true);
    }

	// Used in fixed update to Move the character and determine if touching other colliders for grounded functionality
    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance) 
        {
			// stores results of collitions that touch within a determined distance
            int count = rb2d.Cast (move, contactFilter, hitBuffer, distance + shellRadius);
			// initial clear of the list to prevent old info
            hitBufferList.Clear ();
			// adds collision hits to the hitbuffer list
            for (int i = 0; i < count; i++) {
                hitBufferList.Add (hitBuffer [i]);
            }
			// compare the angle of the collisions
            for (int i = 0; i < hitBufferList.Count; i++) 
            {
                Vector2 currentNormal = hitBufferList [i].normal;
                if (currentNormal.y > minGroundNormalY) 
                {
					// is grounded if collisions detected from buffer list comparison
                    grounded = true;
                    if (yMovement) 
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }
				// detects the difference between velocity and currentNormal to prevent slowing when colliding
                float projection = Vector2.Dot (velocity, currentNormal);
                if (projection < 0) 
                {
                    velocity = velocity - projection * currentNormal;
                }
				// prevent getting stuck in other colliders
                float modifiedDistance = hitBufferList [i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }


        }
        rb2d.position = rb2d.position + move.normalized * distance;
    }
}
