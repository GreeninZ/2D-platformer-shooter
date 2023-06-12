using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NothingMelee : MonoBehaviour
{
    public float attackrange = 0.5f;
    public LayerMask enemylayer;
    public float attackcooldown = 0f;
    public float attackrate = 5f;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && (Time.time >= attackcooldown))
        {
            animator.SetBool("melee", true);
            attackcooldown = Time.time + 1f / attackrate;
        }
        else
        {
            animator.SetBool("melee", false);
        }
    }
}
