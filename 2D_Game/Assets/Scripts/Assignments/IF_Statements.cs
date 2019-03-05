using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IF_Statements : MonoBehaviour {

	public string stopLight;
	public bool isUtah = false;
	public int first;
	public int second;


	// Use this for initialization
	void Start () {
		
	print(Sum(first, second));

	print(Multi(first,second));

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

	int Sum(int a, int b)
	{
		return a + b;
	}

	int Multi(int c, int d)
	{
		return c * d;
	}
	

}
