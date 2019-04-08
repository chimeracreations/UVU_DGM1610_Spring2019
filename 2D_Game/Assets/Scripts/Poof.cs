using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poof : MonoBehaviour {

	public ParticleSystem poof1;
	public ParticleSystem poof2;
	public Transform poof1t;
	public Transform poof2t;
	public Transform player;
	public SnowBurrController burr;
	public float offsetX;
	public float offsetY;
	float[] startValue = new float[2];
	public float sizeIncrement = 0.5f;
	

	// Use this for initialization
	void Start () 
	{
		startValue[0] = poof1t.localScale.x;
		startValue[1] = poof1t.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == ("Ground") && burr.poofCheck == false)
        {
			poof1t.position = new Vector3 (player.position.x + offsetX + (ScoreManager.score * sizeIncrement /2), player.position.y + offsetY, player.position.z);
			poof2t.position = new Vector3 (player.position.x - offsetX - (ScoreManager.score * sizeIncrement /2), player.position.y + offsetY, player.position.z);
			poof1t.GetComponent<Rigidbody2D>().velocity = new Vector2 (player.GetComponent<Rigidbody2D>().velocity.x / 2, 0);
			poof2t.GetComponent<Rigidbody2D>().velocity = new Vector2 (player.GetComponent<Rigidbody2D>().velocity.x / 2, 0);
			poof1t.localScale = new Vector3((startValue[0] + (ScoreManager.score * sizeIncrement)), 1, (startValue[1] + (ScoreManager.score * sizeIncrement)));
			poof2t.localScale = new Vector3((startValue[0] + (ScoreManager.score * sizeIncrement)), 1, (startValue[1] + (ScoreManager.score * sizeIncrement)));
			

            poof1.Emit(1);
            poof2.Emit(1);
            burr.poofCheck = true;
        }
    }
}
