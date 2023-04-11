using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIX_potion : MonoBehaviour
{
    public float spRecovery;
    public float hpRecovery;
    //public GameObject player;
    public PlayerAttributes recovery;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            
            recovery.currentMP+=spRecovery;
            recovery.currentHP+=hpRecovery;
            Destroy(gameObject);
        }
    }
}
