using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public GameObject HP;
    public float delayTime;

    private bool canOpen;
    private bool isOpened;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            if(!canOpen){
            anim.SetTrigger("Opening");
            isOpened = true;
            Invoke("GenHP", delayTime);
            }

        }
    }

    void GenHP()
    {
        Instantiate(HP, transform.position, Quaternion.identity);
    }


    //判断打开关闭
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") 
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = true;
        }
    }

    //EXIT
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = false;
        }
    }
}
