using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functionshw1 : MonoBehaviour {

	// Public stream to designate the pet name
	public string petName;

	// Use this for initialization
	void Start () 
	{ 
		Pet(petName);
	}
	
	// Prints a comment based on the pet given
	void Pet(string petState)
	{

		if(petState == "Cat")
		{
			print("Kitty cuddles are good cuddles!");
		}
		else if(petState == "Dog")
		{
			print("Man's best friend!");
		}
		else if(petState == "Bird")
		{
			print("A fine feather friend!");
		}
		else if(petState == "Burb")
		{
			print("Very stylish feathery friend!");
		}
		else if(petState == "Dragon")
		{
			print("Yeah, sure... right...");
		}
		else
		{
			print(petState + " is quite an exotic pet!");
		}
	}
}
