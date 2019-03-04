using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	
	// Player movement variables
	public float moveSpeed;
	public float jumpHeight;
	bool faceRight = true;
	private float speedVelocity;
	public float movementOffset;

	// Animation call
	Animator animationSpeed;

	// Player grounded variables
	private bool isGrounded;
	private bool hasJumped;

	// Use this for initialization
	void Start () 
	{
		// starts bool variables for jumping
		isGrounded = true;
		hasJumped = false;

		// Speed variable for animations
		animationSpeed = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// character jump and double jump code.
		if(Input.GetKeyDown(KeyCode.W) && ((isGrounded == true) || (hasJumped == true)))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			if (hasJumped == true)
			{
				hasJumped = false;
			}
			else hasJumped = true;
		}
		else if(Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}
		else if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}


		// if pressing both, do nothing
		if ((Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)))
		{
			return;
		}
		// move the character right when pressing D or Right Arrow
		else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))	
		{
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
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);

			if(faceRight == false);
			else
			{
				FlipCharacter ();
			}

		}
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
