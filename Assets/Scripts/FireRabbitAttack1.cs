using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRabbitAttack1 : MonoBehaviour
{
    public int damage;
    public float time,StartTime;

    private Animator anim;
    private PolygonCollider2D Attack1Coll;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        Attack1Coll = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }

    void attack()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("attack_1");
            // Debug.Log("is hurt");
            StartCoroutine(StartAttack());
            
        }
    }

    //延迟动画
    IEnumerator StartAttack()
    {
        // Debug.Log("is hurt");
        Attack1Coll.enabled=true;
        yield return new WaitForSeconds(StartTime);
        // Attack1Coll.enabled=true;
        StartCoroutine(disableHitBox());
    }


    //一定时间内关掉动画
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        Attack1Coll.enabled=false;
    }

    //攻击
    void OnTriggerEnter2D(Collider2D other)
    {
        // Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if(other.gameObject.CompareTag("Enemy"))
        {
           other.GetComponent<Enemy>().TakeDamge(damage);

        }
    }

}
