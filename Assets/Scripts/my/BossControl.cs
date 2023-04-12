using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossControl : Enemy
{
    //Boss���ĸ��׶�����
    public int[] attackDamage = { 5, 10, 15, 20 };
    public float[] attackInterval = { 1f, 0.8f, 0.6f, 0.4f };
    public float[] movementSpeed = { 1f, 1.2f, 1.5f, 2f };
    public float[] rageThreshold = { 0.75f, 0.5f, 0.25f, 0f };
    private int currentPhase = 0;


    public float MaxHp = 100;
    public Slider hpSlider;

    //Boss��״̬
    public enum BossState
    {
        Idle,
        Moving,
        Attacking,
        Death,
    }
    public BossState currentState = BossState.Idle;

    //Boss������
    private int currentHealth = 100;


    //Boss���ж���Χ
    public Transform leftBoundary;
    public Transform rightBoundary;

    //��ҵ�����
    public GameObject player;
    public float attackRange = 1f;

    //�������
    private Animator animator;

    //������Ч
    public GameObject attackEffectPrefab;

    public GameObject deathEffectPrefab;
    private Vector3 moveDirection = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void JumpOn()
    {

    }

    public void ChangePhas(int value)
    {

        if (currentPhase == value)
            return;

        currentPhase = value;
        transform.localScale *= 1.2f;
        speed = movementSpeed[currentPhase];
        animator.SetInteger("Index", value);

    }

    private void OnDestroy()
    {
        if(currentState == BossState.Death){
            var go = GameObject.Instantiate(deathEffectPrefab, transform.position, Quaternion.identity, null);
        }
    }
    // Update is called once per frame
    void Update()
    {

        hpSlider.value = health / MaxHp;

        if (isDeath && currentState != BossState.Death)
        {
            currentState = BossState.Death;
            Destroy(this.gameObject, 2f);
            return;

        }

        if (currentState == BossState.Death)
        {
            return;
        }

        if (health > MaxHp * 0.8f)
        {
            ChangePhas(0);

        }
        else
         if (health < MaxHp * 0.8f && health > MaxHp * 0.55f)
        {
            ChangePhas(1);

        }
        else if (health < MaxHp * 0.55f && health > MaxHp * 0.3f)
        {
            ChangePhas(2);
        }
        else
        {
            ChangePhas(3);
        }



        player = GameObject.FindGameObjectWithTag("Player");
        switch (currentState)
        {
            case BossState.Idle:

                currentState = BossState.Moving;


                break;
            case BossState.Moving:
                //�ж��Ƿ񵽴�߽磬�������ͷ
                if (transform.position.x <= leftBoundary.position.x || transform.position.x >= rightBoundary.position.x)
                {
                    Flip();
                }

                //�ж��Ƿ񵽴���Ҹ�����������빥���׶�
                if (Mathf.Abs(transform.position.x - player.transform.position.x) <= attackRange)
                {
                    currentState = BossState.Attacking;
                    animator.SetBool("Walk", false);
                    StartCoroutine(Attack());
                }
                else
                {
                    Move();
                }
                break;
            case BossState.Attacking:

                break;
            case BossState.Death:
                //�ӳٹ�����ϣ�������н׶�
                currentState = BossState.Idle;
                break;
        }
    }

    private void Move()
    {
        animator.SetBool("Walk", true);
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }


    private void Flip()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
        moveDirection *= -1;
    }


    //Boss��������
    IEnumerator Attack()
    {
        //���ݽ׶������趨����Ƶ�ʺ��˺�
        float interval = attackInterval[currentPhase];
        int damage = attackDamage[currentPhase];

        //���Ź�������
        animator.SetTrigger("Attack");

        //�ȴ�������Ч������ϣ�������˺�
        yield return new WaitForSeconds(0.5f);

        if (player != null)
        {
            player.GetComponentInParent<PlayerAttributes>().currentHP -= damage;

            var go = GameObject.Instantiate(attackEffectPrefab, player.transform.position, Quaternion.identity, null);
            Destroy(go, 1f);
        }
        yield return new WaitForSeconds(interval);
        currentState = BossState.Idle;
    }
}