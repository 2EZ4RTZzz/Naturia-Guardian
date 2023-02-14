using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuffState_SO", menuName = "Inventory/BuffState")]

//背包数据列表
public class BuffState_SO : ScriptableObject
{
    public List<InventoryItem> buffList;
}
