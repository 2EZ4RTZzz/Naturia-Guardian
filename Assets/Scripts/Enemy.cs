using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//super class
public class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected AudioSource deathAudio;

    //damage & health
    public int health, damage;

    //hurt effect
    private SpriteRenderer sr;
    private Color originalColor;
    //flash time 
    public float flashTime;

    //blooddropping effect
    public GameObject bloodEffect;

    //blood fly
    public GameObject floatPoint;

    //get playerhealth 
    private PlayerHealth playerHealth;



    // Start is called before the first frame update
    protected virtual void Start()
    // ****virtual*** means is temporary  , it can be edit in child class later
    {
        //load player's hp info
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        anim = GetComponent<Animator>();
        deathAudio = GetComponent<AudioSource>();

        //save the original color
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    protected virtual void update()
    {
        if (health == 0)
        {
            GetAttack();
            
            // deathAudio.Play();
        }
    }
    //death animation
    public void Death()
    {
        Destroy(gameObject);
    }

    //when the enemy TaketheDamage from the player method*****
    //受到伤害
    public void TakeDamge(int damage)
    {
        //damage point.
        //局部变量
        GameObject gb = Instantiate(floatPoint,transform.position,Quaternion.identity) as GameObject;
        //**** important learn******
        //real time damage valuefeedback.
        gb.transform.GetChild(0).GetComponent<TextMesh>().text= damage.ToString();
        
        
        health -= damage;
        FlashColor(flashTime);
        //bloodeffect for 1sec
        Instantiate(bloodEffect,transform.position,Quaternion.identity);
    }

    //can be used from other class cause is open public
    public void JumpOn()
    {
        deathAudio.Play();
        anim.SetTrigger("death");
    }


    public void GetAttack()
    {
        // deathAudio.Play();
        // Debug.Log("123");
        anim.SetTrigger("death");
    }

    //flash red color -> hurt effect
    //float a time , flash for how long? 
    void FlashColor(float time)
    {
        //white color flash for additial color
        // float level = Mathf.Abs(Mathf.Sin(Time.time * 20));
        // GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, level);
        
        // hurt color (can set like random color if we wanna play some fancy desotry effect.)
        sr.color = Color.red;
        //delay 1-1.25 sec by using invoke method
        Invoke("ResetColor", time);
    }

    //reset back to the originalColor.
    void ResetColor()
    {
        sr.color = originalColor;
    }

    // player Health method 

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     // && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"
    //     if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D" )
    //     {
    //         if(playerHealth != null)
    //         {
    //             playerHealth.DamagePlayer(damage);
    //         }            
    //     }
    // }  

    private void OnCollisionEnter2D(Collision2D other)
    {
                // && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"
        if (other.gameObject.CompareTag("Player") )
        {
            if(playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);
            }            
        }
    }
}
