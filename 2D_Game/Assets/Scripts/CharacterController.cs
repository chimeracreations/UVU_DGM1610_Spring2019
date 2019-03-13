using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	
	// Player movement variables
	private float moveSpeed;
	public float setSpeed;
	public float maxSpeed;
	public float setAcceleration;
	private float moveAcceleration;
	public float jumpHeight;
	bool faceRight = true;
	private float speedVelocity;
	public float movementOffset;

	// Animation call
	Animator animationSpeed;

	// Player grounded variables
	private bool isGrounded = false;
	private bool hasJumped = false;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start () 
	{
		// Speed variable for animations
		animationSpeed = GetComponent<Animator>();
		// initialize movement variables
		moveAcceleration = setAcceleration;
		moveSpeed = setSpeed;
	}
	

	// fixed update is called before update
	void FixedUpate ()
	{

	}


	// Update is called once per frame
	void Update () 
	{
		// check to see if on the ground
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		animationSpeed.SetBool ("Ground", isGrounded);

		if(isGrounded)
			hasJumped = false;

		// falling animation cues
		animationSpeed.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);


		// character jump and double jump code.
		// need to fix code to use physics object code for grounded
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
			moveSpeed = setSpeed;
			return;
		}

		// move the character right when pressing D or Right Arrow
		// play with addforce tomorrow
		else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))	
		{	
			moveSpeed += Time.deltaTime * moveAcceleration;
			if (moveSpeed >= maxSpeed)
				moveSpeed = maxSpeed;
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);

			if(faceRight == true);
			else 
			{
				FlipCharacter ();
			}
		}

		// move the character left if pressing the A or left arrow
		else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))	
		{
			moveSpeed += Time.deltaTime * moveAcceleration;
			if (moveSpeed >= maxSpeed)
				moveSpeed = maxSpeed;

			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);

			if(faceRight == false);
			else
			{
				FlipCharacter ();
			}
		}

		else moveSpeed = setSpeed;

		// Animation speed call
			speedVelocity = Input.GetAxis ("Horizontal");
			animationSpeed.SetFloat("speed", Mathf.Abs(speedVelocity));
		
	}
		// flip character if moving left
		void FlipCharacter ()
		{
			faceRight = !faceRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
			if(faceRight)
			{
				transform.position = new Vector2 ((GetComponent<Rigidbody2D>().position.x + movementOffset),GetComponent<Rigidbody2D>().position.y);
			}
			else if(!faceRight)
			{
				transform.position = new Vector2 ((GetComponent<Rigidbody2D>().position.x - movementOffset),GetComponent<Rigidbody2D>().position.y);
			}
		}
	
}
