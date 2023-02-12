using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            playerHealth.DamagePlayer(damage);
        }
    }




        private void OnCollisionEnter2D(Collision2D other)
    {
                // && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D"
        if (other.gameObject.CompareTag("Player") )
        {
            if(playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);
            }            
        }
    }
}
