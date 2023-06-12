using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiflePickup : MonoBehaviour
{
    public bool canRifle = false;
    public static RiflePickup instance;
    private void Start()
    {
        instance = this;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canRifle = true;
            Destroy(gameObject);
        }
    }
}
