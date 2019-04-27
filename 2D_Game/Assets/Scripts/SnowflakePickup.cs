using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakePickup : MonoBehaviour {

	public int snowValue;
	public LevelManager manager;
	public GameObject levelManager;
	public bool isHoney;

	void Start ()
	{
		levelManager = GameObject.Find("Level Manager");
		manager = levelManager.GetComponent<LevelManager>();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name == "SnowBurrGO")
		{
			ScoreManager.AddPoints(snowValue);
			if (isHoney)
				manager.honeyNo++;
			Destroy(gameObject);
		}
	}
	
}
