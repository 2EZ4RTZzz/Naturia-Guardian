using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [Header("Input")]
    public float maxHP;
    public float maxMP;
    public float atk, def, crit, critDmg, doge;

    [Header("Current state")]
    public float currentHP;
    public float currentMP;

    [Header("Buff List")]
    public BuffState_SO buffs;

    private float oriCrit;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        currentMP = maxMP;
        oriCrit = crit;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<buffs.buffList.Count; i++)
        {
            InventoryItem buff = buffs.buffList[i];
            if (buff.itemID == 1010)
            {
                crit = oriCrit + 10 * buff.itemAmount;
            }
        }
    }
}
