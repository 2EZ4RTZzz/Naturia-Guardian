using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tutorial : MonoBehaviour
{
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(0).gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.H) && index < 5)
            {
                index++;
                //Debug.Log("111");
            }
            if (index == 4) transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
            if (index != 0) index = 0;
            

        }
        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            for (int i = 0; i < 4; i++)
            {
                if (i == index) transform.GetChild(0).GetChild(0).GetChild(i).gameObject.SetActive(true);
                else transform.GetChild(0).GetChild(0).GetChild(i).gameObject.SetActive(false);
            }

        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
