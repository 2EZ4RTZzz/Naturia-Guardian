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

    // Start is called before the first frame update
    protected virtual void Start()
    // ****virtual*** means is temporary  , it can be edit in child class later
    {
        anim = GetComponent<Animator>();
        deathAudio = GetComponent<AudioSource>();
    }

    protected virtual void update()
    {
        if (health <= 0)
        {
            GetAttack();
            // Death();
        }
    }
    //death animation
    public void Death()
    {
        Destroy(gameObject);
    }

    public void TakeDamge(int damage)
    {
        health -= damage;
    }

    //can be used from other class cause is open public
    public void JumpOn()
    {
        deathAudio.Play();
        anim.SetTrigger("death");
    }


    public void GetAttack()
    {
        deathAudio.Play();
        anim.SetTrigger("death");
    }

}
