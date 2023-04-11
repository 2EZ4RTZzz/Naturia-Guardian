using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalReaction : MonoBehaviour
{
    public int fire, ice;
    public float damage;

    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        effect=Resources.Load("effect") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (fire > 0 && ice > 0)
        {
            fire--;
            ice--;
            GetComponent<Enemy>().TakeDamge(damage);
          var go= GameObject.Instantiate(effect,transform.position,Quaternion.identity,null);
          Destroy(go,1f);
        }
    }
}
