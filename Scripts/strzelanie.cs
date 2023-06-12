using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strzelanie : MonoBehaviour
{
    public Animator animator;
    public Transform firepoint;
    public GameObject bulletprefab;
    public float bulletforce = 5f;
    public float firerate;
    public float nextfire;
    float ammo;
    float maxammo = 10f;
    public ammo_counter ammo_counter;
    Vector3 rotation;
    public float attackrange = 0.5f;
    public LayerMask enemylayer;
    public float attackcooldown = 0f;
    public float attackrate = 5f;
    // Update is called once per frame
    private void Start()
    {
        ammo = maxammo;
        gameObject.SetActive(true);
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextfire && ammo > 0)
        {
            nextfire = Time.time + firerate;
            animator.SetTrigger("shoot");
            shoot();

            ammo -= 1;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ammo = maxammo;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ammo = maxammo;
            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.V) && (Time.time >= attackcooldown))
        {
            animator.SetBool("melee", true);
            attackcooldown = Time.time + 1f / attackrate;
        }
        else
        {
            animator.SetBool("melee", false);
        }
    }
    void shoot()
    {
        GameObject bullet = Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.SetRotation(firepoint.rotation );
        rb.AddForce(firepoint.up * bulletforce, ForceMode2D.Impulse);

    }
    
}
