using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymeelee : MonoBehaviour
{
    public Animator animator;
    public Transform meleepoint;
    public float attackrange = 0.5f;
    public LayerMask enemylayer;
    public float attackcooldown = 0f;
    public float attackrate = 5f;
    public float nextactiontime = 2f;
    public float period = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time >= attackcooldown)
        {

            if (Time.time > nextactiontime)
            {
                nextactiontime += period;
                Collider2D[] enemyhit = Physics2D.OverlapCircleAll(meleepoint.position, attackrange, enemylayer);
                foreach (Collider2D enemy in enemyhit)
                {
                    enemy.GetComponent<playerhealthbehaviour>().takehit(2);
                    animator.SetBool("melee", true);
                }
                attackcooldown = Time.time + 1f / attackrate;
                
                

            }
            else
            {
                animator.SetBool("melee", false);
            }


        }

    }
}
