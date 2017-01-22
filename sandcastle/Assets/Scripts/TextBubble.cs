using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBubble : MonoBehaviour {

    public GameObject backgroundBubble;
    public string text;
    private GUIStyle textStyle;
    public float timeDisplayedInSec=2;
    public float upOffset;
    public float rightOffset;
    public float forwardOffset=1.5f;
    public float width=.25f;
    public float height=.25f;
    public ActivatedTextBubbles.Trigger triggersOn;
    public float textOffset = -.2f;
    public float textXRotate, textYRotate = 90, textZRotate;
    private GameObject displayedBubble;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Display()
    {
        if (displayedBubble == null)
        {
            displayedBubble = Instantiate(backgroundBubble, new Vector3(transform.position.x - forwardOffset, transform.position.y + upOffset, transform.position.z - rightOffset), Quaternion.Euler(90, 0, 90), transform);
            displayedBubble.transform.localScale = new Vector3(width, 1, height);
            GameObject textMeshObject = new GameObject("TextMeshObject");
            TextMesh textMesh = textMeshObject.AddComponent<TextMesh>();
            textMesh.text = text;
            textMeshObject.transform.SetParent(displayedBubble.transform, false);
            textMesh.transform.rotation = Quaternion.Euler(textXRotate, textYRotate, textZRotate);
            textMesh.offsetZ = textOffset;
            textMesh.color = Color.black;
            Destroy(displayedBubble, timeDisplayedInSec);
        }
    }
}
