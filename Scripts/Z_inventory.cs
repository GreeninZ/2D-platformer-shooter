using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_inventory : MonoBehaviour
{
    public GameObject menu;
    public GameObject inventory;
    public void z_inventory()
    {
        menu.SetActive(true);
        inventory.SetActive(false);
    }
}
