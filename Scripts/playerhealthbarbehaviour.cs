using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerhealthbarbehaviour : MonoBehaviour
{
    public Slider Slider;
    public Vector3 offset;
    public Color low;
    public Color high;
    

    

    public void sethealth(float health)
    {
        
        Slider.value = health;
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.red;

    }
    
    public void setmaxhealth(float health)
    {
        Slider.maxValue = health;
        Slider.value = health;
    }
  
}
