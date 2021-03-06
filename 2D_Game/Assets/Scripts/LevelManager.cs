﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckPoint;
	private Rigidbody2D pcRigid;
	
	private GameObject player;

	private SnowBurrController burr;

	// Particles are fun
	public GameObject deathParticle;
	public GameObject respawnParticle;

	//Respawn delay
	public float respawnDelay;


	//Point penalty on death
	public int pointPenaltyOnDeath;
	
	// Store gravity value
	private float gravityStore;

	// store enemy kill multiplier
	public int enemyMultiplier = 1;
	public int honeyNo;
	public GameObject honey1;
	public GameObject honey2;
	public GameObject honey3;



	// Use this for initialization
	void Start () 
	{
		pcRigid = GameObject.Find("SnowBurrGO").GetComponent<Rigidbody2D>();
		player = GameObject.Find("SnowBurrGO");
	}

	void Update ()
	{
		if (honeyNo > 3)
			honeyNo = 3;
			
		if (honeyNo == 3)
		{
			honey3.SetActive(true);
			honey2.SetActive(true);
			honey1.SetActive(true);
		}
		if (honeyNo == 2)
		{
			honey3.SetActive(false);
			honey2.SetActive(true);
			honey1.SetActive(true);
		}
		if (honeyNo == 1)
		{
			honey3.SetActive(false);
			honey2.SetActive(false);
			honey1.SetActive(true);
		}
		if (honeyNo == 0)
		{
			honey3.SetActive(false);
			honey2.SetActive(false);
			honey1.SetActive(false);
		}

	}
	
	public void RespawnPlayer()
	{
		StartCoroutine("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo()
	{
		// Generate Death Particle
		Instantiate (deathParticle, pcRigid.transform.position, pcRigid.transform.rotation);
		// Hide pcRigid
		player.SetActive(false);
		player.GetComponent<Renderer>().enabled = false;
		// Gravity Reset
		gravityStore = pcRigid.GetComponent<Rigidbody2D>().gravityScale;
		pcRigid.GetComponent<Rigidbody2D>().gravityScale = 1f;
		pcRigid.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		// Point Penalty
		ScoreManager.AddPoints(-pointPenaltyOnDeath);
		// Debug Message
		yield return new WaitForSeconds (respawnDelay);
		// Gravity Restore
		pcRigid.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
		// Match players Transform position
		pcRigid.transform.position = currentCheckPoint.transform.position;
		// Show Player
		player.SetActive(true);
		yield return new WaitForSeconds (.02f); // Let's the camera catch up
		player.GetComponent<Renderer>().enabled = true;
		// Spawn Player
		Instantiate (respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
	}

}
