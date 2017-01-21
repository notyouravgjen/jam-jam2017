using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waveable {

    public int size;
    private float[] heightOffsetsTravelingRight; // Delta height from defaultHeight that should moving right
    private float[] heightOffsetsTravelingLeft;  // Delta height from defaultHeight that is moving left

	//Constructor
	public Waveable (int size) {
        this.size = size;
        heightOffsetsTravelingRight = new float[size];
        heightOffsetsTravelingLeft = new float[size];
    }
	
	// Update should be called once per frame manually
	public void Update () {
		
	}

    public float getOffset(int index)
    {
        return heightOffsetsTravelingLeft[index] + heightOffsetsTravelingRight[index];
    }
}
