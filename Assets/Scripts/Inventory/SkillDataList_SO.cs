using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillDataList_SO", menuName = "Inventory/SkillData")]

//背包数据列表
public class SkillDataList_SO : ScriptableObject
{
    public List<SkillDetails> fireRabbitSkills;
    public List<SkillDetails> iceRabbitSkills;
}
