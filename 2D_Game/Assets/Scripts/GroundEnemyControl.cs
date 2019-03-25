using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyControl : MonoBehaviour {

	//Movement Variables
	public float moveSpeed;
	public bool moveRight;

	// Wall Check
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	public bool hittingWall;

	//Edge Check
	public bool notAtEdge;
	public Transform edgeCheck;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

		hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

		if(hittingWall || !notAtEdge)
		{
			moveRight = !moveRight;
		}

		if (moveRight)
		{
			// the transform flips the sprite but will enlarge or shrink to the values in the Vector3
			transform.localScale = new Vector3(-0.2f, 0.2f, 1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else
		{
			transform.localScale = new Vector3(0.2f, 0.2f, 1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		
	}
}
