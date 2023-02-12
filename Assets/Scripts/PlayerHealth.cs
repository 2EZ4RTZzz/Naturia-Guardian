using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    //blink times
    public int Blinks;
    //times
    public float time;
    //for the blink 
    private Renderer myRender;

    //continue losing hp if player keep step on the traps
    private PolygonCollider2D polygonCollider2D;

    //poly hit tracps
    public float hitBoxCDTime;
    // Start is called before the first frame update        

    //player death animation
    private Animator anim;

    public float dieTime;
    
    void Start()
    {
        myRender = GetComponent<Renderer>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public
    public void DamagePlayer(int damage)
    {
        health -= damage;

        if(health <=0)
        {
            anim.SetTrigger("die");
            Invoke("playerDead",dieTime);
        }
        BlinkPlayer(Blinks,time);
        polygonCollider2D.enabled=false;
        StartCoroutine(ShowPlayerPolyHitBox());
    }
    IEnumerator ShowPlayerPolyHitBox()
    {
        yield return new WaitForSeconds(hitBoxCDTime);
        if(health > 0)
        {
            polygonCollider2D.enabled = true;
        }
    }


    void playerDead()
    {
        Destroy(gameObject);
    }
    //player get hurts will blink for x secs
    void BlinkPlayer(int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }

    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for(int i = 0; i < numBlinks * 2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
    }
}
