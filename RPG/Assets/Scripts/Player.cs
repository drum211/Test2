using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int HP;
    public int MaxHP;
    public bool flip;

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 Move;
    private Vector2 MoveVel;
    private Vector3 Scaler;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        HP_Config();
        Moving();
    }
    public void HP_Config()
    {
        if (HP <= 0)
        {
            HP = 0;
        }
        if (HP > MaxHP)
        {
            HP = MaxHP;
        }

    }
    public void Flip()
    {
        flip= !flip;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    public void Moving()
    {
        Move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        MoveVel = Move.normalized * speed;
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            anim.SetInteger("AnimComp", 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(rb.position + MoveVel * Time.deltaTime);
            if (flip == false)
            {
                Flip();
            }
            anim.SetInteger("AnimComp", 2);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(rb.position + MoveVel * Time.deltaTime);
            if (flip == true)
            {
                Flip();
            }
            anim.SetInteger("AnimComp", 2);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(rb.position + MoveVel * Time.deltaTime);
            anim.SetInteger("AnimComp", 2);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(rb.position + MoveVel * Time.deltaTime);
            anim.SetInteger("AnimComp", 2);
        }
    }
}
