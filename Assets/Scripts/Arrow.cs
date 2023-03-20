using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed; //original speed
    public float damage;
    public float destoryDistance; //fly x distance will destory itself

    private Rigidbody2D rb2d;
    private Vector3 startPos;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("SnowRabbit");
        rb2d = GetComponent<Rigidbody2D>();
        if (player.transform.localScale.x > 0) rb2d.velocity = transform.right * speed;
        if (player.transform.localScale.x < 0) rb2d.velocity = transform.right * -speed;
        startPos = transform.position;
        transform.localScale = new Vector3(player.transform.localScale.x,1,1);

    }

    // Update is called once per frame
    void Update()
    {
        float distance = (transform.position - startPos).sqrMagnitude;
        if(distance> destoryDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamge(damage);
        }
    }
}
