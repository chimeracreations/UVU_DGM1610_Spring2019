using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDrop : MonoBehaviour {

	public float offset;
	public bool isPlayer = true;
	public Transform player;
	public SnowBurrController burr;
	float distance;
	public int layerMask = 9;

	// Use this for initialization
	void Start () {
		if (player.transform == null)
			Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		RaycastHit2D hit = Physics2D.Raycast(player.position, -Vector2.up, Mathf.Infinity, layerMask);
        if(hit.collider != null)
		{
			distance = Mathf.Abs(hit.point.y - player.position.y);
		}
		if (isPlayer == true && burr.isGrounded == true)	
			transform.position = new Vector3 (player.position.x, player.position.y - distance, player.position.z);

		else
			transform.position = new Vector3 (player.position.x, player.position.y - offset - distance, player.position.z);
		
		var slopeRotation = Quaternion.FromToRotation (transform.up, hit.normal);

		transform.rotation = Quaternion.Slerp(transform.rotation, slopeRotation * transform.rotation, 15 * Time.deltaTime);

	}

}
