using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickleHit : MonoBehaviour
{
    public GameObject sickle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.K))
        //{
        //    Shoot();
        //}
    }

    public void Shoot()
    {
      var go=  Instantiate(sickle,transform.position,transform.rotation);
        go.GetComponent<Sickle>().dir = -(transform.parent.transform.position - this.transform.position).normalized;
    }
}
