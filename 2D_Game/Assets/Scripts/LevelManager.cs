using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckPoint;
	private Rigidbody2D pcRigid;
	
	private GameObject player;

	// Particles are fun
	public GameObject deathParticle;
	public GameObject respawnParticle;

	//Respawn delay
	public float respawnDelay;


	//Point penalty on death
	public int pointPenaltyOnDeath;
	
	// Store gravity value
	private float gravityStore;


	// Use this for initialization
	void Start () 
	{
		pcRigid = GameObject.Find("SnowBurr").GetComponent<Rigidbody2D>();
		player = GameObject.Find("SnowBurr");
	}
		

}
