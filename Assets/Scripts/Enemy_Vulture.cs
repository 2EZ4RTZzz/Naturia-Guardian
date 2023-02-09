using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Vulture : Enemy
{
    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        waitTime = startWaitTime;
        //when the game start , the enemy will get a random position.
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        base.update();
        //move to to random the pos with a set speed
        transform.position = Vector2.MoveTowards(transform.position,movePos.position,speed*Time.deltaTime);

        //check the enemy cureent position is arrive at the random pos or not
        if(Vector2.Distance(-transform.position,movePos.position) < 0.1f)
        {
            if(waitTime<=0)
            {   
                
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                //if enemy arrived , stop for X sec
                waitTime -= Time.deltaTime;
            }
        }
    }

    Vector2 GetRandomPos()
    {
        //random area
        Vector2 randomPos = new Vector2(Random.Range(leftDownPos.position.x,rightUpPos.position.x),Random.Range(leftDownPos.position.y,rightUpPos.position.y));
        return randomPos;
    }
}
