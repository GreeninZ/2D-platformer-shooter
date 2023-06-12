using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpboost : MonoBehaviour
{
    private poruszanie poruszanie;


    // Start is called before the first frame update
    void Start()
    {

        poruszanie = GameObject.FindGameObjectWithTag("Player").GetComponent<poruszanie>();
    }
    public void jump()
    {
        poruszanie.instance.jumpforce = 20f;
        
        Destroy(gameObject);
    }
}
