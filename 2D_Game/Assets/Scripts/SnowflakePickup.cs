using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakePickup : MonoBehaviour {

	public int snowValue;

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name == "SnowBurr")
		{
			print("You've collected the coin!");

			Destroy(gameObject);
		}
	}
	
}
