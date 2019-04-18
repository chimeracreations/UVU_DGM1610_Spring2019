using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour {

	public GameObject nextLevel;
	public GameObject lastLevel;
	public SnowBurrController burr;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (burr.faceRight == true)
		{
			nextLevel.SetActive(true);
			lastLevel.SetActive(false);
		}
		if (burr.faceRight == false)
		{
			nextLevel.SetActive(false);
			lastLevel.SetActive(true);
		}
	}
}
