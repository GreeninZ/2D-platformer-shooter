using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class playeraimweapon : MonoBehaviour
{
    
    private Transform aimtransform;
    public GameObject aim;
    private void Awake()
    {
        aimtransform = transform.Find("Aim");
    }   

    private void Update()
    {
        Vector3 mouseposition = UtilsClass.GetMouseWorldPosition();
        Vector3 aimdirection = (mouseposition - transform.position).normalized;
        float angle = Mathf.Atan2(aimdirection.y, aimdirection.x) * Mathf.Rad2Deg;
        aimtransform.eulerAngles = new Vector3(0, 0, angle);
    } 
    public void zycie (float zycie)
    {
        if (zycie <= 0)
        {
            Destroy(aim);
        }
    }
}
    

   
        

