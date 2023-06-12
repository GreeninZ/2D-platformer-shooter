using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public float movespeed = 7f;
    private Transform player;
    private Vector2 target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, movespeed * Time.deltaTime); 
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }

        Destroy(gameObject, 3f);
        
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<playerhealthbehaviour>();
        if (player)
        {
            player.takehit(1);

        }
        Destroy(gameObject);
    }

}
