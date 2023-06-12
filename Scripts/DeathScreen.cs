using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeathScreen : MonoBehaviour
{
    
    public GameObject objecttodisable;
    // Start is called before the first frame update
    void Start()
    {
      
       objecttodisable.SetActive(false);

    }

    public void zycie(float zycie)
    {
        if (zycie <= 0)
        {
            objecttodisable.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    
}
