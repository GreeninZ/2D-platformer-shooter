using UnityEngine;
using UnityEngine.UI;
public class healthbarbehaviour : MonoBehaviour
{
    public Slider Slider;
    public Vector3 offset;
    public Color low;
    public Color high;

    public void sethealth(float health, float maxhealth)
    {
        Slider.gameObject.SetActive(health < maxhealth);
        Slider.value = health;
        Slider.maxValue = maxhealth;
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.red;
        
    }
   

    // Update is called once per frame
    void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
