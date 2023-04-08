using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRabbitAttack1 : MonoBehaviour
{
    public float damage;
    public float time, StartTime;

    private Animator anim;
    private PolygonCollider2D Attack1Coll;

    //buff状态
    public BuffState_SO buffState;
    public bool fireBuff_1;
    public PlayerAttributes playerAttr;
    public SkillDataList_SO skillList;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        Attack1Coll = GetComponent<PolygonCollider2D>();
        //playerAttr = gameObject.transform.parent.parent.GetComponent<PlayerAttributes>();
        if (playerAttr == null)
        {
            Debug.LogError("playerAttr is not initialized properly.");
        }
        fireBuff_1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //playerAttr = transform.parent.parent.GetComponent<PlayerAttributes>();
        attack();
        checkBuffState();
    }

    void attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            // Debug.Log("123123123");
            if (Random.Range(0, 100) < playerAttr.crit)
            {
                damage = playerAttr.atk * (playerAttr.critDmg / 100) * skillList.fireRabbitSkills[0].dmgFactor;
            }
            else
            {
                damage = playerAttr.atk * skillList.fireRabbitSkills[0].dmgFactor;
            }

            // playerAttr.currentMP += skillList.fireRabbitSkills[0].mp;
            anim.SetTrigger("attack_1");
            // Debug.Log("is hurt");
            StartCoroutine(StartAttack());
        }
        if (Input.GetKeyDown(KeyCode.K) && playerAttr.currentMP >= skillList.fireRabbitSkills[1].mp)
        {
            this.transform.parent.GetChild(2).GetComponent<SickleHit>().Shoot();
            playerAttr.currentMP -= skillList.fireRabbitSkills[1].mp;
            if (Random.Range(0, 100) < playerAttr.crit)
            {
                this.transform.parent.GetChild(2).GetComponent<SickleHit>().sickle.GetComponent<Sickle>().damage = playerAttr.atk * (playerAttr.critDmg / 100) * skillList.fireRabbitSkills[1].dmgFactor;
            }
            else
            {
                this.transform.parent.GetChild(2).GetComponent<SickleHit>().sickle.GetComponent<Sickle>().damage = playerAttr.atk * skillList.fireRabbitSkills[1].dmgFactor;
            }
        }
    }

    //延迟动画
    IEnumerator StartAttack()
    {
        // Debug.Log("is hurt");
        Attack1Coll.enabled = true;
        yield return new WaitForSeconds(StartTime);
        // Attack1Coll.enabled=true;
        StartCoroutine(disableHitBox());
    }


    //一定时间内关掉动画
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        Attack1Coll.enabled = false;
    }

    //攻击
    void OnTriggerEnter2D(Collider2D other)
    {
        // Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamge(damage);
            if(playerAttr == null)
            {
                Debug.Log("null");
            }
            playerAttr.currentMP += skillList.fireRabbitSkills[0].mp;
            other.GetComponent<ElementalReaction>().fire++;
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
