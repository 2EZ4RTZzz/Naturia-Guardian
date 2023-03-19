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

    private float oriCrit, oriAtk, oriDef, oriHP, oriMP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        currentMP = maxMP;
        oriCrit = crit;
        oriAtk = atk;
        oriDef = def;
        oriHP = maxHP;
        oriMP = maxMP;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<buffs.buffList.Count; i++)
        {
            InventoryItem buff = buffs.buffList[i];
            if (buff.itemID == 1010)
            {
                crit = oriCrit + 5 * buff.itemAmount;
            }
            if (buff.itemID == 1011)
            {
                atk = oriAtk + 3 * buff.itemAmount;
            }
            if (buff.itemID == 1012)
            {
                def = oriDef + 2 * buff.itemAmount;
            }
            if (buff.itemID == 1013)
            {
                maxHP = oriHP + 10 * buff.itemAmount;
            }
            if (buff.itemID == 1014)
            {
                maxMP = oriMP + 10 * buff.itemAmount;
            }
        }
    }
}
