using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public Transform firePoint;
	public GameObject projectile;
	public LevelManager manager;
	public Timer timer;

	// Use this for initialization
	void Start () 
	{
		// Load projectile from prefabs
		projectile = Resources.Load("Prefabs/Projectile") as GameObject;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.E) && manager.honeyNo <= 3 && manager.honeyNo > 0 && timer.timer != 0.00)
		{
			Instantiate(projectile, firePoint.position, firePoint.rotation);
			manager.honeyNo--;
		}
	}
}
