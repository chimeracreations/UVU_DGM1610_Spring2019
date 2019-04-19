using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

	private Transform cam;
	private Transform[] layers;
	public float viewArea = 5;
	private int leftIndex;
	private int rightIndex;
	public float backgroundSize;
	public float paralaxSpeed;
	private float lastCamX;
	public float offset;


	// Use this for initialization
	void Start () 
	{
		cam = Camera.main.transform;
		lastCamX = cam.position.x;
		layers = new Transform[transform.childCount];
		for(int i = 0; i < transform.childCount; i++)
			layers[i] = transform.GetChild(i);

		leftIndex = 0;
		rightIndex = layers.Length - 1;
	}
	
	void FixedUpdate ()
	{
		layers[0].position = new Vector3 (layers[0].transform.position.x, cam.position.y + offset, 0);
		layers[1].position = new Vector3 (layers[1].transform.position.x, cam.position.y + offset, 0);
		layers[2].position = new Vector3 (layers[2].transform.position.x, cam.position.y + offset, 0);
		
		
		float changeX = cam.position.x - lastCamX;
		transform.position += Vector3.right * (changeX * paralaxSpeed);
		
		lastCamX = cam.position.x;

		if(cam.position.x < (layers[leftIndex].transform.position.x + viewArea))
			ScrollLeft();
		if(cam.position.x > (layers[rightIndex].transform.position.x - viewArea))
			ScrollRight();
	}

	// Update is called once per frame
	void Update () 
	{	
		
	}

	private void ScrollLeft()
	{
		//int lastRight = rightIndex;
		layers[rightIndex].position = new Vector3 (layers[leftIndex].position.x - backgroundSize, cam.position.y + offset, 0);
		leftIndex = rightIndex;
		rightIndex--;
		if(rightIndex < 0)
			rightIndex = layers.Length - 1;
	}

	private void ScrollRight()
	{
		//int lastLeft = leftIndex;
		layers[leftIndex].position = new Vector3 (layers[leftIndex].position.x + backgroundSize, cam.position.y + offset, 0);
		rightIndex = leftIndex;
		leftIndex++;
		if(leftIndex == layers.Length)
			leftIndex = 0;
	}
}
