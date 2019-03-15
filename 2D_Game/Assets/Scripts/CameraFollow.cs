using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

public Transform player;
public Vector3 cameraOffset;
public SnowBurrController burr;
public float characterOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// follows the player plus an offset
		// need to add code to make more smooth
		if(burr.faceRight == true)
		{
			transform.position = new Vector3 (player.position.x + cameraOffset.x - characterOffset, player.position.y + cameraOffset.y, player.position.z + cameraOffset.z);
		}
		if(burr.faceRight == false)
		{
			transform.position = new Vector3 (player.position.x + cameraOffset.x + characterOffset, player.position.y + cameraOffset.y, player.position.z + cameraOffset.z);
		}

	}
}
