using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VcamController : MonoBehaviour
{
    public Transform player1, player2, player3;
    private Transform currentPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.gameObject.activeSelf) currentPos = player1;
        else if (player2.gameObject.activeSelf) currentPos = player2;
        else if (player3.gameObject.activeSelf) currentPos = player3;

        GetComponent<CinemachineVirtualCamera>().Follow = currentPos;
    }
}
