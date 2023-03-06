using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    //玩家的碰撞方框（可以是胶囊也可以是正方形）
    public Collider2D coll;
    public Collider2D DisColl;
    public Collider2D Attack1_Coll;
    public float speed, jumpforce;
    //LayerMask 指的是图层，告诉系统那个图层是真正的地面.
    public LayerMask ground;
    public Transform CellingCheck;

    //记录樱桃
    public Text CherryNum;

    //判断伤害

    private bool isHurt;  //默认是False
    private bool isCrouching;
    public bool isCrafting;
    public bool bagOpening;

    //记录吃了多少樱桃
    public int Cherry = 0;

    //后退速度
    private float backSpeed=5;

    //jump sound
    public AudioSource jumpAudio;

    //pick up coins sound
    public AudioSource pickUpAudio;


    public float Attack1finish=90;
    [SerializeField] private GameObject buffInfo;

    

    //check the last 帧
    // private Animation animationComponent;
    // private AnimationClip animClip;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isCrouching = false;
        // animationComponent = GetComponent<Animation>();
        // animClip = animationComponent.clip;
    }

    void Update()   //自适应变化帧数 ， 根据不同电脑 ，有的电脑卡 自动会掉帧 所以要fix叼
    {
        //!isHurt 反而是true 当受到伤害 不执行Movement
        if (!isHurt && !isCrafting && !bagOpening)
        {
            Movement();
        }
        SwitchAnim();
        attack_2();
        attack_3();
        // if(animationComponent[animClip.].normalizedTime >= 1.0f){
        //     anim.SetBool("idle",true);
        // }
        // if(Attack1finish>0){
        //      Attack1finish --;
        //     Attack1_Coll.enabled=true;
        // }else{
        //     Attack1_Coll.enabled=false;
        // }
    }
    
    //move
    void Movement() 
    {
        Crouch();
        float horizontalmove = Input.GetAxisRaw("Horizontal");  //get -1 , 0 , 1 if 1 right , -1 left
        //左右移动 !!!有bug 施法的时候不应该移动的
        if(!anim.GetBool("attack_3")){
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
        }
        
        if (!isCrouching) anim.SetFloat("running", Mathf.Abs(horizontalmove));
        //Time.deltaTime 乘以物理时钟的百分比 ， 所以在运行中 会变得平滑不跳帧数
        //rb.velocity = new Vector2(horizontalmove*speed,rb.velocity.y);

        //控制左右朝向
        if (horizontalmove != 0)
        {
            transform.localScale = new Vector3(horizontalmove, 1, 1);  //x , y , z （Y,Z 保持不变）
        }


        //跳跃   
        //1-11 remove super jumps !!!  同时执行的时候才算
        if (Input.GetButtonDown("Jump") && DisColl.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            jumpAudio.Play();
            anim.SetBool("jumping", true);
        }
    }


    void attack_2()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            anim.SetBool("attack_2",true);
        }
    }

        void attack_3()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            anim.SetBool("attack_3",true);
            // rb.velocity = new Vector2(horizontalmove * 0, 0);          
        }
    }


    //切换动画
    void SwitchAnim()
    {
        //无论如何都会执行 因为这是一开始的基础移动 ， 也只有在将落地的时候 重新切换为true
        anim.SetBool("idle", false);

        //if the player is falling down and also not touching the ground , then is falling animtion
        if(rb.velocity.y < 0.1f && !coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling",true);
        }
        //直接返回一个boolean 因为我设置的boolean variable!!!
        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0)
            {
                //当y轴小于0的时候 关掉jumping 因为已经开始下降了，同时fall为true
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        else if (isHurt)
        {
            //decrease the hurt backSpeed
            backSpeed -= 0.05f;
            anim.SetBool("hurt",true);
            
            if (backSpeed <= 0)
            {
                //after hurt animtor back to idle
                //回到正常状态
                anim.SetBool("hurt",false);
                anim.SetBool("idle",true);


                //Debug.Log("is hurt");
                isHurt = false;
                backSpeed = 5;

            }

        }
        //如果玩家下降碰到地面，那么下落为false ， 回归正常ldle ， 但是要确保如果下落一次 就会一直保持一样 ， 所以在一开始LINE56 要给个trigger值 去control it back
        else if (DisColl.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
        }
    }

    

    //吃cherry！ 收集method
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collection")
        {
            pickUpAudio.Play();
            Destroy(collision.gameObject);
            Cherry += 1;
            //把int 变string 用ToString();
            CherryNum.text = Cherry.ToString();
        }
    }

    // 下蹲 crouching 
    void Crouch()
    {
        //顶头 ， 如果钻进去，不能让他站立！
        if (Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
        }
        if (Input.GetButtonUp("Crouch"))
        {
            isCrouching = false;
        }

        if (isCrouching)
        {
            anim.SetBool("crouching", true);
            DisColl.enabled = false;
            coll.enabled = true;
        }
        else if (!isCrouching && !Physics2D.OverlapCircle(CellingCheck.position, 0.2f, ground))
        {
            anim.SetBool("crouching", false);
            coll.enabled = false;
            DisColl.enabled = true;
        }
    }


    //kill enemeies
    private void OnCollisionEnter2D(Collision2D other)
    {
        //match the tag
        if (other.gameObject.tag == "Enemy")
        {   
            //get all the enemy_frog's functions / variables 
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            // Enemy_Frog frog = other.gameObject.GetComponent<Enemy_Frog>();
            //check if is falling
            if (anim.GetBool("falling"))
            {
                //take from the all enemy method.
                enemy.JumpOn();
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                anim.SetBool("jumping", true);
            }
            //if not falling on the head of the enemy
            //fox on the left side of frog
            else if (transform.position.x < other.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-5, rb.velocity.y);
                isHurt = true;
            }
            //fox on the right side of the frog
            //get Object , transform position and check X not y!
            else if (transform.position.x > other.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(5, rb.velocity.y);
                isHurt = true;
            }
        }
    }
}
