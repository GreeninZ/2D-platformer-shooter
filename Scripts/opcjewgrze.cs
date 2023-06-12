using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class opcjewgrze : MonoBehaviour
{
    public GameObject opcjemenu;
    public Object_Active_Changer Object_Active_Changer;
    public bool cando;
    // Start is called before the first frame update
    public void Awake()
    {
        Object_Active_Changer = GameObject.FindObjectOfType<Object_Active_Changer>();
    }
    public void przycisk()
    {
        
        opcjemenu.SetActive(true);
        gameObject.SetActive(false);
        cando = false;
    }
}
