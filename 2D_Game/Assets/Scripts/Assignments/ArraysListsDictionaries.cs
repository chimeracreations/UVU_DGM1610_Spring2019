using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArraysListsDictionaries : MonoBehaviour {

	// Collection of CLient Variables
	public string clientOne = "Greg";
	public string clientTwo = "Kate";
	public string clientThree = "Adam";
	public string clientFour = "Mia";
	public string clientFive = "Fred";

	// Array Example
	public string[] clientList = new string[]{"Greg", "Kate", "Adam", "Mia", "Fred"};

, 	// List Example
	public List<string> santasNaughtyList = new List<string>();

	// ArrayList Example
	public ArrayList inventory = new ArrayList();

	// Use this for initialization
	void Start () {
		santasNaughtyList.Add("Jimmy");
		santasNaughtyList.Add("Jenny");
		santasNaughtyList.Add("Sam");
		santasNaughtyList.Add("Ty");
		santasNaughtyList.Add("Susie");

		santasNaughtyList.Remove("Jimmy");

		print(clientList[2]);
		print(santasNaughtyList[3]);

		inventory.Add(10);
		inventory.Add("Bob");
		inventory.Add(true);
		inventory.Add(5.2234);

		print(inventory[2]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
