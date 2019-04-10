using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeDropShadow : MonoBehaviour {

	
	public float offset;
	public Transform bee;
	float distance;
	public int layerMask = 9;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		RaycastHit2D hit = Physics2D.Raycast(bee.position, -Vector2.up, Mathf.Infinity, layerMask);
        if(hit.collider != null)
		{
			distance = Mathf.Abs(hit.point.y - bee.position.y);
		}

		transform.position = new Vector3 (bee.position.x, bee.position.y - offset - distance, bee.position.z);
		
		var slopeRotation = Quaternion.FromToRotation (transform.up, hit.normal);

		transform.rotation = Quaternion.Slerp(transform.rotation, slopeRotation * transform.rotation, 10 * Time.deltaTime);
	
	}
}
