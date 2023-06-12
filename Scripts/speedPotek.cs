using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedPotek : MonoBehaviour
{
    
   
    private poruszanie poruszanie;
    
   
    // Start is called before the first frame update
    void Start()
    {
        
        poruszanie = GameObject.FindGameObjectWithTag("Player").GetComponent<poruszanie>();
    }

    // Update is called once per frame
    public void speedboost()
    {
        poruszanie.instance.speedpotion = true;
        Destroy(gameObject);
        poruszanie.instance.speed = poruszanie.instance.speed * 2;
        
    }

}
