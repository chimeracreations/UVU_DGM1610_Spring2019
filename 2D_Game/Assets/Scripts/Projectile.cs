using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed;
	public float timeOut;
	public SnowBurrController burr;
	public GameObject player;
	public GameObject enemyDeath;
	public GameObject projectileParticle;
	public int pointsForKill;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("SnowBurrGO");

		enemyDeath = Resources.Load("Prefabs/PS") as GameObject;

		projectileParticle = Resources.Load("Prefabs/PS") as GameObject;

		if(player.transform.localScale.x < 0)
			speed = -speed;

		// Destroys projectile after x seconds
		Destroy(gameObject, timeOut);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		// Destroys enemy on contact with projectile and adds points
		if(other.tag == "Enemy")
		{
			Instantiate(enemyDeath, other.transform.position, other.transform.rotation);


			Destroy(other.gameObject);
			Destroy(transform.parent.gameObject);
			ScoreManager.AddPoints(pointsForKill);
		}
		//Instatiate(projectileParticle, transform.position, transform.roation);
		Destroy(gameObject);
	}
	// OnCollision with object in environment
	void OnCollisionEnter2D(Collision2D other)
	{
		Instantiate(projectileParticle, transform.position, transform.rotation);
		Destroy (gameObject);
	}
	
}
