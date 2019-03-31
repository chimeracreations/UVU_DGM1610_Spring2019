using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToSlope : MonoBehaviour {

	public int layerMask = 9;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, Mathf.Infinity, layerMask);

		var slopeRotation = Quaternion.FromToRotation (transform.up, hit.normal);

		transform.rotation = Quaternion.Slerp(transform.rotation, slopeRotation * transform.rotation, 10 * Time.deltaTime);
	}
}
