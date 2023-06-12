using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GRADOOPCJI : MonoBehaviour
{
    public GameObject tytul;
    public GameObject back;
    public GameObject mainmenu;
    public GameObject Inventory;
    public void opcje()
    {
        tytul.SetActive(true);
        back.SetActive(true);
        mainmenu.SetActive(false);
        gameObject.SetActive(false);
        Inventory.SetActive(false);
    }
}
