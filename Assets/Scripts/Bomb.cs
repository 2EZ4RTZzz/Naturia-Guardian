using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //bagenning speed
    public Vector2 startSpeed;
    private Rigidbody2D rb2d;
    private Animator anim;

    //set times
    public float delayExplodeTime;
    public float hitBoxTime;
    public float destroyBombTime;


    //for the bomb range
    public GameObject explosionRange;
    public Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //a orignal speed like throw out behaviour
        rb2d.velocity = dir * startSpeed.x + transform.up * startSpeed.y;


        Invoke("Explode", delayExplodeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Explode()
    {
        anim.SetTrigger("Explode");
        Invoke("GenExplosionRange", hitBoxTime);
        Invoke("DestroyThisBomb", destroyBombTime);
    }

    //destory the gameobject (bomb)
    void DestroyThisBomb()
    {
        Destroy(gameObject);
    }


    void GenExplosionRange()
    {
        Instantiate(explosionRange, transform.position, Quaternion.identity);
    }

}


