using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Shameless.Inventory;

public class BuffTree : MonoBehaviour
{
    public int buffID = 0; 

    // Start is called before the first frame update
    void Start()
    {
        //buffID = GameObject.FindGameObjectWithTag("BuffTreeGenerator").GetComponent<BuffTreeGenerator>().buffID;
    }

    // Update is called once per frame
    void Update()
    {
        if (buffID == 0) buffID = GameObject.Find("BuffTreeGenerator").GetComponent<BuffTreeGenerator>().buffID;
        gameObject.GetComponent<Item>().itemID = buffID;
    }
}
