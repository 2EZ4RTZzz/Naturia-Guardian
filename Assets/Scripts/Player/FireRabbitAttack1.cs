using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRabbitAttack1 : MonoBehaviour
{
    public int damage;
    public float time,StartTime;

    private Animator anim;
    private PolygonCollider2D Attack1Coll;

    //buff状态
    public BuffState_SO buffState;
    public bool fireBuff_1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        Attack1Coll = GetComponent<PolygonCollider2D>();
        fireBuff_1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        attack();
        checkBuffState();
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

        if (other.gameObject.CompareTag("MeltIce") && fireBuff_1)
        {
            Vector3 scale = other.gameObject.transform.localScale;
            // anim.SetTrigger("shaking");
            scale.x -= 0.1f;
            scale.y -= 0.1f;
            scale.z -= 0.1f;
            other.gameObject.transform.localScale = scale;
            if (other.gameObject.transform.localScale.x < 2.0f)
            {
                Debug.Log("destroy");
                Destroy(other.gameObject);
            }
            
        }
    }

    private void checkBuffState()
    {
        for (int i = 0; i < buffState.buffList.Count; i++)
        {
            var id = buffState.buffList[i].itemID;
            if (id == 1000) fireBuff_1 = true;
        }
    }

}
