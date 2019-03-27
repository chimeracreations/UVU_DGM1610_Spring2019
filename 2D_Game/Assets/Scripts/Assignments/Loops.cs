using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour {

	public int bottles = 100;

	public bool isRaining = true;

	// Use this for initialization
	void Start () 
	{
		// For loop
		for(int i=1; i <= bottles; i++)
		{
			print(i + " bottles of whatever you want on the wall");
		}

		// while loop
		while(bottles > 10)
		{
			print("it is raining " + bottles + " bruh");
			bottles--;
		}

		// do while loop
		bool shouldContinue = false;
		do
		{
			print("Hello World");
		}
		while(shouldContinue == true);

		// For Each Loop
		string[] strings = new string[3];

		strings[0] = "first string";
		strings[1] = "second string";
		strings[2] = "third string";
		
		foreach(string item in strings)
		{
			print (item);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
