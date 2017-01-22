using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {

	public KeyCode handKey;

	public int rotationAngle;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!GameManager.instance.interactionDisabled)
		{
			if (Input.GetKeyDown(handKey))
			{
				transform.Rotate(rotationAngle, 0, 0);
			}
			else if (Input.GetKeyUp(handKey))
			{
				transform.Rotate(rotationAngle * -1, 0, 0);
			}
		}
	}
}
