using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGrow : MonoBehaviour {

	private Rigidbody2D rb2d;
	public Transform burr;
	public SnowBurrController controller;
	public SnowBar bar;

	public float increment = 0.5f;

	float[] startValue = new float[2];

	// Use this for initialization
	void Start () 
	{
		startValue[0] = burr.localScale.x;
		startValue[1] = burr.localScale.y;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		grow(burr);
		
	}

	public void grow(Transform growth)
	{
		if(controller.faceRight == true && bar.snowMax >= ScoreManager.score)
			growth.localScale = new Vector3((startValue[0] + (ScoreManager.score * increment)), (startValue[1] + (ScoreManager.score * increment)), 1);

		else if(controller.faceRight == false && bar.snowMax >= ScoreManager.score)
			growth.localScale = new Vector3(-(startValue[0] + (ScoreManager.score * increment)), (startValue[1] + (ScoreManager.score * increment)), 1);

		else if(controller.faceRight == true && bar.snowMax < ScoreManager.score)
			growth.localScale = new Vector3((startValue[0] + (bar.snowMax * increment)), (startValue[1] + (bar.snowMax * increment)), 1);
		
		else if(controller.faceRight == false && bar.snowMax < ScoreManager.score)
			growth.localScale = new Vector3(-(startValue[0] + (bar.snowMax * increment)), (startValue[1] + (bar.snowMax * increment)), 1);
	}
}
