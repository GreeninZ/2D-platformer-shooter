using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealthbehaviour : MonoBehaviour
{
    public float hitpoints;
    public float MaxHitpoints = 5;
    public healthbarbehaviour Healthbar;
    void Start()
    {
        hitpoints = MaxHitpoints;
        Healthbar.sethealth(hitpoints, MaxHitpoints);
    }

    public void takehit(float damage)
    {
        hitpoints -= damage;
        Healthbar.sethealth(hitpoints, MaxHitpoints);
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
