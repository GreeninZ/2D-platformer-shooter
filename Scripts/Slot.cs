using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i; 
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void Update()
    {
        if (transform.childCount <= 0 )
        {
            inventory.isfull[i] = false;
        }
        else
        {
            inventory.isfull[i] = true;
        }
    }
    public void dropitem()
    {
        foreach(Transform child in transform)
        {
            child.GetComponent<Spawn>().spawnitem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
