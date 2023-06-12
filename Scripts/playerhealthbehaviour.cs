using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealthbehaviour : MonoBehaviour
{
    public float hitpoints;
    public float MaxHitpoints = 5;
    public playerhealthbarbehaviour Healthbar;
    public DeathScreen deathscreen;
    public poruszanie poruszanie;
    public static playerhealthbehaviour instance;
    public playeraimweapon playeraimweapon;
    void Start()
    {
        instance = this;    
        hitpoints = MaxHitpoints;
        Healthbar.setmaxhealth(hitpoints);
    }
    private void Awake()
    {
        poruszanie = GameObject.FindObjectOfType<poruszanie>();
        deathscreen = GameObject.FindObjectOfType<DeathScreen>();
        playeraimweapon = GameObject.FindObjectOfType<playeraimweapon>();

    }

    public void takehit(float damage)
    {
        hitpoints -= damage;
        Healthbar.sethealth(hitpoints);
        if (hitpoints <= 0)
        {
            
        }
    }
    private void Update()
    {
        
        Healthbar.sethealth(hitpoints);
        if (hitpoints > MaxHitpoints)
        {
            hitpoints = MaxHitpoints;
        }
        poruszanie.zycie(hitpoints);
        
        deathscreen.zycie(hitpoints);
        playeraimweapon.zycie(hitpoints);
        if (transform.position.y < -25f)
        {
            hitpoints = 0;
        }
    }
}
