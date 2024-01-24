using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator animplayer;
    public float speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJump;


    private Rigidbody2D rig;
    private Animator anim;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;  

        if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("andando", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("andando", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }

        if(Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("andando", false);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if(doubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                    anim.SetBool("doublejump", true);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool("jump", false);
            anim.SetBool("doublejump", false);
        }
        
        if(collision.gameObject.layer == 7)
        {
            isJumping = false;
            anim.SetBool("jump", false);
            anim.SetBool("doublejump", false);
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = true;
            anim.SetBool("jump", true);
        }

        if(collision.gameObject.layer == 7)
        {
            isJumping = true;
            anim.SetBool("jump", true);
        }
    }
}
