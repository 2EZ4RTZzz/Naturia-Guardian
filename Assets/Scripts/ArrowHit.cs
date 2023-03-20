using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour
{
    public GameObject arrowPrefab;
    private Animator anim;
    public PlayerAttributes playerAttr;
    public SkillDataList_SO skillList;
    // Start is called before the first frame update
    void Start()
    {
        playerAttr = transform.parent.parent.GetComponent<PlayerAttributes>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }

    void attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("attack_1");
            Shoot();
            if (Random.Range(0, 100) < playerAttr.crit)
            {
                arrowPrefab.GetComponent<Arrow>().damage = playerAttr.atk * (playerAttr.critDmg / 100) * skillList.iceRabbitSkills[0].dmgFactor;
            }
            else
            {
                arrowPrefab.GetComponent<Arrow>().damage = playerAttr.atk * skillList.iceRabbitSkills[0].dmgFactor;
            }
            playerAttr.currentMP += skillList.iceRabbitSkills[0].mp;
        }
    }
    void Shoot()
    {

        Instantiate(arrowPrefab, transform.position, transform.rotation);
    }

}
