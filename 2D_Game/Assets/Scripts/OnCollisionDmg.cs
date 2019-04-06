using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDmg : MonoBehaviour {

	public SnowBurrController burr;

	public float pushBack = 2f;

	public float pushUp = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == ("Enemy"))
		{
			ScoreManager.score /= 2;

			if (burr.faceRight == true)
			GetComponent<Rigidbody2D>().velocity = new Vector2(-pushBack, GetComponent<Rigidbody2D>().velocity.y + pushUp);

			if (burr.faceRight == false)
			GetComponent<Rigidbody2D>().velocity = new Vector2(pushBack, GetComponent<Rigidbody2D>().velocity.y + pushUp);

		}
	}
}
