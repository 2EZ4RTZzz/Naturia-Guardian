using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //public int health;
    private PlayerAttributes playerAttr;

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
        playerAttr = gameObject.transform.GetComponentInParent<PlayerAttributes>();
        myRender = GetComponent<Renderer>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        anim = GetComponent<Animator>();
        //set the hp
        //HealthBar.HealthMax= health;
        //HealthBar.HealthCurrent= health;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public
    public void DamagePlayer(float damage)
    {
        //relate to the HP bar
        playerAttr.currentHP -= damage*(1-playerAttr.def/100.0f);
        if(playerAttr.currentHP <= 0)
        {
            //GG!!!!!! 2023-02-14-3:21 AM FUCKING AM!!!
            playerAttr.currentHP = 0;
            anim.SetTrigger("die");
            Invoke("playerDead", dieTime);
        }
        //HealthBar.HealthCurrent = health;

        BlinkPlayer(Blinks,time);
        polygonCollider2D.enabled=false;
        StartCoroutine(ShowPlayerPolyHitBox());
    }
    IEnumerator ShowPlayerPolyHitBox()
    {
        yield return new WaitForSeconds(hitBoxCDTime);
        if(playerAttr.currentHP > 0)
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
