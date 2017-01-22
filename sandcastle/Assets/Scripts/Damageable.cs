using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour {
    public int healthHits = 1; // number of hits we can take
    public float damageThreshold = 2.0f;
    private bool wasRecentlyHit = false;
    private bool destroyed = false;

	// Use this for initialization
	void Start () {
        EventManager.DamageEvent += TakeDamage;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void TakeDamage(float damage)
    {
        if(damage > damageThreshold)
        {
            if (!wasRecentlyHit)
            {
                healthHits--;
            }
            wasRecentlyHit = true;
            Debug.Log("damage: " + damage + " exceeded threshold, Health was hit");
        }
        else
        {
            wasRecentlyHit = false;
        }
        if (healthHits <= 0 && !destroyed)
        {
            destroyed = true;
            Debug.Log("Target Destroyed");
        }
    }

    void OnDestroy()
    {
        EventManager.DamageEvent -= TakeDamage;
        Debug.Log("Cleaned up my DamageEvent");
    }
}
