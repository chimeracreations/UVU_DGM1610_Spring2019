using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBar : MonoBehaviour 
{

	public Transform snowBar;

	public float snowMax;

	float fraction; 

	float startLocal;

	// Use this for initialization
	void Start () 
	{
		fraction = 1 / snowMax;
		startLocal = snowBar.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (ScoreManager.score <= snowMax && ScoreManager.score >= 0)
		{
			snowBar.transform.localScale = new Vector3((startLocal * (fraction * ScoreManager.score)), snowBar.transform.localScale.y, 1);
		}

		if (ScoreManager.score >= 10)
			snowBar.transform.localScale = new Vector3(startLocal, snowBar.transform.localScale.y, 1);
	}
}
