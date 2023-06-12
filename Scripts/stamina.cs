using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class stamina : MonoBehaviour
{

    public Slider slider;
    public float maxstamina = 100;
    public float currentstamina;
    public static stamina instance;
    public Coroutine regen;
    public poruszanie poruszanie;
    public melee melee;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        melee = GameObject.FindObjectOfType<melee>();
        poruszanie = GameObject.FindObjectOfType<poruszanie>();
    }
    void Start()
    {
        currentstamina = maxstamina;
        slider.maxValue = maxstamina;
        slider.value = currentstamina;
    }

    public void jumping(float ammount)
    {
        if (currentstamina - ammount >= 0 )
        {

            currentstamina -= ammount;
            slider.value = currentstamina;
            if (currentstamina < 0)
            {
                currentstamina = 0;
            }
            if (regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(regenstamina());
        }
       
    }
    private IEnumerator regenstamina()
    {
        yield return new WaitForSeconds(2);
        while(currentstamina < maxstamina)
        {
            currentstamina += maxstamina / 100;
            slider.value = currentstamina;
            yield return new WaitForSeconds(0.1f);
        }
        regen = null;
    }
    public void running()
    {
        currentstamina -= 0.02f - Time.deltaTime;
        slider.value = currentstamina;
        if (currentstamina < 0)
        {
            currentstamina = 0;
        }
        if (regen != null)
            StopCoroutine(regen);

        regen = StartCoroutine(regenstamina());
    }
    private void Update()
    {
        melee.atak(currentstamina);
        poruszanie.bieg(currentstamina);
        poruszanie.skok(currentstamina);
    }
}
