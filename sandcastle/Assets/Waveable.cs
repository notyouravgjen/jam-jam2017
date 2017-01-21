using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waveable {

    public int size;
    public float[] wave;
    private Queue<float> currWave;
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
        float f = currWave.Dequeue();
        heightOffsetsTravelingRight.RotateRight();
        heightOffsetsTravelingRight.Set(0, f);
	}

    public float GetOffset(int index)
    {
        return heightOffsetsTravelingLeft.Get(index) + heightOffsetsTravelingRight.Get(index);
    }

    public void AddWave()
    {
        if (currWave.Count > 0)
        {
            currWave.Clear();
        }
        // wave is queued from the right to left since waving goes to the right
        for (int i=wave.Length-1; i>=0; i--)
        {
            currWave.Enqueue(wave[i]);
        }
    }
}
