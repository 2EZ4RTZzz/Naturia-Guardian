using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//super class
public class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected AudioSource deathAudio;

    // Start is called before the first frame update
    protected virtual void Start()
    // ****virtual*** means is temporary  , it can be edit in child class later
    {
        anim= GetComponent<Animator>();
        deathAudio = GetComponent<AudioSource>();
    }
    
    //death animation
    public void Death()
    {
        Destroy(gameObject);
    }

    //can be used from other class cause is open public
    public void JumpOn()
    {
        deathAudio.Play();
        anim.SetTrigger("death");
    }


}
