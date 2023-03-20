using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Text manaText;
    //public static int HealthCurrent;
    //public static int HealthMax;
    private Image manaBar;

    public GameObject player;
    private PlayerAttributes playerAttr;


    // Start is called before the first frame update
    void Start()
    {
        manaBar = GetComponent<Image>();
        playerAttr = player.GetComponent<PlayerAttributes>();
    }

    void Update()
    {
        manaBar.fillAmount = playerAttr.currentMP / playerAttr.maxMP;
        manaText.text = playerAttr.currentMP.ToString("F2") + "/" + playerAttr.maxMP.ToString("F2");
    }
}
