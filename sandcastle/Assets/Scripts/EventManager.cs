using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {
    public delegate void DamageThings(float damage);
    public static event DamageThings DamageEvent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void BroadcastDamageThings(float damage)
    {
        if (DamageEvent != null)
        {
            DamageEvent(damage);
        }
    }
}
