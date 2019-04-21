using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	public Timer levelTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (levelTime.timer == 0.00f)
		{
			SceneManager.LoadScene(0);
		}
	}
}
