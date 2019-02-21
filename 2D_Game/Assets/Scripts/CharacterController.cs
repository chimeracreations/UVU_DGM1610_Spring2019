using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	// Player movement variables
	public float moveSpeed;
	public float jumpHeight;

	// Player grounded variables
	private bool isGrounded;
	private bool hasJumped;

	// Use this for initialization
	void Start () 
	{
		// starts bool variables for jumping
		isGrounded = true;
		hasJumped = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// move the character right when pressing D or Right Arrow
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))	
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		}
		// move the character left if pressing the A or left arrow
		else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))	
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		}
		
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
	}
}
