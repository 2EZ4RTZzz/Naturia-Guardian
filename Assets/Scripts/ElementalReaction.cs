using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalReaction : MonoBehaviour
{
    public int fire, ice;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fire > 0 && ice > 0)
        {
            fire--;
            ice--;
            GetComponent<Enemy>().TakeDamge(damage);
        }
    }
}
