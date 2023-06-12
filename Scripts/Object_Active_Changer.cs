using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Active_Changer : MonoBehaviour
{
    public GameObject Object1;
    public GameObject Object2;
    public GameObject rece;
    public GameObject pauza;
    public bool pauzaactive;
    public RiflePickup rifle;
    public ammoCounter ammo;
    public ammo_counter pistolammo;
    public rifle_ammo_counter rifleammo;

    // Start is called before the first frame update
    void Start()
    {
        rifleammo = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<rifle_ammo_counter>();
        pistolammo = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ammo_counter>();
        ammo = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ammoCounter>();
        rifle = GameObject.FindGameObjectWithTag("Rifle").GetComponent<RiflePickup>();
        rece.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.Tab))
        {
            pauza.SetActive(true);

        }
        else
        {
            pauza.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
          
                Object1.SetActive(true);
                Object2.SetActive(false);
            
                
            

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (RiflePickup.instance.canRifle == true)
            { 
                
                Object2.SetActive(true);
                Object1.SetActive(false);
            }

        }
        
        if (Object1.activeSelf == true)
        {
            ammo_counter.instance.pistol = true;
        }
        else
        {
            ammo_counter.instance.pistol = false;

        }
        if (Object2.activeSelf == true)
        {
            rifle_ammo_counter.instance.rifle = true;
        }
        else
        {
            rifle_ammo_counter.instance.rifle = false;

        }

        /*if(Object1.activeSelf == false && Object2.activeSelf == false)
        {
            rece.SetActive(true);
        }
        else
        {
            rece.SetActive(false);
        }*/
    }
  
}
