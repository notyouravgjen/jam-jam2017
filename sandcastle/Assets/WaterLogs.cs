using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLogs : MonoBehaviour {
    public int size = 50;
    public Transform waveObject;
    public float waveSpacing;
    private Waveable waveNumbers;
    private Transform[] waves;

	// Use this for initialization
	void Start () {
        waveNumbers = new Waveable(size);
        waves = new Transform[size];
        for(int i=0; i < size; i++)
        {
            float xOffset = i * waveSpacing;
            waves[i] = Instantiate(waveObject, new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z), Quaternion.Euler(90, 0, 0), transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
        waveNumbers.Update();
		for(int i=0; i<size; i++)
        {
            Vector3 wavePos = waves[i].transform.position;
            wavePos.y = transform.position.y + waveNumbers.getOffset(i);
            waves[i].transform.position = wavePos;
        }
	}
}
