using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreReader : MonoBehaviour {
	
	public bool isHighScore;
	public static int score;
	Text scoreText;

	// Use this for initialization
	void Start () 
	{
		//Gets UI text component
		scoreText = GetComponent<Text>();

		score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isHighScore)
			score = PlayerPrefs.GetInt("highscore");

		if (!isHighScore)
			score = PlayerPrefs.GetInt("score");

		scoreText.text = "" + score;	
	}
}