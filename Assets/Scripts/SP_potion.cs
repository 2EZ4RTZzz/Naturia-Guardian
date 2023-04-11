using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_potion : MonoBehaviour
{
    public float spRecovery;
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
            Debug.Log("++++");
            recovery.currentMP+=spRecovery;
            Destroy(gameObject);
        }
    }
}
