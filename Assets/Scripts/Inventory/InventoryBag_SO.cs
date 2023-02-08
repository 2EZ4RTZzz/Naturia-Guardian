using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryBag_SO", menuName = "Inventory/InventoryBag")]

//背包数据列表
public class InventoryBag_SO : ScriptableObject
{
    public List<InventoryItem> itemList;
}
