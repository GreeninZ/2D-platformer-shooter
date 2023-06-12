using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rifle_ammo_counter : MonoBehaviour
{
    float amunicja;
    float max_amunicja = 25f;
    float firerate = 0.1f;
    float nextfire = 0f;
    public bool rifle = false;
    public static rifle_ammo_counter instance;
    private GUIStyle guiStyle = new GUIStyle();
    private void Start()
    {
        instance = this;
        amunicja = max_amunicja;
    }
    private void OnGUI()
    {
        if (rifle == true)
        {
            guiStyle.fontSize = 20;
            guiStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(42, 62, 80, 20), amunicja + "/" + max_amunicja, guiStyle);
        }
        if (rifle == false)
        {
            guiStyle.fontSize = 20;
            guiStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(42, 62, 80, 20), "", guiStyle);
           
        }

    }
    private void Update()
    {
        
        if (Input.GetMouseButton(0) && Time.time > nextfire && amunicja > 0)
        {
            amunicja -= 1;
            nextfire = Time.time + firerate;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            amunicja = max_amunicja;
        }
    }
}
