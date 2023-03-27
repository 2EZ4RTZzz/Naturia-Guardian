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

    private float oriCrit, oriAtk, oriDef, oriHP, oriMP, oriCritDmg;
    private float addAtk1, addAtk2, addCrit1, addcrit2, addCritDmg1;

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
        oriCritDmg = critDmg;
        addAtk1 = 0;
        addAtk2 = 0;
        addCrit1 = 0;
        addcrit2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP > maxHP) currentHP = maxHP;
        if (currentHP < 0) currentHP = 0;
        if (currentMP > maxMP) currentMP = maxMP;
        if (currentMP < 0) currentMP = 0;
        if (crit > 90) crit = 90;

        atk = oriAtk + addAtk1 + addAtk2;
        crit = oriCrit + addCrit1 + addcrit2;
        critDmg = oriCritDmg + addCritDmg1;

        for (int i=0; i<buffs.buffList.Count; i++)
        {
            InventoryItem buff = buffs.buffList[i];
            if (buff.itemID == 1010)
            {
                addCrit1 = 5 * buff.itemAmount;
            }
            if (buff.itemID == 1011)
            {
                addAtk1 = 3 * buff.itemAmount;
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
            if (buff.itemID == 1015)
            {
                addAtk2 = 0.1f * (buff.itemAmount) * maxHP;
            }
            if (buff.itemID == 1016)
            {
                addcrit2 = 0.1f * (buff.itemAmount) * maxMP;
            }
            if (buff.itemID == 1017)
            {
                addCritDmg1 = 5*buff.itemAmount;
            }
        }
    }
}
