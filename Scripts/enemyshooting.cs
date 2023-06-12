using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshooting : MonoBehaviour
{
    public bool kierunekwprawo = false;
    public GameObject bulletprefab;
    float timebtwshoots;
    public float starttimebtwshoots;
    public Transform firepoint;
    public Transform player;

    private void Update()
    {
        if (timebtwshoots <=0)
        {
            Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
 
            timebtwshoots = starttimebtwshoots;

        } else
        {
            timebtwshoots -= Time.deltaTime;
        }
        if (player.position.x > transform.position.x && kierunekwprawo == false)
        {
            Flip();
            kierunekwprawo = true;
        }
        if (player.position.x < transform.position.x && kierunekwprawo == true)
        {
            Flip();
            kierunekwprawo = false;
        }
    }
    void Flip()
    {
        kierunekwprawo = !kierunekwprawo;
        Vector3 skala = gameObject.transform.localScale;
        skala.x *= -1;
        gameObject.transform.localScale = skala;
    }
}
