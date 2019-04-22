using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour {

	private float timer;
	public GameObject cloud;
	public Transform cloudLocation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
     	if (timer <= 0f)
     	{
        	Instantiate(cloud, transform.position, transform.rotation);
        	timer = 18f;
     	}	
	}
}
