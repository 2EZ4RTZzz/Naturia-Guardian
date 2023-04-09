using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/SavePlayerAttr")]
public class SavePlayerAttr : ScriptableObject
{
    public float maxHP;
    public float maxMP;
    public float atk, def, crit, critDmg, doge;
    public float currentHP;
    public float currentMP;
    public bool pass = false;
}
