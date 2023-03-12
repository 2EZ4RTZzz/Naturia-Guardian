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

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        currentMP = maxMP;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
