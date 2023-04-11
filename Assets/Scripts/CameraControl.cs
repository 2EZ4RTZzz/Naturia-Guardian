using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player1, player2, player3;
    private Transform currentPos;

    void Update()
    {
        if (player1.gameObject.activeSelf) currentPos = player1;
        else if (player2.gameObject.activeSelf) currentPos = player2;
        // else if (player3.gameObject.activeSelf) currentPos = player3;

        transform.position = new Vector3 (currentPos.position.x, currentPos.position.y, -10f);
    }
}
