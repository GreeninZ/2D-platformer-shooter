using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kucanie : MonoBehaviour
{
    public Animator animator;
    public Transform gracz;
    private float attackrange = 2f;
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
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.position = new Vector3(transform.position.x, -0.5f,transform.position.z);
        }
        else
        {
            transform.position = new Vector3(gracz.position.x  - 0.03f, gracz.position.y + 0.1f, gracz.position.z);
        }

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
