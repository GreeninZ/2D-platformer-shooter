using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    private playerhealthbehaviour playerhealth;
    // Start is called before the first frame update
    void Start()
    {
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerhealthbehaviour>();
    }

    // Update is called once per frame
    public void heal()
    {
        Debug.Log(playerhealthbehaviour.instance.hitpoints);
        playerhealthbehaviour.instance.hitpoints += 5;
        Destroy(gameObject);
    }
}
