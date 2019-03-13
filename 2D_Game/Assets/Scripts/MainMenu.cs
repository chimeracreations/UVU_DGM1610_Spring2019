using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	// Indexed level to load  
	public int levelToLoad;

	// this function loads the scene based on the levelToLoad Variable after button pressed
	public void LoadLevel()
	{
		SceneManager.LoadScene(levelToLoad);
	}

	// Quits the program after button pressed	
	public void LevelExit()
	{
		Application.Quit();
	}
}
