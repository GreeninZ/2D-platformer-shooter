using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoCounter : MonoBehaviour
{
    private GUIStyle guiStyle = new GUIStyle();
    public bool nothing;
    public static ammoCounter instance;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    
    
        private void OnGUI()
        {
            if (nothing == true)
            {
            guiStyle.fontSize = 20;
            guiStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(42, 62, 80, 20), 0 + "/" + 0, guiStyle);
            }

                
            
            

        }
    
}
