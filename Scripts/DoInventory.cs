using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DoInventory : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Inventory;
    public void doinventory()
    {
        Inventory.SetActive(true);
        Menu.SetActive(false);
        
    }
}
