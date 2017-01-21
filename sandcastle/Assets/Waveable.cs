using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waveable {

    public int size;
    private Queue<float> currWave;
    private RandomAccessCircularArray<float> heightOffsetsTravelingRight; // Delta height from defaultHeight that should moving right
    private RandomAccessCircularArray<float> heightOffsetsTravelingLeft;  // Delta height from defaultHeight that is moving left

	//Constructor
	public Waveable (int size) {
        this.size = size;
        heightOffsetsTravelingRight = new RandomAccessCircularArray<float>(size, 0);
        heightOffsetsTravelingLeft = new RandomAccessCircularArray<float>(size, 0);
        currWave = new Queue<float>();
    }

    // Update should be called once per frame manually
    public void Update() {
        heightOffsetsTravelingRight.RotateRight();
        if (currWave.Count > 0) {
          float f = currWave.Dequeue();
          heightOffsetsTravelingRight.Set(0, f);
        }
	}

    public float GetOffset(int index)
    {
        return heightOffsetsTravelingLeft.Get(index) + heightOffsetsTravelingRight.Get(index);
    }

    public void AddWave(float[] wave)
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
