using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waveable {

    public int size;
    private RandomAccessCircularArray<float> heightOffsetsTravelingRight; // Delta height from defaultHeight that should moving right
    private RandomAccessCircularArray<float> heightOffsetsTravelingLeft;  // Delta height from defaultHeight that is moving left

	//Constructor
	public Waveable (int size) {
        this.size = size;
        heightOffsetsTravelingRight = new RandomAccessCircularArray<float>(size, 0);
        heightOffsetsTravelingLeft = new RandomAccessCircularArray<float>(size, 0);
    }
	
	// Update should be called once per frame manually
	public void Update () {
        heightOffsetsTravelingRight.Set(0, 1f);
	}

    public float GetOffset(int index)
    {
        return heightOffsetsTravelingLeft.Get(index) + heightOffsetsTravelingRight.Get(index);
    }
}
