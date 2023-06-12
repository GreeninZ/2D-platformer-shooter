    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo_counter : MonoBehaviour
{
    float amunicja;
    float max_amunicja = 10f;
    float firerate = 0.6f;
    float nextfire = 0f;
   public  bool pistol = true;
    private GUIStyle guiStyle = new GUIStyle();
    public static ammo_counter instance;
    private void Start()
    {
        instance = this;
        amunicja = max_amunicja;
    }
    private void OnGUI()
    {
        if (pistol == true)
        {
            guiStyle.fontSize = 20;
            guiStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(42, 62, 80, 20), amunicja + "/" + max_amunicja, guiStyle);
        }
        if (pistol == false)
        {
            guiStyle.fontSize = 20;
            guiStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(42, 62, 80, 20),"", guiStyle);
            
        }
        
    }
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && Time.time > nextfire && amunicja > 0)
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
