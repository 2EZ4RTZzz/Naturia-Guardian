using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_potion : MonoBehaviour
{
    public float hpRecovery;
    public GameObject player;
    private PlayerAttributes recovery;
    // Start is called before the first frame update
    void Start()
    {
        recovery=player.GetComponent<PlayerAttributes>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            recovery.currentHP+=hpRecovery;
            Destroy(gameObject);
        }
    }
}
