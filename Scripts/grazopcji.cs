using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class grazopcji : MonoBehaviour
{
    public GameObject tytul;
    public GameObject OPTIONS;
    public GameObject mainmenu;
    public GameObject invent;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void opcje()
    {
        tytul.SetActive(false);
        OPTIONS.SetActive(true);
        mainmenu.SetActive(true);
        gameObject.SetActive(false);
        invent.SetActive(true);
    }
}
