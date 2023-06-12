using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{
    public Transform meleepoint;
    public float attackrange = 0.5f;
    public LayerMask enemylayer;
    public float attackcooldown = 0f;
    public float attackrate = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void atak(float currentstamina)
    {
        if (Time.time >= attackcooldown)
        {

            if (Input.GetKeyDown(KeyCode.V))
            {
                Collider2D[] enemyhit = Physics2D.OverlapCircleAll(meleepoint.position, attackrange, enemylayer);
                foreach (Collider2D enemy in enemyhit)
                {
                    enemy.GetComponent<enemyhealthbehaviour>().takehit(2);
                }
                stamina.instance.jumping(15);
                attackcooldown = Time.time + 1f / attackrate;
            }


        }
    }
}
