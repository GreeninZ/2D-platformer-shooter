using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poruszanie : MonoBehaviour
{
    public CapsuleCollider2D playercollider;
    public Animator animator;
    public float speed = 10f;
    public bool kierunekWPrawo = true;
    private Rigidbody2D rbBody;
    public int skokgit = 2;
    public float crouchpercent = 0.5f;
    [SerializeField] private float crouchspeed;
    public static poruszanie instance;
    public bool crouchingPressed { get; private set; }
    public bool iscrouching { get; private set; }
    private Vector2 standcollidersize;
    public float jumpforce = 7f;
    private Vector2 standcollideroffset;
    private Vector2 crouchcollidersize;
    private Vector2 crouchcollideroffset;
    [SerializeField] private Collider2D m_CrouchDisableCollider;
    private Transform aimtransform;
    private bool canMove;
    public bool running;
    public bool crouching;
    public float distance;
    public LayerMask ladder;
    private bool isclimbing;
    public bool speedpotion;
    public bool crouchh;
    public bool isgrounded;
   
   [SerializeField] private Transform m_CeilingCheck;
    [SerializeField] private Transform m_GroundCheck;
    public const float k_CeilingRadius = .2f;
    public const float k_GroundRadius = .2f;
    [SerializeField] private LayerMask m_WhatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        
        instance = this;
        canMove = true;
        playercollider = this.GetComponent<CapsuleCollider2D>();
        rbBody = GetComponent<Rigidbody2D>();
        /*standcollidersize = playercollider.size;
        standcollideroffset = playercollider.offset;

        crouchcollidersize = new Vector2(standcollidersize.x, standcollidersize.y * crouchpercent);
        crouchcollideroffset = new Vector2(standcollideroffset.x, standcollideroffset.y  * crouchpercent);*/
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isgrounded);
        if (speedpotion == true)
        {
            Invoke("normalspeed", 5f);
            Invoke("speedend", 5f);
        }
        if (jumpforce == 20f)
        {
            Invoke("normaljump", 5f);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouchingPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouchingPressed = false;
        }
        if (canMove == true)
        {
            float ruchPoziomy = Input.GetAxis("Horizontal");
            animator.SetFloat("speed", Mathf.Abs(ruchPoziomy));
            float ruchPionowy = Input.GetAxis("Vertical");
            RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.up, distance, ladder);
            rbBody.velocity = new Vector2(ruchPoziomy, rbBody.velocity.y);
            rbBody.velocity = new Vector2(ruchPoziomy * speed, rbBody.velocity.y);
            crouch();
            stand();


            Vector3 skala = gameObject.transform.localScale;

            if (ruchPoziomy < 0 && kierunekWPrawo == true)
            {
                Flip();
            }

            if (ruchPoziomy > 0 && kierunekWPrawo == false)
            {
                Flip();
            }

            

            if (rbBody.velocity.y == 0)
            {
                skokgit = 2;
            }
            if (rbBody.velocity.y > 0)
            {
                animator.SetBool("jump", true);
            }
            else
            {
                animator.SetBool("jump", false);
            }
            if (rbBody.velocity.y < 0)
            {
                animator.SetBool("fall", true);
            }
            else
            {
                animator.SetBool("fall", false);
            }

           
            if(running == true && crouchh == true)
            {
                speed = 15f;
                Invoke("speedtonormalcrouch", 1);
            }

            if (hitinfo.collider!=null)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    isclimbing = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    isclimbing = false;
                }
            }
            if(isclimbing==true && hitinfo.collider !=null)
            {
                ruchPionowy = Input.GetAxis("Vertical");
                rbBody.velocity = new Vector2(rbBody.velocity.x, ruchPionowy * speed);
                rbBody.gravityScale = 0;
            }
            else
            {
                rbBody.gravityScale = 1.6f;
            }
        }
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
            crouchh = true;
        }
        else
        {
            crouchh = false;
        }

       if (!crouchh)
       {
          if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
          {
               crouchh = true;
          }
       }

        if (Physics2D.OverlapCircle(m_GroundCheck.position, k_GroundRadius, m_WhatIsGround))
        {
            isgrounded = true;
        }
        else
        {
            isgrounded = false;
        }
    }
    public void normalspeed()
    {
        speed = 10f;
    }
    public void speedend()
    {
        speedpotion = false;
    }
    public void normaljump()
    {
        jumpforce = 7f;
    }
    public void speedtonormalcrouch()
    {
        speed = 5f;
    }
    public void changerunning()
    {
        running = false;
    }
    public void skok(float currentstamina)
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && (skokgit > 0) && (currentstamina > 0) && canMove == true)
        {
            rbBody.velocity = new Vector3(0, jumpforce, 0);
            skokgit = skokgit - 1;
            stamina.instance.jumping(15);
            
        }
    }
    public void bieg(float currentstamina)
    {
        if (Input.GetKey(KeyCode.LeftShift) && currentstamina > 0 && canMove == true && crouchh == false && speedpotion == false && isgrounded == true)
        {
            //Debug.Log(currentstamina);
            speed = 15f;
            running = true;
            stamina.instance.running();
        }
        if (Input.GetKey(KeyCode.LeftShift) && currentstamina > 0 && canMove == true && crouchh == false && speedpotion == true && isgrounded == true)
        {
            //Debug.Log(currentstamina);
            speed = 25f;
            running = true;
            stamina.instance.running();
        }
        else
        {
            
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && speedpotion == false|| currentstamina <= 0 && speedpotion == false)
        {
            speed = 10f;
            Invoke("changerunning", 1);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && speedpotion == true || currentstamina <= 0 && speedpotion == true)
        {
            speed = 20f;
            Invoke("changerunning", 1);
        }
    }
    public void zycie(float zycie)
    {
        if (zycie <= 0)
        {
            canMove = false;
        }
    }
    void crouch()
    {
        if (isgrounded == true && isgrounded == true&& speedpotion == false)
        {
            animator.SetBool("crouch", true);
            speed = 5f;
            crouching = true;
            if (m_CrouchDisableCollider != null)
                m_CrouchDisableCollider.enabled = false;
        }
        else
        {
            crouching = false;

        }

        if (crouchh == true && isgrounded== true && speedpotion == true)
        {
            animator.SetBool("crouch", true);
            speed = 10f;
            crouching = true;
            if (m_CrouchDisableCollider != null)
                m_CrouchDisableCollider.enabled = false;
        }
        else
        {
            crouching = false;

        }


    }
    void stand()
    {
        if (crouchh== false && speedpotion == false)
        {
            speed = 10f;
            // Enable the collider when not crouching
            if (m_CrouchDisableCollider != null)
                m_CrouchDisableCollider.enabled = true;
            animator.SetBool("crouch", false);
        }

        if (crouchh == false && speedpotion == true)
        {
            speed = 20f;
            // Enable the collider when not crouching
            if (m_CrouchDisableCollider != null)
                m_CrouchDisableCollider.enabled = true;
            animator.SetBool("crouch", false);
        }

    }
    public void Flip()
    {
        Transform aim = transform.Find("Aim");
        aim.parent = null;
        kierunekWPrawo = !kierunekWPrawo;
        Vector3 skala = gameObject.transform.localScale;
        skala.x *= -1;
        gameObject.transform.localScale = skala;
        aim.parent = transform;
    }

}

  
  
