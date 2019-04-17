using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampBoost : MonoBehaviour {

	public Rigidbody2D rb2D;
	public float rampForce;
	public SnowBurrController burr;

	Vector2 boost;

	// Use this for initialization
	void Start () 
	{
		boost = new Vector2 (rampForce, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{	
		if (col.gameObject.tag == ("Player") && burr.faceRight == true)
			rb2D.AddForce(boost);
	}	

}
