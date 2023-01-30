using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//super class
public class Enemy : MonoBehaviour
{
    protected Animator anim;

    // Start is called before the first frame update
    protected virtual void Start()
    // ****virtual*** means is temporary  , it can be edit in child class later
    {
        anim= GetComponent<Animator>();
    }
    
    //death animation
    public void Death()
    {
        Destroy(gameObject);
    }

    //can be used from other class cause is open public
    public void JumpOn()
    {
        anim.SetTrigger("death");
    }
}
