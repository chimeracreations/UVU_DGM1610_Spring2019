using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakePickup : GenericPickUp 
{
	public GameObject playerCharacter;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "playerCharacter")
		{
			// collect snowflake
		}
		else
		{
			// dont collect snowflake
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
