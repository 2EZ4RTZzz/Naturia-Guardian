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

    // public GameObject player;

    //chase player
    Transform target;
    Vector2 moveDirection;

    //chasing angle
    //序列化 定义之后 虽然是private 但是会在inspector里面出现 可以修改
    [SerializeField] private float facingAngle;



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
        //catch the player pos.
        target = GameObject.Find("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        checkPlayerLocation();
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
    void checkPlayerLocation()
    {
        if (Mathf.Abs(target.transform.position.x - transform.position.x) <= 15)
        {
            if (target)
            {
                Vector2 direction = (target.position - transform.position).normalized;
                //calcuate angle  , 三角函数
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                //转向角度
                // rb.rotation = angle;
                if (transform.position.x < target.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                moveDirection = direction;
                rb.velocity = new Vector2(direction.x, direction.y) * Speed;
                //if close to 15 , charing 
                rb.rotation = 0;
                //charging mode
                if (Mathf.Abs(target.position.x - transform.position.x) <= 5)
                {
                    rb.velocity = new Vector2(direction.x, direction.y) * Speed * 4f;
                    anim.SetBool("attack", true);
                    if ((transform.position.x < target.position.x) && (transform.position.y < target.position.y))
                    {
                        rb.rotation = facingAngle;
                        //skip the fight
                    }
                    else if ((transform.position.x > target.position.x) && (transform.position.y < target.position.y))
                    {
                        rb.rotation = -facingAngle;
                    }
                    else
                    {
                        rb.rotation = 0;
                    }
                }
                else
                {
                    anim.SetBool("attack", false);
                }
            }
        }
    }
}


    // void ChasePlayer()
    // {
    //     Debug.Log("123");
    //     if(Mathf.Abs(player.transform.position.x-transform.position.x) <= 15){

    //         anim.SetBool("attack",true);
    //         // isAttacking=true;

    //         // Eagleattack();
    //     }else{
    //         // isAttacking=false;
    //         // Eagleattack();
    //         anim.SetBool("attack",false);
    //     }
    // }
    // void Eagleattack()
    // {
    //     if(isAttacking){
    //         anim.SetBool("attack",true);
    //     }
    //     else{
    //         anim.SetBool("attack",false);
    //     }
    // }



// 爆炸
//  lockdown x,y,z
// rb.constraints = RigidbodyConstraints2D.FreezeAll;