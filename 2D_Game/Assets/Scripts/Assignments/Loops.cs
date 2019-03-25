using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour {

	public int bottles = 100;

	public bool isRaining = true;

	// Use this for initialization
	void Start () {
		// For loop
		for(int i=1; i <= bottles; i++)
		{
			print(i + " bottles of whatever you want on the wall");
		}

		while(bottles > 10)
		{
			print("it is raining " + bottles + " bruh");
			bottles--;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
