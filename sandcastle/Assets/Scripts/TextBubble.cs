using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBubble : MonoBehaviour {

    public Texture backgroundBubble;
    public string text;
    public GUIStyle textStyle;
    public Rect positionAndSize;
    public ActivatedTextBubbles.Trigger triggersOn; 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Display()
    {
        GUI.Label(positionAndSize, backgroundBubble);
        GUI.Label(positionAndSize, text, textStyle);
    }
}
