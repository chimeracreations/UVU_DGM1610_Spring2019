using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBeeMovement : MonoBehaviour {

	// variables to control the bee position and movement
	public float RotateSpeed = 5f;

    public float Radius = 0.1f;
 
	private Vector2 circleCenter;

    private float angle;


	// Use this for initialization
	void Start () 
	{
		circleCenter = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//adjust angle over time by set rotaion speed
		angle += RotateSpeed * Time.deltaTime;

		// set offset to the position on a circle
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;

		// moves the bee
        transform.position = circleCenter + offset;

	}
}
