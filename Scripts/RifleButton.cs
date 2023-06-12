using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleButton : MonoBehaviour
{
    // Start is called before the first frame update
    public static RifleButton instance;
    public bool canRifle = false;
    void Start()
    {
        instance = this;

    }

   public void RifleUnlock()
    {
        canRifle = true;
    }
}
