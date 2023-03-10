using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUniversalController : MonoBehaviour
{
    private GameObject currentPlayer;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = this.transform.GetChild(0).gameObject;
        //currentPlayer.GetComponent<Transform>().position = this.GetComponent<Transform>().position;
        //playerController = currentPlayer.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchPlayer();
        //this.GetComponent<Transform>().position = currentPlayer.GetComponent<Transform>().position;
    }

    private void SwitchPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(0).gameObject.GetComponent<Transform>().position = currentPlayer.GetComponent<Transform>().position;
            this.transform.GetChild(0).gameObject.GetComponent<Transform>().localScale = currentPlayer.GetComponent<Transform>().localScale;
            this.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(false);
            currentPlayer = this.transform.GetChild(0).gameObject;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.GetComponent<Transform>().position = currentPlayer.GetComponent<Transform>().position;
            this.transform.GetChild(1).gameObject.GetComponent<Transform>().localScale = currentPlayer.GetComponent<Transform>().localScale;
            this.transform.GetChild(2).gameObject.SetActive(false);
            currentPlayer = this.transform.GetChild(1).gameObject;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(true);
            this.transform.GetChild(2).gameObject.GetComponent<Transform>().position = currentPlayer.GetComponent<Transform>().position;
            this.transform.GetChild(2).gameObject.GetComponent<Transform>().localScale = currentPlayer.GetComponent<Transform>().localScale;
            currentPlayer = this.transform.GetChild(2).gameObject;
        }

        playerController = currentPlayer.GetComponent<PlayerController>();
    }

    
}
