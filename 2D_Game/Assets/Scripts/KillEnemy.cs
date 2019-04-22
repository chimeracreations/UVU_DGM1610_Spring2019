using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour {

	public GameObject enemy;
	public GameObject shadow;
	public float delay = 0f;
	public GameObject burr;
	public float velocityCheck = .5f;
	public SnowBurrController burrController;
	public int pointsForKill;
	public LevelManager manage;
	Animator anim;
 
    // Use this for initialization
    void Start () 
	{
		anim = GetComponent<Animator>();
		anim.SetBool ("dead", false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == ("Player") && burr.GetComponent<Rigidbody2D>().velocity.y < velocityCheck)
		{
			if (enemy.name == "IceBee")
				Destroy (enemy.GetComponent<IceBeeMovement>());
			anim.SetBool ("dead", true);
			StartCoroutine(DeathAfterTime(0.5f));
			burr.GetComponent<Rigidbody2D>().velocity = new Vector2(burr.GetComponent<Rigidbody2D>().velocity.x, burrController.jumpHeight);
			if(burrController.isGrounded == false)
				manage.enemyMultiplier++;
			ScoreManager.AddPoints(pointsForKill * manage.enemyMultiplier * manage.enemyMultiplier);
		}
	}

	IEnumerator DeathAfterTime(float time)
 	{
    	yield return new WaitForSeconds(time);
		Destroy (enemy);
		Destroy (shadow);//, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay); 
		Destroy(transform.parent.gameObject);
 	}
}


