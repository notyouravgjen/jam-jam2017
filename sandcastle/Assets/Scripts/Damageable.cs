using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour {
    public float damageThreshold = 2.0f;
    private bool wasRecentlyHit = false;
    private TieredAnimation myTieredAnimation;

	// Use this for initialization
	void Start () {
        EventManager.DamageEvent += TakeDamage;
        myTieredAnimation = gameObject.GetComponentInChildren<TieredAnimation>();
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
                bool destroyed = myTieredAnimation.AdvanceStage();
                if(destroyed)
                {
                    TriggerDestruction();
                }
            }
            wasRecentlyHit = true;
            Debug.Log("damage: " + damage + " exceeded threshold, Health was hit");
        }
        else
        {
            wasRecentlyHit = false;
        }
    }

    void TriggerDestruction()
    {
        Debug.Log("Target Destroyed");
    }

    void OnDestroy()
    {
        EventManager.DamageEvent -= TakeDamage;
        Debug.Log("Cleaned up my DamageEvent");
    }
}
