using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBurrController : MonoBehaviour {

    public float force;             //Floating point variable to store the player's movement speed.
    public float maxSpeed;
    public float acceleration;
    public float jumpHeight;
	public bool faceRight = true;
    public float characterOffset;
    Animator animationSpeed;
    public bool isGrounded = false;
	private bool hasJumped = false;
	public Transform groundCheck;
	public Transform groundCheck2;
	public Transform groundCheck3;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
    private float speedVelocity;


    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Use this for initialization
    void Start()
    {
        // Speed variable for animations
		animationSpeed = GetComponent<Animator>();

        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {

        // check to see if on the ground
		if((Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround)) || (Physics2D.OverlapCircle(groundCheck2.position, groundRadius, whatIsGround)) 
			|| (Physics2D.OverlapCircle(groundCheck3.position, groundRadius, whatIsGround)))
				isGrounded = true;
		else isGrounded = false;

		animationSpeed.SetBool ("Ground", isGrounded);

		if(isGrounded)
			hasJumped = false;

		// falling animation cues
		animationSpeed.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);


		// character jump and double jump code.
		if((isGrounded || !hasJumped) && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			animationSpeed.SetBool("Ground", false);

			if(!hasJumped && !isGrounded)
				hasJumped = true;
			
		}
		
		// if pressing both, do nothing
		if ((Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)))
		{
			return;
		}

        //Store the current horizontal input in the float moveHorizontal.
        float moveRight = 0;
        float moveLeft = 0;
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveRight += acceleration;
        }
        
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveLeft += acceleration;    
        }

        float moveVertical = 0;

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movementRight = new Vector2 (moveRight, moveVertical);
        Vector2 movementLeft = new Vector2 (moveLeft, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        if (GetComponent<Rigidbody2D>().velocity.x <= maxSpeed)
        {
            rb2d.AddForce (movementRight * force);
        }

        if (GetComponent<Rigidbody2D>().velocity.x >= -maxSpeed)
        {
            rb2d.AddForce (-movementLeft * force);
        }

        speedVelocity = Input.GetAxis ("Horizontal");
			animationSpeed.SetFloat("speed", Mathf.Abs(speedVelocity));

    }

    void Update ()
    {
        if (GetComponent<Rigidbody2D>().velocity.x > 0.3)
        {
			if(faceRight == true);
			else
			{
				FlipCharacter ();
			}
        }
        
        if (GetComponent<Rigidbody2D>().velocity.x < -0.3)
        {
			if(faceRight == false);
			else
			{
				FlipCharacter ();
			}
        }

    }

    void FlipCharacter ()
		{
			faceRight = !faceRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
			if(faceRight)
			{
				transform.position = new Vector2 ((GetComponent<Rigidbody2D>().position.x + characterOffset),GetComponent<Rigidbody2D>().position.y);
			}
			else if(!faceRight)
			{
				transform.position = new Vector2 ((GetComponent<Rigidbody2D>().position.x - characterOffset),GetComponent<Rigidbody2D>().position.y);
			}
		}
}
