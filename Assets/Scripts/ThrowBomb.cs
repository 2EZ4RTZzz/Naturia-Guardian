using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{
    public GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void callBomb()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Instantiate(bomb,transform.position,Quaternion.Euler(0,-180,0));
          var go=  Instantiate(bomb, transform.position, transform.rotation);
            go.GetComponent<Bomb>().dir = -(transform.parent.transform.position - this.transform.position).normalized;
        }
    }
}
