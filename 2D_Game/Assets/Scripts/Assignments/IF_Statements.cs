using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IF_Statements : MonoBehaviour {

	public string stopLight;
	public bool isUtah = false;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(stopLight == "red")
		{
			if(!isUtah)
			{
				print("stop");
			}
			else
			{
				print("STOP YOU FOOL!");
			}

		}	
		else if((stopLight == "yellow") && (!isUtah))
		{
			print("caution");
		}
		else if((stopLight == "yellow") && (isUtah))
		{
			print("SLOW DOWN OR YOU'LL KILL SOMEONE!");
		}
		else
		{
			print("go");
		}
	}
}
