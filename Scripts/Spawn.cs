using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    public Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void spawnitem()
    {
        Vector2 playerpos = new Vector2(player.position.x -3, player.position.y -1);
        Instantiate(item, playerpos, Quaternion.identity); 
    }
}
