using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class przeciwnikruch : MonoBehaviour
{
    public Transform player;
    public bool kierunekwprawo = true;
    public float agrorange;

    
    public float movespeed;


    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Flip()
    {
        kierunekwprawo = !kierunekwprawo; 
        Vector3 skala = gameObject.transform.localScale; 
        skala.x *= -1; 
        gameObject.transform.localScale = skala; 
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > transform.position.x && kierunekwprawo == false)
        {
            Flip();
            kierunekwprawo = true;
        }
        if (player.position.x < transform.position.x && kierunekwprawo == true)
        {
            Flip();
            kierunekwprawo = false;
        }


            float distplayer = Vector2.Distance(player.position, transform.position);

        if(distplayer < agrorange)
        {
            if(transform.position.x < player.position.x)
            {
                rb.velocity = new Vector2(movespeed, 0);
                if (distplayer <= 3f)
                {
                    rb.velocity = new Vector2(0, 0);
                }
            }
            else if (transform.position.x > player.position.x)
            {
                rb.velocity = new Vector2(-movespeed, 0);
                if (distplayer <= 3f)
                {
                    rb.velocity = new Vector2(0, 0);
                }
            }
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            
        }
        
    }

    

}
