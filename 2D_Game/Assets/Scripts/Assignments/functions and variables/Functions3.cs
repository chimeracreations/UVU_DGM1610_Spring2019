using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions3 : MonoBehaviour {

	public int cookiesNumber; 

	// Use this for initialization
	void Start () 
	{
		print("Let's count cookies with the Count!");
		print(cookiesNumber + " cookie(s) are falling from the sky AH AH AH!");
	}
	
	// Update is called once per frame
	void Update () 
	{
		cookiesNumber += 1;

		print(cookiesNumber + " cookie(s) are falling from the sky AH AH AH!");
	}
}
