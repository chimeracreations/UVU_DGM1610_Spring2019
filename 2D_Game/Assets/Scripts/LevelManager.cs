using System.Collections;
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
	private float gravityScale;


	// Use this for initialization
	void Start () 
	{
		pcRigid = GameObject.Find("SnowBurr").GetComponent<Rigidbody2D>();
		player = GameObject.Find("SnowBurr");
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
		pcRigid.GetComponent<Rigidbody2D>().gravityScale = 0f;
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
		player.GetComponent<Renderer>().enabled = true;
		// Spawn Player
		Instantiate (respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
	}

}
