using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  
    void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<enemyhealthbehaviour>();
        if (enemy)
        {
            enemy.takehit(1);
            
        }

        Destroy(gameObject);
    }
    private void Update()
    {
        Destroy(gameObject, 5f);
    }

}
