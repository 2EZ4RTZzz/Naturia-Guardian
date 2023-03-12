 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text healthText;
    //public static int HealthCurrent;
    //public static int HealthMax;
    private Image healthBar;

    public GameObject player;
    private PlayerAttributes playerAttr;


    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        playerAttr = player.GetComponent<PlayerAttributes>();
    }
    
    void Update()
    {
        healthBar.fillAmount = playerAttr.currentHP / playerAttr.maxHP;
        healthText.text = playerAttr.currentHP.ToString("F2") + "/" + playerAttr.maxHP.ToString("F2");
    }
}
