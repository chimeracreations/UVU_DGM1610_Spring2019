using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakePickup : MonoBehaviour {

	public int snowValue;
	public int honeyValue;

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name == "SnowBurrGO")
		{
			ScoreManager.AddPoints(snowValue);
			ScoreManager.AddPoints(honeyValue);
			Destroy(gameObject);
		}
	}
	
}
