using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	public Timer levelTime;
	public GameObject finished;
	public GameObject burr;
	public float timeToStop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (levelTime.timer == 0.00f)
		{
			finished.SetActive(true);
			burr.GetComponent<Rigidbody2D>().isKinematic = true;
			burr.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
			StartCoroutine(StopTime(timeToStop));
		}
	}

	IEnumerator StopTime(float time)
 	{
   		yield return new WaitForSeconds(time);
		burr.GetComponent<Rigidbody2D>().isKinematic = false;
		finished.SetActive(false);
		SceneManager.LoadScene(0);
	}
}
