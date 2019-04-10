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
 
    // Use this for initialization
    void Start () 
	{

    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == ("Player") && burr.GetComponent<Rigidbody2D>().velocity.y < velocityCheck)
		{
			Destroy (enemy);//, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay); 
			Destroy (shadow);//, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay); 
			Destroy(transform.parent.gameObject);
			burr.GetComponent<Rigidbody2D>().velocity = new Vector2(burr.GetComponent<Rigidbody2D>().velocity.x, burrController.jumpHeight);
		}
	}
}
