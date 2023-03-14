using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUniversalController : MonoBehaviour
{
    private GameObject currentPlayer;
    public float healDuration;
    public int healAmount;
    [SerializeField] private float healTimer;
    private PlayerAttributes playerAttr;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = this.transform.GetChild(0).gameObject;
        playerAttr = GetComponent<PlayerAttributes>();
        healTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchPlayer();
        autoHeal();
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
    }

    public void autoHeal()
    {
        if(playerAttr.currentHP < playerAttr.maxHP / 2 && healTimer <= 0)
        {
            playerAttr.currentHP += healAmount;
            healTimer = healDuration;
        }
        if (healTimer > 0) healTimer -= Time.deltaTime;
    }
}
