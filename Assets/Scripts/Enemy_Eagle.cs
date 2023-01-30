using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Eagle : Enemy
{
    private Rigidbody2D rb;
    // private Collider2D Coll;
    public Transform top, bottom;
    //locked 1
    private float Speed = 1;
    private float TopY, BottomY;
    // private Animator anim;

    private bool isUp = true;

    

    // Start is called before the first frame update
    protected override void Start()
    {
        //super the componet.
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        // Coll = GetComponent<Collider2D>();
        // anim = GetComponent<Animator>();
        TopY = top.position.y;
        BottomY = bottom.position.y;
        Destroy(top.gameObject);
        Destroy(bottom.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (isUp)
        {
            rb.velocity = new Vector2(rb.velocity.x, Speed);
            if (transform.position.y > TopY)
            {
                isUp = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -Speed);
            if (transform.position.y < BottomY)
            {
                isUp = true;
            }
        }
    }
}



// 爆炸
//  lockdown x,y,z
// rb.constraints = RigidbodyConstraints2D.FreezeAll;