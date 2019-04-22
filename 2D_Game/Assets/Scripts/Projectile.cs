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

		projectileParticle = Resources.Load("Prefabs/drops") as GameObject;

		if(player.transform.localScale.x < 0)
			speed = -speed;

		// Destroys projectile after x seconds
		Destroy(gameObject, timeOut);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed + player.GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		// Destroys enemy on contact with projectile and adds points
		if(other.gameObject.tag == "Enemy")
		{
			Instantiate(enemyDeath, other.transform.position, other.transform.rotation);
			Destroy(other.transform.parent.gameObject);
			Destroy(other.gameObject);
			ScoreManager.AddPoints(pointsForKill);
		}
		else	
		{
			Instantiate(projectileParticle, transform.position, transform.rotation);
		}
		Destroy(gameObject);
	}


	
}
