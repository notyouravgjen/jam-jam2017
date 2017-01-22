using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {

	public KeyCode handKey;

	public int rotationAngle;

	private bool handsDown;

	// Use this for initialization
	void Start ()
	{
		handsDown = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!GameManager.instance.interactionDisabled)
		{
			if (Input.GetKeyDown(handKey) && !handsDown)
			{
				transform.Rotate(rotationAngle, 0, 0);
				handsDown = true;
			}
			else if (Input.GetKeyUp(handKey) && handsDown)
			{
				transform.Rotate(rotationAngle * -1, 0, 0);
				handsDown = false;
			}
		}
		else if (handsDown)
		{
			transform.Rotate(rotationAngle * -1, 0, 0);
			handsDown = false;
		}
	}
}
